   M S B A M L   `   `   `  ����  UI    UI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6K   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5        $
��1600��5   /  $	��900��6<    � WindowStyle$
  None=�6I   � Title$ Tasks��6\   � WindowState$ 	Maximized=�6j  .��5      �  � ColumnDefinitions 5   
   �� 5      $
��150* �6   �� 5      $
��500* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��500* �6   �� 5	      $
��100* �6   �� 5
      $
��150* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��100* �6   �� 5      $
��100* �6   �� 5      $
��500* �6   �� 5      $
��100* �6   .+�5   
   ��    Border.Background#���   6   $��7��6B   $��18q�6V    �� CornerRadius$ 32��6b   ._�5      ]� -   5        ���#0000.+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�63   $��Center=�6L   $
��32,0q�6g   .+�5      �� ���#FFF$
��16,0q�6.   $��Center=�6<   $��Segoe Fluent Icons)�6^   $��32(�6~   $	����6�   �� 5      ���#FFF$
��16,0q�6.   $��Center=�6<   $��32(�6^   $��Tasks��6l   5      �� 5      $��Right=�6   $ 
Horizontal=�64   $��Right=�6M   $��Center=�6i   $
��32,0q�6�   .+�5      �� -   5         ��Name$ ChromeMinimize��5      $	����65     Command#���  6H   6j   �� 5      -   5        $ ChromeMaximize��5      $	����65   #���  6H   6j   �� 5      -   5        $ ChromeClose��5      $	����62   #���  6E   6g   5      �� 5      $ 
Horizontal=�6   $��Right=�66   $��Center=�6R   $
��32,0q�6m   .+�5      �� -   5         ��Name$ ComboBox��5      $��32(�61   $	��200��6?   6K   �� 5       -   5        $ Refresh��5       $	����6.   #���  6A   6c   5!      5"      5#      &   System.Windows.Controls.DataGrid  5$   
   -   5        	  Name$	 Me��5$      $��3��6   $��1��6,   �� 5%   
   -	   5        $	 Add��5%      $��3��6   $��2��6+   $��Segoe Fluent Icons)�6;   $	����6[   6n     5&   
   -
   5        $	 My��5&      $��3��6   $��4��6,   �� 5'   
   -   5        $
 Send��5'      $��3��6   $��5��6,   $��Segoe Fluent Icons)�6<   $	����6\   6o   5(      5)      