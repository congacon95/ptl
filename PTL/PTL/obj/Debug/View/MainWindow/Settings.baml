   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5      "    PTL.View.MainWindow.Settings   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.MainWindow     5      .��5
      ��   � 	Resources  5         
sl_default �� BasedOn �� 
TargetType �� Property �� Value��%b  '��       7   �� 5      8   " ��5      �5      �� 5       �@�Maximum$ 1Q�5   
   6   �� 5       �@�Minimum$
 0.01Q�5   
   6   �� 5       �@��TickFrequency$
 0.01Q�5   
   6   �� 5       �@�LargeChange$	 0.1Q�5   
   6   �� 5       �@�SmallChange$
 0.01Q�5   
   6   5      5      .+�5      d� -   5         d�Name$ chb_general��5      $��GENERAL��5   
   6   �� 5      ._�5      �� y�6   �� *	IsChecked+ �� ElementName$ chb_general��  b2v �� 	Converter# [ .+�5       ��  d� 	IsChecked 6   �� *	st.IsOn+��5!   
   �� *l.IsOn+	 �� FallbackValue$	 Background Tasks��6I   �� 5"      ��6   �� *st.RESET_INTERVAL_MAIN+
 J� Effect
 5#      �� *Effect+$ sl_interval�� �� Mode$ TwoWay=�y�5$   	   �� *	st.IsOn+# [ .��5%      �� �� 5&   
   $�Interval Time: ��6   6'    �� 5'   
   �6   �� *st.Interval_Main+  mul# [  �� ConverterParameter$ 10��$	 50�� �� 5(   
   $�ms��6   6   5)      �� 5*      -   5         ��Name$ sl_interval��5+       � ToolTip$! Background task circle time��5,   	    � Maximum$ 20Q�5.   	    � Minimum$ 1Q�5/   	    � LargeChange$ 1Q�50   	    � Value 5*      �� *st.Interval_Main+$	 5��y�5-   	   �� *	st.IsOn+# [ 50      �� 51      $ Keep main window topmost��52   
    51      �� *st.IsTopmost+��53   
   �� *l.IsTopmost+$	 Topmost��6E   �� 54       6   �� *st.IsStartWithWindow+ 55   
   �� *l.IsStartWithWindow+$	 Startup with windows OS����56   
   �� *l.IsStartWithWindow+$	 Startup with windows OS��6]   �� 57      $ When mouse click away��58   
    57      �� *st.IsAutoHide+��59   
   �� *l.IsAutoHide+$	 Auto hide SETTING window��6W   �� 5:      $% Always stay on left screen side��5;   
    5:      �� *st.IsStickyMainWindow+��5<   
   �� *l.IsStickyMainWindow+$	 Sticky SETTING window��6\   ]� 5>      .+�5?      �� -   5        $ Select a language��5?      $��Right=�5B      $	��100��5C       �� SelectedIndex 5@      �� *l.ID+$	 0��.@�5D      �� .��6   	English6   �� 5E      .��6   
Vietnamese6!   �� 5F      .��6   	Chinese6   5G      �� 5H      $  Select from drop down list��6   .��63   	Language:6>   5I      5J      5K      d� 5L      -   5        $ chb_appearance��5L      $
 TrueY�5M   
   $��
APPEARANCE��5N   
   6!   �� 5O      ._�5P      �� y�6   �� *	IsChecked+$ chb_appearance��# [ .+�5Q      ]� .+�5R      �� $% Select floating button position��6   $��Right=�5T      $	��100��5U       5S      �� *st.ID_FloatPos+$	 0��.@�5V      �� ��6   �� *
l.Top_Left+$	 Top-Left��6P   �� 5W      ��6   �� *l.Top_Right+$	 	Top-Right��6R   �� 5X      ��6   �� *l.Bottom_Left+$	 Bottom-Left��6V   �� 5Y      ��6   �� *l.Bottom_Right+$	 Bottom-Right��6X   5Z      �� 5[      $  Select from drop down list��6   .��63   Floating button position:6N   5\      �� 5]       6   �� *st.IsAppearance+��5^   
   �� *l.IsAppearance+$	 Beautiful Appreance��6T   A� 5_       A� Rows$ 1��5`      y�5_      �� *st.IsAppearance+# [ .+�5a      �� .��6   Lime6   �� 5b      .��6   Blue6   �� 5c      .��6   Sring6   5d      �� 5e       6   �� *st.IsBlurMain+��5f   
   �� *l.IsBlurMain+$!	 Blur main window background��6Z   �� 5g       6   �� *st.IsBlurOverlay+��5h   
   �� *l.IsBlurOverlay+$$	 Blur overlay window background��6`   �� 5i       6   �� *st.IsBlurFloat+��5j   
   �� *l.IsBlurFloat+$%	 Blur floating button background��6_   �� 5k      ��6   �� *st.RESET_OPACITY_MAIN+.��5l      �� �� 5m      $�Main Opacity: ��6
   6"    �� 5n      �6
   �� *st.Opacity_Main+# [ $	 100��$	 1�� �� 5o      $�%��6
   6   5p      �� 5q       6   �� *st.Opacity_Main+$		 0.5��6C   �� 5r      ��6   �� *st.RESET_OPACITY_MENU+.��5s      �� �� 5t      $�Menu Opacity: ��6
   6"    �� 5u      �6
   �� *st.Opacity_Menu+# [ $	 100��$	 1�� �� 5v      $�%��6
   6   5w      �� 5x       6   �� *st.Opacity_Menu+$		 0.5��6C   �� 5y      ��6   �� *st.RESET_OPACITY_OVERLAY+.��5z      �� �� 5{      $�Overlay Opacity: ��6
   6%    �� 5|      �6
   �� *st.Opacity_Overlay+# [ $	 100��$	 1�� �� 5}      $�%��6
   6   5~      �� 5       6   �� *st.Opacity_Overlay+$		 0.5��6F   �� 5�      ��6   �� *st.RESET_BORDER_OVERLAY+.��5�      �� �� 5�      $�Overlay Border: ��6
   6$    �� 5�      �6
   �� *st.Border_Overlay+ �� 5�      $�px��6
   6   5�      �� 5�      $ 48Q�5�   	   $ 0Q�5�   	   $ 1Q�5�   	    5�      �� *st.Border_Overlay+5�      5�      5�      �� 5�      -   5         ��Name$ chb_hook��5�      .��64   Unhook6<   5�      5�      