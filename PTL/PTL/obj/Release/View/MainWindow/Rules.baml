   M S B A M L   `   `   `  ���� >  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.MainWindowPTL.View.MainWindow  9!clr-namespace:PTL.View.ComponentsPTL.View.Components      PTL.View.MainWindow.Rules   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PTL.View.MainWindow     2View!clr-namespace:PTL.View.Components     $	��350��.���� .+��� -     ��Name$  listviewRules��$	��215��   lv_Rules#��[  $
��Left=�$
��Auto=�$
��Auto=� �� SelectedItem �� *r.Rule+ �� Mode$ TwoWay=����� *	r.Rules+ � 	Resources   
tb_content �� BasedOn �� 
TargetType �� Property �� Value��%�   '��       7  �� 8   " ��.���  � ��$ 12(���  � ��$
 auto����  � ��$ 0q���  � ��$
 Left=���  �@��TextAlignment$
 Left=���  � ��$ NoWrap=� �� View �� .P��� $��Title��	 �� Width$		 120��
 �� DisplayMemberBinding
 �� *	Title.V+�� $��Class��$		 120��
 �� *	Class.V+�� $��	File Name��$		 120��
 �� *	Process.V+]� $��Bottom=���.     btn_trigger��%   '��       7  �� " ��8   .+���  � ToolTip$	 Top��  btn_Top#��[ ���� *r.TOP+�� $ Bottom��  
btn_Bottom#��[ ���� *
r.BOTTOM+�� $
 Down��  btn_down#��[ ���� *r.DOWN+�� $ Up�� 
 btn_Up#��[ ���� *r.UP+�� $��Right=�  btn_Add#��[ $ Add New Rule������ *r.ADD+�� $ Delete Rule��$��Right=�  
btn_Remove#��[ ���� *
r.DELETE+�� -    ��Name$ spn_RuleInfo��.+�d� -    d�Name$ chb_conditions�� d� 	IsChecked$
 TrueY�$��
CONDITIONS���� ._��� y��� *	IsChecked+ �� ElementName$ chb_conditions�� 	 b2v �� 	Converter# [	 .+�&    PTL.View.Components.TextBox_Info     Text$ Title:�� � DataContext �� *r.Rule.Title+  $ Class:�� �� *r.Rule.Class+  $ Name:�� �� *r.Rule.Process+d� -   $ chb_actions��$
 TrueY�$��ACTIONS���� ._��� y��� *	IsChecked+$ chb_actions��# [	 .+��� $)��#Ignore          (No move or resize)�� �� *r.Rule.IsIgnore+�� $��Move only    (No resize)��$��Right=� �� *r.Rule.IsNoResize+��   
 	sld_value&    PTL.View.Components.Slider_Value��%{   &	
       �� "  .���  � ��$	 295����  �@ Minimum$	 -50����  � ��$ 50����  � ��$
 Left=�.+�� .+��� -    ��Name$ chb_top�� �� *r.Rule.Top.B+     Text$ Title:��#��[
    Value �� *r.Rule.Top.V+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=� J� Effect �� *Effect+$ chb_top������ *
Foreground+$ chb_top��� .+��� -   $ 
chb_Border�� �� *r.Rule.Border.B+  $ Border:��#��[
  �� *r.Rule.Border.V+$ PropertyChanged=�$ TwoWay=� �� *Effect+$ 
chb_Border������ *
Foreground+$ 
chb_Border��� .+��� -   $ 
chb_bottom�� �� *r.Rule.Bottom.B+  $ Bottom:��#��[
  �� *r.Rule.Bottom.V+$ PropertyChanged=�$ TwoWay=� �� *Effect+$ 
chb_bottom������ *
Foreground+$ 
chb_bottom���� -   $ 
chb__State��$!��Relative Position and Size:�� �� *r.Rule._State.B+��  �� *Effect+$ 
chb__State�� �� *r.Rule._State+.+�  $ Left:�� �� *V.Left+$ PropertyChanged=�$ TwoWay=����� *
Foreground+$ 
chb__State��  $
 Top:�� �� *V.Top+$ PropertyChanged=�$ TwoWay=����� *
Foreground+$ 
chb__State��  $ Width:�� �� *	V.Width+$ PropertyChanged=�$ TwoWay=����� *
Foreground+$ 
chb__State��  $ Height:�� �� *
V.Height+$ PropertyChanged=�$ TwoWay=����� *
Foreground+$ 
chb__State���� -	   $ 	chb_State��$��Real Position and Size:�� �� *r.Rule.State.B+��  �� *Effect+$ 	chb_State�� �� *r.Rule.State+.+�  $ Left:�� �� *V.Left+$ PropertyChanged=�$ TwoWay=�   Maximum �� *Bound.Right+   Minimum �� *
Bound.Left+���� *
Foreground+$ 	chb_State��  $
 Top:�� �� *V.Top+$ PropertyChanged=�$ TwoWay=� �� *Bound.Bottom+ �� *	Bound.Top+���� *
Foreground+$ 	chb_State��  $ Width:��$ 0�� �� *	V.Width+$ PropertyChanged=�$ TwoWay=� �� *Bound.Width+���� *
Foreground+$ 	chb_State��  $ Height:��$ 0�� �� *
V.Height+$ PropertyChanged=�$ TwoWay=� �� *Bound.Height+���� *
Foreground+$ 	chb_State��