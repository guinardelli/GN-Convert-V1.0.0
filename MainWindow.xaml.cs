using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace GN_Convert_V1._0
{
    public partial class MainWindow : Window
    {
        Dictionary<string, double> pressureConversionFactors = new Dictionary<string, double>
        {
         {"Kgf/mm2", 1 / 0.0980665},
            {"Kgf/cm2", 1},
            {"Kgf/m2", 10000},
            {"Tf/mm2", 1 / 98.0665},
            {"Tf/cm2", 100},
            {"Tf/m2", 1000000},
            {"N/mm2", 1 / 9.80665},
            {"N/cm2", 1 / 0.0980665},
            {"N/m2", 1 / 0.0000980665},
            {"kN/mm2", 1000 / 9.80665},
            {"kN/cm2", 10},
            {"kN/m2", 1000},
            {"MPa", 1 / 0.00980665},
            {"KPa", 0.1 / 0.00980665},
            {"Pa", 0.0001 / 0.00980665}
        };

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void TxtValor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddColoredResult(string unit, double value, SolidColorBrush color)
        {
            txtResultado.Inlines.Add(new Run($"{value:0.##} ") { Foreground = color });
            txtResultado.Inlines.Add(new Run($"{unit}") { Foreground = color });
            txtResultado.Inlines.Add(new LineBreak());
        }


        private void BtnCalcularForca_Click(object sender, RoutedEventArgs e)
        {
            double valor;
            if (!double.TryParse(txtValor.Text, out valor))
            {
                MessageBox.Show("Digite um valor válido.");
                return;
            }

            double kgf = 0, tf = 0, n = 0, kn = 0;

            switch ((cmbUnidadesForca.SelectedItem as ComboBoxItem).Content.ToString())
            {
                case "kgf":
                    kgf = valor;
                    tf = valor / 1000;
                    n = valor * 9.80665;
                    kn = n / 1000;
                    break;
                case "Tf":
                    kgf = valor * 1000;
                    tf = valor;
                    n = kgf * 9.80665;
                    kn = n / 1000;
                    break;
                case "N":
                    kgf = valor / 9.80665;
                    tf = kgf / 1000;
                    n = valor;
                    kn = n / 1000;
                    break;
                case "kN":
                    n = valor * 1000;
                    kgf = n / 9.80665;
                    tf = kgf / 1000;
                    kn = valor;
                    break;
            }

            txtResultado.Inlines.Clear();
            AddColoredResult("kgf", kgf, Brushes.DarkSlateBlue);
            AddColoredResult("Tf", tf, Brushes.DimGray);
            AddColoredResult("N", n, Brushes.LightSeaGreen);
            AddColoredResult("kN", kn, Brushes.Crimson);
        }

        private void BtnCalcularForcaComprimento_Click(object sender, RoutedEventArgs e)
        {
            double valor;
            if (!double.TryParse(txtValor.Text, out valor))
            {
                MessageBox.Show("Digite um valor válido.");
                return;
            }

            double kgf_m = 0, tf_m = 0, n_m = 0, kn_m = 0;
            double kgf_cm = 0, tf_cm = 0, n_cm = 0, kn_cm = 0;
            double kgf_mm = 0, tf_mm = 0, n_mm = 0, kn_mm = 0;

            switch ((cmbUnidadesComprimento.SelectedItem as ComboBoxItem).Content.ToString())
            {
                case "m":
                    kgf_m = valor;
                    tf_m = valor / 1000;
                    n_m = valor * 9.80665;
                    kn_m = n_m / 1000;
                    kgf_cm = kgf_m / 100;
                    tf_cm = tf_m / 100;
                    n_cm = n_m / 100;
                    kn_cm = kn_m / 100;
                    break;
                case "cm":
                    kgf_cm = valor;
                    tf_cm = valor / 1000;
                    n_cm = valor * 9.80665;
                    kn_cm = n_cm / 1000;
                    kgf_m = kgf_cm * 100;
                    tf_m = tf_cm * 100;
                    n_m = n_cm * 100;
                    kn_m = kn_cm * 100;
                    break;
                case "mm":
                    kgf_cm = valor / 10;
                    tf_cm = valor / 10000;
                    n_cm = valor * 9.80665 / 10;
                    kn_cm = n_cm / 1000;
                    kgf_m = kgf_cm / 100;
                    tf_m = tf_cm / 100;
                    n_m = n_cm / 100;
                    kn_m = kn_cm / 100;
                    break;
            }

            txtResultado.Inlines.Clear();
            AddColoredResult("kgf/m", kgf_m, Brushes.DarkSlateBlue);
            AddColoredResult("kgf/cm", kgf_cm, Brushes.DarkSlateBlue);
            AddColoredResult("kgf/mm", kgf_mm, Brushes.DarkSlateBlue);
            AddColoredResult("Tf/m", tf_m, Brushes.DimGray);
            AddColoredResult("Tf/cm", tf_cm, Brushes.DimGray);
            AddColoredResult("Tf/mm", tf_mm, Brushes.DimGray);
            AddColoredResult("N/m", n_m, Brushes.LightSeaGreen);


        }



        private void BtnCalcularMomentoFletor_Click(object sender, RoutedEventArgs e)
        {
            double valor;
            if (!double.TryParse(txtValor.Text, out valor))
            {
                MessageBox.Show("Digite um valor válido.");
                return;
            }

            var unidadeForcaSelecionada = (cmbUnidadesForca.SelectedItem as ComboBoxItem).Content.ToString();
            var unidadeComprimentoSelecionada = (cmbUnidadesComprimento.SelectedItem as ComboBoxItem).Content.ToString();

            double kgf_m = 0, tf_m = 0, n_m = 0, kn_m = 0;

            switch (unidadeForcaSelecionada)
            {
                case "kgf":
                    kgf_m = valor;
                    tf_m = valor / 1000;
                    n_m = valor * 9.80665;
                    kn_m = n_m / 1000;
                    break;
                case "Tf":
                    kgf_m = valor * 1000;
                    tf_m = valor;
                    n_m = kgf_m * 9.80665;
                    kn_m = n_m / 1000;
                    break;
                case "N":
                    kgf_m = valor / 9.80665;
                    tf_m = kgf_m / 1000;
                    n_m = valor;
                    kn_m = n_m / 1000;
                    break;
                case "kN":
                    n_m = valor * 1000;
                    kgf_m = n_m / 9.80665;
                    tf_m = kgf_m / 1000;
                    kn_m = valor;
                    break;
            }

            double kgf_cm = kgf_m * 100, kgf_mm = kgf_m * 1000;
            double tf_cm = tf_m * 100, tf_mm = tf_m * 1000;
            double n_cm = n_m * 100, n_mm = n_m * 1000;
            double kn_cm = kn_m * 100, kn_mm = kn_m * 1000;

            txtResultado.Inlines.Clear();
            AddColoredResult("kgf.m", kgf_m, Brushes.DarkSlateBlue);
            AddColoredResult("kgf.cm", kgf_cm, Brushes.DarkSlateBlue);
            AddColoredResult("kgf.mm", kgf_mm, Brushes.DarkSlateBlue);
            AddColoredResult("Tf.m", tf_m, Brushes.DimGray);
            AddColoredResult("Tf.cm", tf_cm, Brushes.DimGray);
            AddColoredResult("Tf.mm", tf_mm, Brushes.DimGray);
            AddColoredResult("N.m", n_m, Brushes.LightSeaGreen);
            AddColoredResult("N.cm", n_cm, Brushes.LightSeaGreen);
            AddColoredResult("N.mm", n_mm, Brushes.LightSeaGreen);
            AddColoredResult("kN.m", kn_m, Brushes.Crimson);
            AddColoredResult("kN.cm", kn_cm, Brushes.Crimson);
            AddColoredResult("kN.mm", kn_mm, Brushes.Crimson);
        }

        private string FormatarNumero(double numero)
        {
            return string.Format("{0:#,##0.######}", numero);
        }



        private void BtnCalcularTensao_Click(object sender, RoutedEventArgs e)
        {
            double valor;
            if (!double.TryParse(txtValor.Text, out valor))
            {
                MessageBox.Show("Digite um valor válido.");
                return;
            }

            string unitFrom = (cmbUnidadesTensaoDe.SelectedItem as ComboBoxItem).Content.ToString();

            txtResultado.Inlines.Clear();
            foreach (string unitTo in pressureConversionFactors.Keys)
            {
                double result = ConvertPressure(valor, unitFrom, unitTo);

                Run resultRun = new Run($"{FormatarNumero(result)} {unitTo}") { FontWeight = FontWeights.Bold };
                if (unitTo.StartsWith("Kgf"))
                {
                    resultRun.Foreground = Brushes.DarkSlateBlue;
                }
                else if (unitTo.StartsWith("Tf"))
                {
                    resultRun.Foreground = Brushes.DimGray;
                }
                else if (unitTo.StartsWith("N"))
                {
                    resultRun.Foreground = Brushes.LightSeaGreen;
                }
                else if (unitTo.StartsWith("kN"))
                {
                    resultRun.Foreground = Brushes.Crimson;
                }
                else
                {
                    resultRun.Foreground = Brushes.Black;
                }

                txtResultado.Inlines.Add(resultRun);
                txtResultado.Inlines.Add(new LineBreak());
            }
        }



        private void cmbUnidadesTensao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Seu código aqui
        }



        private double ConvertPressure(double value, string from, string to)
        {
            double fromFactor = pressureConversionFactors[from];
            double toFactor = pressureConversionFactors[to];

            return (value * fromFactor) / toFactor;
        }
    }
}



