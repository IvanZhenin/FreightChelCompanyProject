   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:FreightChelCompanyProject.PagesOfAdmin&FreightChelCompanyProject.PagesOfAdmin  5      E    ?FreightChelCompanyProject.PagesOfAdmin.AdminCheckOrderStatsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:FreightChelCompanyProject.PagesOfAdmin     5      -   5          N� Title$  AdminCheckOrderStatsPage��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $	��115 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��350 �6   .+�5   
   �� 
����d�$��0��6-   $��2��6:    �� CornerRadius$ 5��6K   $��2��6\   (� 5   
   $��0��6   $��2��6   .��5      ��  �� Orientation$ 
Horizontal=�6   $��5 5 5 0q�62   $��Center=�6C   $��Center=�6^   .+�5      �� $5��/Общая статистика заказов ��6   $	��255��6=   
�������$��20(�6a   $��5q�6o   �� 5      $	��100��6   $	��950��6&   $ 5��62   $��2q�6C   
�������._�5      �� $ Vertical=�6!   $��5q�68   $��Center=�6C   .+�5      �� $ 
Horizontal=�6%   .+�5      �� $��Менеджер:��6(   $��95��69   
�������$��16(�6\   �� 5      -   5        $��choseManagerOrder��5   L   $��30��6'   $��5q�63   $��16(�6>   $	��240��6e   �� 5      $��Клиент:��6(   
�������$��16(�6O   �� 5      -   5        $��choseClientOrder��5   X   $��30��6'   $	��235��63   $��5q�6?   $��16(�6J   6X   5      �� 5      $ 
Horizontal=�6%   .+�5       �� $��Год заказов:��6(   $��95��6<   
�������$��16(�6_   �� 5!      -   5        $��choseYearOrders��5!   L   $��30��6'   $��5q�63   $��16(�6>   $	��160��6c   �� 5"      $ ��Месяц заказов:��6(   
�������$��16(�6V   �� 5#      -   5        $��choseMonthOrders��5#   L   $��30��6'   $��5q�63   $��16(�6>   $	��215��6d   �� 5$      -   5           ButtonStandard#��[  5$   %   
�������$��35��6e   $��35��6t    � ToolTip$ Поиск заказов��5%   %   $��3q�6=   ��5&   "   �� 5'   &   $��/Resources/search.png��6,   $��2q�6K   5)      5*      5+      5,      �� 5.      -   5        #��[  5.      $��10 5 5 5q�6A   
�������$= 7Вернуться на главную страницу��5/      $��35��6[   $��35��6j   ��50      �� 51      $!��/Resources/gohomebutton.png��6    $��2q�6E   53      54      55      �� 57   
   $��1��6   $��5q�6   
�������$ 5��6A   $��2��6R   �� 58   
   -   5        $��borderProducts��59   >   $��1��58      $��1��6   $��20 15 20 15q�6.   $	��300��6C   $��Center=�6O   
����d�$ 5��59   -   ._�5:      �� $5��/Наличие товаров в заказах��6   $��16(�69   
�������$��Arial)�6_   $��Center=�5;       $	��Top=�6=   $��20��6U   $��0 5 0 0q�6a   5<      �� 5=   
   -	   5        $��listBoxProducts��5=       �� SelectionMode$ Multiple=�6)   $��1��6B   $��1��6R   $��Center=�6_   $	��300��5>      $��16(�6   $��Arial)�6,   
�������$��30 50 30 75q�6W   �� 5?   
   $��1��6   $��1��6!   $��Center=�6.   $��Bottom=�6K   
�������$��
30 5 30 20q�5@   )   $	��300��6=   $��50��6I   ._�5A      �� -
   5        $��35��5A      $��5q�6!   $	��180��6,   #��[  68   $!��Очистить выбор��5B      $��16(�6.   $��Arial)�6<   6O   5C      (� 5E   
   $��1��6   $��0��6   $��20 15 20 15q�6/   .��5F      �� 
����d�$��3q�62   $ 5��6F   $	��800��6W   ._�5G      �� $ 
Horizontal=�6   $��Center=�66   .+�5H      �� $��15q�6   ._�5I      �� $ 
Horizontal=�6%   $	��Top=�6>   .+�5J      �� $ Vertical=�6)   .+�5K   "   �� $ ��Заказов всего:��6+   $��70��6C   $	��400��6O   
����d�$��2q�5L   +   $��5q�6?   $��Arial)�6J   $��16(�6]   .��5M   &   �� -   5         ��Name$ inputTotalQuanOrders��5M   .    �� 
IsReadOnly . $��5q�6^   $��30��6i   $��16(�6u   5N   #   �� 5O   "   $!��Статус заказов��6+   $	��400��6C   
����d�$��2q�5P   +   $��5q�6?   $��Arial)�6J   $��16(�6]   .��5Q   &   �� $ Vertical=�61   .+�5R   *   �� $��5q�65   $ 
Horizontal=�6@   .+�5S   .   �� $	��200��68   $*��$Заказов в ожидании: ��6D   �� 5T   .   -   5        $ inputWaitingOrders��5T   6    . $��5q�6d   $��30��6o   $��16(�6{   $	��170��6�   5U   +   �� 5V   *   $��5q�65   $ 
Horizontal=�6@   .+�5W   .   �� $	��200��68   $/��)Выполняющиеся заказы: ��6D   �� 5X   .   -   5        $ inputProccesingOrders��5X   6    . $��5q�6g   $��30��6r   $��16(�6~   $	��170��6�   5Y   +   �� 5Z   *   $��5q�65   $ 
Horizontal=�6@   .+�5[   .   �� $	��200��68   $+��%Выполненные заказы: ��6D   �� 5\   .   -   5        $ inputCompleteOrders��5\   6    . $��5q�6e   $��30��6p   $��16(�6|   $	��170��6�   5]   +   �� 5^   *   $��5q�65   $ 
Horizontal=�6@   .+�5_   .   �� $	��200��68   $)��#Отмененные заказы: ��6D   �� 5`   .   -   5        $ inputRefuseOrders��5`   6    . $��5q�6c   $��30��6n   $��16(�6z   $	��170��6�   5a   +   5b   '   5c   #   �� 5d   "   $#��Прибыль заказов��6+   $	��400��6D   
����d�$��2q�5e   +   $��5q�6?   $��Arial)�6J   $��16(�6]   .��5f   &   �� $ Vertical=�61   .+�5g   *   �� $��5q�65   $ 
Horizontal=�6@   .+�5h   .   �� $	��200��68   $1��+Потенциальная прибыль: ��6D   �� 5i   .   -   5        $ inputPotencSumOrders��5i   6    . $��5q�6f   $��30��6q   $��16(�6}   $	��170��6�   5j   +   �� 5k   *   $��5q�65   $ 
Horizontal=�6@   .+�5l   .   �� $	��200��68   $-��'Фактическая прибыль: ��6D   �� 5m   .   -   5        $ inputActualSumOrders��5m   6    . $��5q�6f   $��30��6q   $��16(�6}   $	��170��6�   5n   +   5o   '   5p   #   5q      5r      5s      5t      5u      5v      5w      5x      