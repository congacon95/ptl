   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5      9!clr-namespace:PTL.View.ComponentsPTL.View.Components  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      &     PTL.View.MainWindow.CornerSetups   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.MainWindow     5      2View!clr-namespace:PTL.View.Components     5      9system&clr-namespace:System;assembly=mscorlib     5      -   5          >�Name$
  Main��5
      $	��350��5      .��5      �� ��6   �� *Width+ �� ElementName$
 Main�� � 	Resources 5       �� 
TargetType   btn_trigger �� BasedOn  
tb_content �� Property �� Value��%�   '��       7   '�� &     7  �� 5      " ��6   8   5   1   �� 5      " ��6   8   .�5      ��  � ��$ 60��5   	   6   �� 5       � ��$ 0��5   	   5      5      .+�5      d� -   5         d�Name$ chb_features��5       d� 	IsChecked$ FalseY�5   
   $��FEATURES��5   
   6   �� 5      ._�5      �� y�6   �� *	IsChecked+$ chb_features��  b2v	 �� 	Converter#	 [ 
 �� FallbackValue$

 true��.+�5      ��  6   �� *st.IsMergeScreen+��5   
   �� *l.IsMergeScreen+$&
  Merge multiple displays into one��6b   �� 5        6   �� *st.IsMoveToCursor+��5!   
   �� *l.IsMoveToCursor+$"
 Move window to focus display��6_   �� 5"       6   �� *st.IsMoveToCursorKeep_State+��5#   
   �� *l.IsMoveToCursorKeep_State+$&
  Keep Relative state and position��6m   �� 5$       6   �� *st.IsMoveToCursor_Taskbar+��5%   
   �� *l.IsMoveToCursor_Taskbar+$%
 Place 1/3 width window properly��6j   �� 5&       6   �� *st.IsFormat+��5'   
   �� *
l.IsFormat+$%
 Format new window into the grid��6\   5(      5)      �� 5*      -   5         ��Name$ cv��5*      $	��250��5,      ��5+      �� *Width+$
 Main�� 5-        btn_demo_screen��%4   '��       7  �� 5.      " ��6   8   5/   6   50      51      ]� 52      .+�53      �� -   5         ��Name$ btn_add��53      $��Right=�55        btn_Add#��[ 56       � ToolTip$ Add new corner setup��57      6)   �� 58      -   5        $ 
btn_remove��58      $��Right=�59        
btn_Remove#��[ 5;      $ Delete selected setup��5<      6*   �� 5=      -   5         ��Name$ 
cbb_setups��5=      5?      5@      �� 5A      -   5         ��Name$ tb_setup_name��5A      $ Unique setup name��5C      ��5D      �� *
Foreground+$ tb_setup_name����5E      �� *cs.Setup.Name+6)   �� 5F      ._�5G      �� -   5         ��Name$ spn_add_setup��5I   
   $y�Visible=�5G      $ Screen corner side parts��5H   
    5J      &    PTL.View.Components.Slider_Value��%  '        �� 5K      "  6   .�5L      ��  �@ Maximum$ 12��5M      6   �� 5N       �@ Minimum$ 1��5O      6   �� 5P       �@ Value$ 3��5Q      6   �� 5R       � �� 5S      �� *
Foreground+$ btn_add_new_setup��6I   5T      5U      .+�5V        -	   5          Name$ sl_Left��5W         Text$ Left:��5V      5W   "     5X      -
   5        $ sl_Top��5Y      $
 Top:��5X      5Y   !     5Z      -   5        $ sl_Right��5[      $ Right:��5Z      5[   #     5\      -   5        $ 	sl_Bottom��5]      $ Bottom:��5\      5]   $   � 5^      .+�5_      �� -   5         ��Name$ 
tb_isvalid��5_      $
��Left=�6%   6B   �� 5`      -   5        $ btn_add_new_setup��5a   
   $
��Save��5b   
   $	��1.5q�5c   
   $	��100��5d   
     	btn_Reset#��[ 5e   
   6/   5f      5g      5h      �� 5i      ._�5j      �� .+�5k      � -   5         �Name$ 
setup_view��5k      $	��210��5m      ��5n      �� *Width+$
 Main�� 5o        chb_cornerSetup��%4   '��       7  �� 5p      " ��6   8   5q   8   5r       � RowDefinitions 5s      �� 5t      -   5         ��Name$ setup_view_row��5t      $��15��5u      ��5v      �� *st.Corner_Distance+$
 15��6I   �� 5w      $��* �6   6#   �� 5x      ��6   �� *Height+$ setup_view_row��6M    � ColumnDefinitions 5z      �� 5{      ��6   �� *Height+$ setup_view_row��6O   �� 5|      $��* �6   6%   �� 5}      ��6   �� *Height+$ setup_view_row��6O   .+�5      �� $��0��6   $��0��5�      �� 5�      $��0��6   $��2��5�      �� 5�      $��2��6   $��0��5�      �� 5�      $��2��6   $��2��5�      A� 5�      -   5         A�Name$	 Top��5�       A� Rows$ 1��5�      $��0��5�      $��1��5�      .+�5�      �� �� 5�      �� 5�      5�      A� 5�      -   5        $ Bottom��5�      $ 1��5�      $��2��5�      $��1��5�      .+�5�      �� �� 5�      �� 5�      5�      A� 5�      -   5        $
 Left��5�       A� Columns$ 1��5�      $��1��5�      $��0��5�      .+�5�      �� �� 5�      �� 5�      5�      A� 5�      -   5        $ Right��5�      $ 1��5�      $��1��5�      $��2��5�      .+�5�      �� �� 5�      �� 5�      5�      �� 5�      $��1��6   $��1��5�   
   .+�5�      �� -   5        $ btn_preview��5�        btn_demo_window#��[ 5�      $��Select A Corner Part��5�       � DataContext 5�      �� *cs.Setup.Selected+ �� Left 5�      �� *_Left+$
 0��
 �� Top 5�      �� *_Top+$
 0����5�      �� *_Width+$	
 305����5�      �� *	_Height+$	
 165��5�      5�      5�      �� 5�      -   5        $ spn_part_info��5�      $# Corner part position and size��5�       5�      �� *cs.Setup.Selected+ 5�      ��%�   '        �� 5�      "  6   .�5�   	   ��  �@ Value$ 24��5�      6   �� 5�   	    � �� 5�      �� *
Foreground+$ btn_preview��6C   5�   	   5�      .+�5�        $ Left:��6      Value 5�      �� *Left+ �� UpdateSourceTrigger$ PropertyChanged=�  �� Mode$  TwoWay=�6[     5�      $
 Top:��6    5�      �� *Top+$ PropertyChanged=�$  TwoWay=�6Z     5�      $ Width:��6    5�      �� *Width+$ PropertyChanged=�$  TwoWay=�6\     5�      $ Height:��6    5�      �� *Height+$ PropertyChanged=�$  TwoWay=�6]   5�      ]� 5�      -   5        ! ]�Name$! dpn_btn��5�   &   ��.  .+�5�      �� -   5        $ Insert new corner part��5�      #��[ 5�   
   $��Right=�5�   
   6#   �� 5�      -   5        $! Remove selected corner part��5�      #��[ 5�   
   $��Right=�5�   
   6#   �� 5�      -   5        $# Load default Horizontal setup��5�       
	 btn_Up#��[	 5�   
   $
��Left=�5�   
   6"   �� 5�      -   5        $! Load default Vertical setup��5�      #��[	 5�   
   $
��Left=�5�   
   6"   5�      �� 5�      #��[ 5�   	   ��5�      �� *st.RESET_CORNER_DISTANCE+" J� Effect" 5�      �� *Effect+$ sl_corner_distance��$  TwoWay=�.��5�      �� ��6   Z� �� 5�   
   $�Corner Trigger Distance: ��6   61    �� 5�   
   �6   �� *st.Corner_Distance+$
 10�� �� 5�   
   $�px��6   6   5�      �� 5�      -   5        # ��Name$# sl_corner_distance��5�      $ � Value$ 5�      �� *st.Corner_Distance+$
 10��5�   /   �� 5�      #��[ 5�   	   ��5�      �� *st.RESET_CORNER_SENSITIVE+" 5�      �� *Effect+$ sl_corner_sensitive��$  TwoWay=�.��5�      �� ��6   Z� �� 5�   
   $�Corner Trigger Delay: ��6   6.    �� 5�   
   �6   �� *st.Corner_Sensitive+ 
 mul#	 [
 % �� ConverterParameter$% 10��$
 10�� �� 5�   
   $�ms��6   6   5�      �� 5�      -   5        $# sl_corner_sensitive��5�      $ 5�      �� *st.Corner_Sensitive+$
 10��5�   8   5�      5�      5�      5�      