   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FreightChelCompanyProjectFreightChelCompanyProject  5   	   .    (FreightChelCompanyProject.DispatcherMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FreightChelCompanyProject     5   	     � Title$'  !Панель диспетчера��5   	   $	��720��6#   $
��1280��63    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon 5
      �� 5   
    �� 	UriSource$ /Resources/logo.png?�6   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   $��80��6(   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $	��100��6   �� 5      $��* �6   �� 5      -   5         ��Name$ assistColumn��5   .   $	��650��6   6.   .+�5   
   �� $#��/Resources/dispatcherIcon.png��6   $��70��67   $��70��6C   $��5q�6N   $��0��5      $��0��6   $��Center=�6-   $��Center=�6H   �� 5   
   $��0��6   
����d�$��0 0 3 0q�6;   �� 5   
   -   5        $��textUserPosition��5      $��24(�6,   $��5q�6:   $��0��6E   $��1��6R   $��2��5      $��Center=�6(   �� 5   
   $��0��6   
����d�$��3 3 3 0q�6;   $��3��6U   �� 5    
   $��1��6   
����d�$��3q�6;   $��2��6O   $��3��6`    � 5!   
   -   5        $��dispatcherTargetFrame��5!        � NavigationUIVisibility$ Hidden=�6-   $��1��6M   $��1��6Z   $��2��5"      $��
5 10 10 10q�6!    � 5$   
   -   5        $��dispatcherAssistFrame��5$      $ Hidden=�6-   $��1��6M   $��2��6Z   $��2��5%      $��
5 10 15 10q�6!   �� 5'   
   $��1��6   $��2��6   $��3q�6/   
����d�$��10q�5(       �� CornerRadius$ 5��6   
�������6.   �� 5)   
   $��1��6   $��Center=�6   $��Center=�69   
����d�$��0 3 0 3q�5*   .   $��75��6H   ._�5+      �� 	 �� Orientation$	 Vertical=�6   $��5q�60   .+�5,      �� -   5        $��buttonAssistBack��5-   $   $��50��5,      $��50��6%      ButtonStandard#��[  6J   $��5q�5-      
 � ToolTip$M
 GСкрыть информацию о клиентах и товарах��6<   ��5.      �� 5/      $��/Resources/buttonback.png��6    $��3q�6C   51      �� 52      -   5        $��buttonAssistUp��53   $   $��50��52      $��50��6%   #��[  6J   $��5q�53      $Q
 KПоказать информацию о клиентах и товарах��6:   ��54      �� 55      $!��/Resources/buttonassist.png��6    $��3q�6E   57      �� 58      -   5        $��50��58      $��50��6%   #��[  6N   $��5q�59      $.
 (Добавить новую заявку��6$   ��5:      �� 5;      $��/Resources/buttonadd.png��6    $��3q�6B   5=      �� 5>      -   5        $��50��5>      $��50��6%   #��[  6J   $��5q�5?      $-
 'Перезапустить панель��6$   ��5@      �� 5A      $��/Resources/reboot.png��6    $��3q�6?   5C      �� 5D      -	   5        $��50��5D      $��50��6%   #��[  60   $��5q�5E   3   $$
 Выйти из системы��6>   ��5F      �� 5G      $!��/Resources/buttonlogout.png��6    $��3q�6E   5I      5J      5K      5L      5M      