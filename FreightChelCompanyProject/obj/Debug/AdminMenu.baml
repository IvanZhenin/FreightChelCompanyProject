   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FreightChelCompanyProjectFreightChelCompanyProject  5   	   )    #FreightChelCompanyProject.AdminMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FreightChelCompanyProject     5   	     � Title$/  )Панель администратора��5   	   $	��720��6'   $
��1280��67    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon 5
      �� 5   
    �� 	UriSource$ /Resources/logo.png?�6   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   $��80��6(   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��/Resources/adminIcon.png��6   $��75��62   $��75��6>   $��5q�6I   $��0��5      $��0��6   $��Center=�6-   $��Center=�6H   �� 5   
   $��0��6   
����d�$��0 0 3 0q�6;   �� 5   
   -   5        $��textUserPosition��5      $��24(�6,   $��5q�6:   $��0��6E   $��1��6R   $��2��5      $��Center=�6(   �� 5   
   $��0��6   
����d�$��3 3 3 0q�6;   $��3��6U   �� 5   
   $��1��6   
����d�$��3q�6;   $��2��6O   $��2��6c    � 5!   
   -   5        $��adminTargetFrame��5!      $��10q�6(   $��1��64   $��1��6A   $��2��6Q     � NavigationUIVisibility$ Hidden=�6b   �� 5#   
   $��1��6   $��2��6   $��3q�6/   
����d�$��10q�5$       �� CornerRadius$ 5��6   
�������6.   �� 5%   
   $��1��6   $��Center=�6   $��Center=�69   
����d�$��0 3 0 3q�5&   .   $��75��6H   ._�5'      ��  �� Orientation$ Vertical=�6   $��5q�60   .+�5(      �� -   5        $��50��5(      $��50��6%      ButtonStandard#��[  6J   $��5q�5)      	 � ToolTip$-	 'Перезапустить панель��6$   ��5*      �� 5+      $��/Resources/reboot.png��6    $��3q�6?   5-      �� 5.      -   5        $��50��5.      $��50��6%   #��[  60   $��5q�5/   3   $$	 Выйти из системы��6>   ��50      �� 51      $!��/Resources/buttonlogout.png��6    $��3q�6E   53      54      55      56      57      