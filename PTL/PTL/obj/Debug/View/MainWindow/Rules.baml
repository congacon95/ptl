   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  5      9!clr-namespace:PTL.View.ComponentsPTL.View.Components  5          PTL.View.MainWindow.Rules   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.MainWindow     5      2View!clr-namespace:PTL.View.Components     5      $	��350��5
      .��5      �� .+�5      �� -   5          ��Name$  listviewRules��5      $	��215��5   	      lv_Rules#��[  5   	   $
��Left=�5   	   $
��Auto=�5   	   $
��Auto=�5   	    �� SelectedItem 5   	   �� *r.Rule+ �� Mode$ TwoWay=���5   	   �� *	r.Rules+ � 	Resources 5        
tb_content �� BasedOn �� 
TargetType �� Property �� Value��%G  '��       7  �� 5      8   " ��5   	   .�5      ��  � ��$ 12(�5   
   6   �� 5       � ��$
 auto��5   
   �� 5       � ��$ 0q�5   
   �� 5       � ��$
 Left=�5   
   �� 5        �@��TextAlignment$
 Left=�5!   
   �� 5"       � ��$ NoWrap=�5#   
   5$      5%       �� View 5&      �� 5'      .P�5(      �� $��Title��6   	 �� Width$		 120��5)      
 �� DisplayMemberBinding
 5*      �� *	Title.V+�� 5+      $��Class��6   $		 120��5,      
 5-      �� *	Class.V+�� 5.      $��	File Name��6   $		 120��5/      
 50      �� *	Process.V+5G      5I      ]� 5J      $��Bottom=�6   ��.   5L        btn_trigger��%4   '��       7  �� 5M      " ��6   8   5N   2   5O      .+�5P      ��  � ToolTip$	 Top��6     btn_Top#��[ 5R      ��5Q      �� *r.TOP+5R   .   �� 5S      $ Bottom��6     
btn_Bottom#��[ 5U      ��5T      �� *
r.BOTTOM+5V      �� 5W      $
 Down��6     btn_down#��[ 5Y      ��5X      �� *r.DOWN+5Z      �� 5[      $ Up��6    
 btn_Up#��[ 5]      ��5\      �� *r.UP+5]   -   �� 5^      $��Right=�5_        btn_Add#��[ 5`      $ Add New Rule��5a      ��5^      �� *r.ADD+5a   !   �� 5b      $ Delete Rule��6   $��Right=�5c        
btn_Remove#��[ 5e      ��5d      �� *
r.DELETE+5e   1   5f      �� 5g      -   5         ��Name$ spn_RuleInfo��5g      .+�5h      d� -   5         d�Name$ chb_conditions��5h       d� 	IsChecked$
 TrueY�5i      $��
CONDITIONS��5j      6"   �� 5k      ._�5l      �� y�6   �� *	IsChecked+ �� ElementName$ chb_conditions�� 	 b2v �� 	Converter# [	 .+�5m      &    PTL.View.Components.TextBox_Info     Text$ Title:��6    � DataContext 5n      �� *r.Rule.Title+67     5o      $ Class:��6    5p      �� *r.Rule.Class+67     5q      $ Name:��6    5r      �� *r.Rule.Process+69   5s      5t      d� 5u      -   5        $ chb_actions��5u      $
 TrueY�5v      $��ACTIONS��5w      6   �� 5x      ._�5y      �� y�6   �� *	IsChecked+$ chb_actions��# [	 .+�5z      �� $)��#Ignore          (No move or resize)��6    5{      �� *r.Rule.IsIgnore+�� 5|      $��Move only    (No resize)��6   $��Right=�5}       5~      �� *r.Rule.IsNoResize+�� 5       5�       
 	sld_value&    PTL.View.Components.Slider_Value��%�   &	
       �� 5�   	   "  5�      .�5�   
   ��  � ��$	 295��5�      6   �� 5�   
    �@ Minimum$	 -50��5�      6   �� 5�   
    � ��$ 50��5�      6   �� 5�   
    � ��$
 Left=�5�      6   5�   
   5�   	   .+�5�      � .+�5�   	   �� -   5         ��Name$ chb_top��5�       5�      �� *r.Rule.Top.B+  5�   	      Text$ Title:��6   #��[
 5�         Value 5�      �� *r.Rule.Top.V+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=� J� Effect 5�      �� *Effect+$ chb_top����5�      �� *
Foreground+$ chb_top��6K   5�   	   � 5�      .+�5�   	   �� -   5        $ 
chb_Border��5�       5�      �� *r.Rule.Border.B+  5�   	   $ Border:��6   #��[
 5�       5�      �� *r.Rule.Border.V+$ PropertyChanged=�$ TwoWay=� 5�      �� *Effect+$ 
chb_Border����5�      �� *
Foreground+$ 
chb_Border��6N   5�   	   � 5�      .+�5�   	   �� -   5        $ 
chb_bottom��5�       5�      �� *r.Rule.Bottom.B+  5�   	   $ Bottom:��6   #��[
 5�       5�      �� *r.Rule.Bottom.V+$ PropertyChanged=�$ TwoWay=� 5�      �� *Effect+$ 
chb_bottom����5�      �� *
Foreground+$ 
chb_bottom��6N   5�   	   5�      �� 5�      -   5        $ 
chb__State��5�      $!��Relative Position and Size:��5�       5�      �� *r.Rule._State.B+5�      �� 5�       6   �� *Effect+$ 
chb__State�� 5�      �� *r.Rule._State+.+�5�        $ Left:��6    5�      �� *V.Left+$ PropertyChanged=�$ TwoWay=���5�      �� *
Foreground+$ 
chb__State��6M     5�      $
 Top:��6    5�      �� *V.Top+$ PropertyChanged=�$ TwoWay=���5�      �� *
Foreground+$ 
chb__State��6M     5�      $ Width:��6    5�      �� *	V.Width+$ PropertyChanged=�$ TwoWay=���5�      �� *
Foreground+$ 
chb__State��6M     5�      $ Height:��6    5�      �� *
V.Height+$ PropertyChanged=�$ TwoWay=���5�      �� *
Foreground+$ 
chb__State��6M   5�      �� 5�      -	   5        $ 	chb_State��5�      $��Real Position and Size:��5�       5�      �� *r.Rule.State.B+�� 5�       6   �� *Effect+$ 	chb_State�� 5�      �� *r.Rule.State+.+�5�        $ Left:��6    5�      �� *V.Left+$ PropertyChanged=�$ TwoWay=�   Maximum 5�      �� *Bound.Right+   Minimum 5�      �� *
Bound.Left+��5�      �� *
Foreground+$ 	chb_State��6L     5�      $
 Top:��6    5�      �� *V.Top+$ PropertyChanged=�$ TwoWay=� 5�      �� *Bound.Bottom+ 5�      �� *	Bound.Top+��5�      �� *
Foreground+$ 	chb_State��6L     5�      $ Width:��6   $ 0��5�       5�      �� *	V.Width+$ PropertyChanged=�$ TwoWay=� 5�      �� *Bound.Width+��5�      �� *
Foreground+$ 	chb_State��6L     5�      $ Height:��6   $ 0��5�       5�      �� *
V.Height+$ PropertyChanged=�$ TwoWay=� 5�      �� *Bound.Height+��5�      �� *
Foreground+$ 	chb_State��6L   5�      5�      5�      5�      5�      5�      