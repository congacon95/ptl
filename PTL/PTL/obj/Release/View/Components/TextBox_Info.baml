   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.ComponentsPTL.View.Components  &     PTL.View.Components.TextBox_Info   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8
Components!clr-namespace:PTL.View.Components     -     >�Name$
  Main��.���  � 	Resources    
chb_switch �� BasedOn �� 
TargetType��%   '��       7   �� 8   " ��.+��� -    ��Name$ chb_text������ *Text+ �� ElementName$
 Main�� d� 	IsChecked �� *B+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�"   PTL.View.Components.TextBoxs  	 J� Effect	 �� *Effect+$ chb_text������ *
Foreground+$ chb_text��
   Value
 �� *V+$ PropertyChanged=�$ TwoWay=�