   M S B A M L   `   `   `  ����>  :PTL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PTL.View.ComponentsPTL.View.Components  5      &     PTL.View.Components.Slider_Value   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PTL.View.Components     5      -   5          >�Name$
  Main��5      $��32��5	      .��5
      ]� -   5         ]�Name$ 
dpn_border��5
         
dpn_slider#��[  6!    � 	Resources 5       �� 
TargetType  
sl_default �� BasedOn �� Property �� Value �� ElementName  
tb_content  tb_ruleList��%�  '��       7  '��     7  '�� x    7  �� 5      " ��6   8   .�5      ��  � �� 5   	   �� *
Foreground+$
 Main��6:   �� 5       �@�Maximum 5   	   �� *	Maximum+$
 Main��67   �� 5       �@�Minimum 5   	   �� *	Minimum+$
 Main��67   5      �� 5      " ��6   8   .�5      ��  � �� 5   	   �� *
Foreground+$
 Main��6:   5      �� 5      " ��6   8   .�5      ��  �@��TextAlignment$ Center=�5   	   6   �� 5       � �� 5   	   �� *
Foreground+$
 Main��6:   �� 5        � �� 5!   	   �� *
Foreground+$
 Main��6:   5"      5#      .+�5$      �� ��6   �� *Text+$
 Main�� �� FallbackValue$
 Test��	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�5%   	   �� 5&      $��Right=�5'      ��5&      �� *Value+$
 Main��$ 0��$	 PropertyChanged=�$
 TwoWay=�5'      �� 5(       � Value 6   �� *Value+$
 Main��$ 24��$	 PropertyChanged=�$
 TwoWay=�5*      5+      