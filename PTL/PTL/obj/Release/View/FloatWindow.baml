   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PTL.ViewPTL.View  clr-namespace:PTLPTL      PTL.View.FloatWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'Viewclr-namespace:PTL.View     !Appclr-namespace:PTL     -     � Title$  FloatWindow��$	��160��$��90�� � Topmost .  � AllowsTransparency .  � ShowInTaskbar .   � WindowStyle$
 None=����	#01000000 � 	Resources    chb_cornerSetup �� BasedOn �� 
TargetType��%   '��       7   �� 8   " ��.��� .+�� -    �Name$ 
LayoutRoot��.+��� $
��Left=�$	��Top=����� *Height+	 �� ElementName$	 	TopBorder��
 �� FallbackValue$
 15������ *Height+$	 	TopBorder��$
 15���� $��Right=�$	��Top=����� *Height+$	 	TopBorder��$
 15������ *Height+$	 	TopBorder��$
 15���� $��Right=�$��Bottom=����� *Height+$	 	TopBorder��$
 15������ *Height+$	 	TopBorder��$
 15���� $
��Left=�$��Bottom=����� *Height+$	 	TopBorder��$
 15������ *Height+$	 	TopBorder��$
 15��� -   $ 	TopBorder��$	��Top=����� *CheckBoxWidth+  sub �� 	Converter# [  �� ConverterParameter$ 0��$
 15�� � ColumnDefinitions �� ���� *Height+$	 	TopBorder��$
 15���� $��* ��� ���� *Height+$	 	TopBorder��$
 15��.+�A� -    A�Name$ 	TopCorner�� A� Columns$ 3��$��1������ *Height+$	 	TopBorder��$
 15��.+��� �� �� � -   $ BottomBorder��$��Bottom=� �� ���� *Height+$	 	TopBorder��$
 15���� $��* ��� ���� *Height+$	 	TopBorder��$
 15��.+�A� -   $ BottomCorner��$ 3��$��1������ *Height+$	 	TopBorder��$
 15��.+��� �� �� � -   $ 
LeftBorder��$
��Left=� � RowDefinitions �� ���� *Height+$	 	TopBorder��$
 15���� $��* ��� ���� *Height+$	 	TopBorder��$
 15��.+�A� -   $ 
LeftCorner�� A� Rows$ 3��$��1������ *Height+$	 	TopBorder��$
 15��.+��� �� �� � $��Right=� �� ���� *Height+$	 	TopBorder��$
 15���� $��* ��� ���� *Height+$	 	TopBorder��$
 15��.+�A� -	   $ RightCorner��$ 3��$��1������ *Height+$	 	TopBorder��$
 15��.+��� �� �� �� -
    ��Name$ btn_ShowCornerSetup��$��20��$��0q�
����  �  	dropBlack J� Effect# [ 
����� ����� *Width+$	 btn_ShowCornerSetup������  �� 
TargetType" ��.R�� .+��� #��z��$	��1.5q�  dropLime# [  �� CornerRadius$ 20������ bdbg�� �� Color$
 Blue�� �� Opacity$	 0.0Q���  ��Name$	 bar��#��z��$��2��$ 1��$��10���� #��z��$��2��$ 1������ *Width+$		 bar�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value .  N� EnterActions �� .���� .��W�  �� 
TargetName$
 bdbg�� �� TargetProperty$ Opacity�	 W� To$ 1X�  animationTimeFast  g� Duration#  [ W� $ Width�$ 30X�#  [ W� $ Width�$	 bar��$ 15X�#  [ ! N� ExitActions! �� .���� .��W� $
 bdbg��$ Opacity�$	 0.0X�#  [ W� $ Width�$ 20X�#  [ W� $ Width�$	 bar��$ 10X�#  [ . ��� " �� Value#" [ # �� Property# �@J�Effect