   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FreightChelCompanyProjectFreightChelCompanyProject  5   	   *    $FreightChelCompanyProject.BookerMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FreightChelCompanyProject     5   	     � Title$'  !Панель бухгалтера��5   	   $	��720��6#   $
��1280��63    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon 5
      �� 5   
    �� 	UriSource$ /Resources/logo.png?�6   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   $��80��6(   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      -   5         �Name$ assistColumn��5   .   $	��650��6   6.   .+�5   
   �� $��/Resources/bookerIcon.png��6   $��75��63   $��75��6?   $��5q�6J   $��0��5      $��0��6   $��Center=�6-   $��Center=�6H   �� 5   
   $��0��6   
����d�$��0 0 3 0q�6;   �� 5   
   -   5        $��textUserPosition��5   E   $��0��6   $��1��6!   $��2��61   $��24(�5      $��5q�6"   $��Center=�6-   �� 5    
   $��0��6   $��3��6   
����d�$��3 3 3 0q�6O   �� 5!   
   $��1��6   $��2��6   $��3��6/   
����d�$��3q�6`    � 5#   
   -   5        $��bookerTargetFrame��5#   -   $��1��6   $��1��6   $��10q�6F   $��2��5$        � NavigationUIVisibility$ Hidden=�6!    � 5%   
   -   5        $��bookerAssistFrame��5%   -   $��1��6   $��2��6   $��
5 10 10 10q�6F   $��2��5&      $ Hidden=�6!   �� 5(   
   $��1��6   $��2��6   $��3q�6/   
����d�$��10q�5)       �� CornerRadius$ 5��6   
�������6.   �� 5*   
   $��1��6   $��Center=�6   $��Center=�69   
����d�$��0 3 0 3q�5+   .   $��75��6H   ._�5,      �� 	 �� Orientation$	 Vertical=�6   $��5q�60   .+�5-      �� -   5        $��buttonAssistBack��5.   $   $��50��5-      $��50��6%      ButtonStandard#��[  6J   $��5q�5.      
 � ToolTip$M
 GСкрыть информацию о клиентах и товарах��6<   ��5/      �� 50      $��/Resources/buttonback.png��6    $��3q�6C   52      �� 53      -   5        $��buttonAssistUp��54   $   $��50��53      $��50��6%   #��[  6J   $��5q�54      $Q
 KПоказать информацию о клиентах и товарах��6:   ��55      �� 56      $!��/Resources/buttonassist.png��6    $��3q�6E   58      �� 59      -   5        $��50��59      $��50��6%   #��[  6J   $��5q�5:      $-
 'Перезапустить панель��6$   ��5;      �� 5<      $��/Resources/reboot.png��6    $��3q�6?   5>      �� 5?      -   5        $��50��5?      $��50��6%   #��[  60   $��5q�5@   3   $$
 Выйти из системы��6>   ��5A      �� 5B      $!��/Resources/buttonlogout.png��6    $��3q�6E   5D      5E      5F      5G      5H      