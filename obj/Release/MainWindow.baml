   M S B A M L   `   `   `  ���� J  FGN-Convert-V1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GN_Convert_V1._0GN_Convert_V1._0  !    GN_Convert_V1._0.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:GN_Convert_V1._0     _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=� ! MaterialDesignLightBackground#���    MaterialDesignFont#���   � Title$0 *GN Estruturas | Conversor de Unidades V1.0��$	��557��$	��487�� � WindowStyle$ ThreeDBorderWindow=� � Icon$+ %/Logotipo_Colorido_SemFundo_Nome2.png�� � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=� � 	Resources   CustomFlatButtonStyle �� 
TargetType  MaterialDesignFlatButton	 �� BasedOn
 �� Property �� Value �� Triggers P� Property P� Value �� 
TargetType � RowDefinitions �� Padding��%�  &	       7  '�� �     �� " ��8	   .��� 
 � �� �#F2F2F2�� 
 � ��
 �   ��� 
 � �� �#8C8C8C�� 
 � ��$ 1q��� 
 � ��$ 14(��� 
 � ��$ Normal"� P�  �@J�IsMouseOver . . ��� 
 � ��
 � � ��� " ��.��� 
 � �� �� " ��.R��  �� $
��Auto ��� $��* �.+��� $��0�����#0C1D40$ 5q�$��0q�._��� #��z��
�������$��Normal"��� $��1��#��z�� � FocusVisualStyle �� .���  �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* �.+��� $��DADOS DE ENTRADA:��$��0��$��0��$��10,10,10,10q�$��14(�.���� .+��� $��Unidade de Força:��$
��Left=����	#FF3A3A3A$��Normal"��� -    ��Name$ cmbUnidadesForca�� �� SelectedIndex$ 0��$	��110��$��Normal"�$��Center=�$��Stretch=�.@��� $	��kgf���� $��Tf���� $��N���� $��kN���� $��Unidade de Comprimento:��$
��Left=����	#FF3A3A3A$��Normal"��� -   $ cmbUnidadesComprimento��$ 0��$	��110��$��Normal"�.@��� $��m���� $��cm���� $��mm���� $��Unidade de Tensão:��$
��Left=����	#FF3A3A3A$��Normal"��� -   $ cmbUnidadesTensaoDe��$ 1��$	��110��$��Normal"�.@��� $��Kgf/mm2���� $��Kgf/cm2���� $��Kgf/m2���� $��Tf/mm2���� $��Tf/cm2���� $��Tf/m2���� $��N/mm2���� $��N/cm2���� $
��N/m2���� $��KN/mm2���� $��KN/cm2���� $��KN/m2���� $	��MPa���� $	��KPa���� $��Pa���� $��Valor de Entrada:��$
��Left=����	#FF3A3A3A$��Normal"��� -    ��Name$ txtValor��$	��130��#��� ��$��Normal"��� $��0��$��1�� �� Orientation$ Vertical=�$��10,10,10,102q�.+��� -    ��Name$ BtnCalcularForca��$��FORÇA��$��0,0,0,5q�$	��200��$��30��$��center=�4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ FromClip=�#��[ �� -   $! BtnCalcularForcaComprimento��$��FORÇA/COMPRIMENTO��$��0,0,0,5q�$	��200��$��30��$��Center=�#��[ �� -   $ BtnCalcularMomentoFletor��$��MOMENTO FLETOR��$��0,0,0,5q�$	��200��$��30��$��center=�#��[ �� -   $ BtnCalcularTensao��$��TENSÃO��$��0,0,0,5q�$	��200��$��30��$��center=�#��[ �� $��CONVERSÃO DE UNIDADES:��$��1��$��0��$��2��$��	8,10,10,0q�$	��352��$	��Top=�$��14(�.���� -	    ��Name$ txtResultado��$��Stretch=�$	��Top=�$
��Wrap=�$��10q�$	��300�����	#FF1C2675��Z� �� ���#8C8C8C$��1q�$��87��$��
10,0,10,10q�$��Bottom=�$��1��$��2��._�� .+��� $
��Left=�$��75��$��Center=�$	��148��$+��%/Logotipo_Colorido_SemFundo_Nome2.png��$��UniformToFill=�$��	307,0,0,0q��� $ Vertical=�$��Center=�$
��Left=�.+��� $#��Engº Guilherme Luiz Nardelli��$��Normal"��� $��Normal"�$	��456��$��5,0,0,0q��� -
   $!��https://gnestruturas.eng.br?�.��� $!�https://gnestruturas.eng.br���� $'��!GN Estruturas | Copyright © 2022��$��Normal"�