   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  9!clr-namespace:PTL.View.ComponentsPTL.View.Components  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem &     PTL.View.MainWindow.CornerSetups   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PTL.View.MainWindow     2View!clr-namespace:PTL.View.Components     9system&clr-namespace:System;assembly=mscorlib     -     >�Name$
  Main��$	��350��.���� ���� *Width+ �� ElementName$
 Main�� � 	Resources  �� 
TargetType   btn_trigger �� BasedOn  
tb_content �� Property �� Value��%h   '��       7   '��      7  �� " ��8   �� " ��8   .���  � ��$ 60����  � ��$ 0��.+�d� -    d�Name$ chb_features�� d� 	IsChecked$ FalseY�$��FEATURES���� ._��� y��� *	IsChecked+$ chb_features��  b2v	 �� 	Converter#	 [ 
 �� FallbackValue$

 true��.+���  �� *st.IsMergeScreen+���� *l.IsMergeScreen+$&
  Merge multiple displays into one����  �� *st.IsMoveToCursor+���� *l.IsMoveToCursor+$"
 Move window to focus display����  �� *st.IsMoveToCursorKeep_State+���� *l.IsMoveToCursorKeep_State+$&
  Keep Relative state and position����  �� *st.IsMoveToCursor_Taskbar+���� *l.IsMoveToCursor_Taskbar+$%
 Place 1/3 width window properly����  �� *st.IsFormat+���� *
l.IsFormat+$%
 Format new window into the grid���� -    ��Name$ cv��$	��250������ *Width+$
 Main��   btn_demo_screen��%   '��       7  �� " ��8   ]� .+��� -    ��Name$ btn_add��$��Right=�  btn_Add#��[  � ToolTip$ Add new corner setup���� -   $ 
btn_remove��$��Right=�  
btn_Remove#��[ $ Delete selected setup���� -    ��Name$ 
cbb_setups���� -    ��Name$ tb_setup_name��$ Unique setup name������ *
Foreground+$ tb_setup_name������ *cs.Setup.Name+�� ._��� -    ��Name$ spn_add_setup��$y�Visible=�$ Screen corner side parts�� &    PTL.View.Components.Slider_Value��%�   '        �� "  .���  �@ Maximum$ 12����  �@ Minimum$ 1����  �@ Value$ 3����  � �� �� *
Foreground+$ btn_add_new_setup��.+�  -	     Name$ sl_Left��   Text$ Left:��  -
   $ sl_Top��$
 Top:��  -   $ sl_Right��$ Right:��  -   $ 	sl_Bottom��$ Bottom:��� .+��� -    ��Name$ 
tb_isvalid��$
��Left=��� -   $ btn_add_new_setup��$
��Save��$	��1.5q�$	��100��  	btn_Reset#��[ �� ._��� .+�� -    �Name$ 
setup_view��$	��210������ *Width+$
 Main��   chb_cornerSetup��%   '��       7  �� " ��8    � RowDefinitions �� -    ��Name$ setup_view_row��$��15������ *st.Corner_Distance+$
 15���� $��* ��� ���� *Height+$ setup_view_row�� � ColumnDefinitions �� ���� *Height+$ setup_view_row���� $��* ��� ���� *Height+$ setup_view_row��.+��� $��0��$��0���� $��0��$��2���� $��2��$��0���� $��2��$��2��A� -    A�Name$	 Top�� A� Rows$ 1��$��0��$��1��.+��� �� �� A� -   $ Bottom��$ 1��$��2��$��1��.+��� �� �� A� -   $
 Left�� A� Columns$ 1��$��1��$��0��.+��� �� �� A� -   $ Right��$ 1��$��1��$��2��.+��� �� �� �� $��1��$��1��.+��� -   $ btn_preview��  btn_demo_window#��[ $��Select A Corner Part�� � DataContext �� *cs.Setup.Selected+ �� Left �� *_Left+$
 0��
 �� Top �� *_Top+$
 0������ *_Width+$	
 305������ *	_Height+$	
 165���� -   $ spn_part_info��$# Corner part position and size�� �� *cs.Setup.Selected+ ��%j   '        �� "  .���  �@ Value$ 24����  � �� �� *
Foreground+$ btn_preview��.+�  $ Left:��   Value �� *Left+ �� UpdateSourceTrigger$ PropertyChanged=�  �� Mode$  TwoWay=�  $
 Top:�� �� *Top+$ PropertyChanged=�$  TwoWay=�  $ Width:�� �� *Width+$ PropertyChanged=�$  TwoWay=�  $ Height:�� �� *Height+$ PropertyChanged=�$  TwoWay=�]� -   ! ]�Name$! dpn_btn����.  .+��� -   $ Insert new corner part��#��[ $��Right=��� -   $! Remove selected corner part��#��[ $��Right=��� -   $# Load default Horizontal setup�� 
	 btn_Up#��[	 $
��Left=��� -   $! Load default Vertical setup��#��[	 $
��Left=��� #��[ ���� *st.RESET_CORNER_DISTANCE+" J� Effect" �� *Effect+$ sl_corner_distance��$  TwoWay=�.���� ��Z� �� $�Corner Trigger Distance: �� �� ��� *st.Corner_Distance+$
 10�� �� $�px���� -   # ��Name$# sl_corner_distance��$ � Value$ �� *st.Corner_Distance+$
 10���� #��[ ���� *st.RESET_CORNER_SENSITIVE+" �� *Effect+$ sl_corner_sensitive��$  TwoWay=�.���� ��Z� �� $�Corner Trigger Delay: �� �� ��� *st.Corner_Sensitive+ 
 mul#	 [
 % �� ConverterParameter$% 10��$
 10�� �� $�ms���� -   $# sl_corner_sensitive��$ �� *st.Corner_Sensitive+$
 10��