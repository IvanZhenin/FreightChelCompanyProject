   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:FreightChelCompanyProject.PagesOfAdmin&FreightChelCompanyProject.PagesOfAdmin  5      B    <FreightChelCompanyProject.PagesOfAdmin.AdminPickupPointsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:FreightChelCompanyProject.PagesOfAdmin     5      -   5          N� Title$  AdminPickupPointsPage��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      .+�5   
   �� 
����d�$��0��6-   $��2��6:    �� CornerRadius$ 5��6K   (� 5   
   $��0��6   .��5      ��  �� Orientation$ 
Horizontal=�6   $��5 5 5 0q�62   $��Center=�6C   $��Center=�6^   .+�5      �� $/��)Список пунктов выдачи ��6   $	��225��6:   
�������$��20(�6^   $��5q�6l   �� 5      -   5        $��35��5      $��35��6(      ButtonStandard#��[  66   
�������$��5 0 5 0q�5   1    � ToolTip$4 .Добавить новую категорию��6B   .��5      �� $��/Resources/buttonadd.png��6   $��3q�6>   5      �� 5      $��50��6   $
��1000��6%   $ 5��62   $��2q�6C   
�������._�5      �� $ 
Horizontal=�6!   $��5q�6:   $��Center=�6E   .+�5      �� $��Номер:��6$   
�������$��16(�6J   �� 5      -   5        $��inputSearchNumPoint��5   0   $��30��5   "   $��5q�6.   $��16(�5   "   $	��100��6K   �� 5      $��Адрес пункта:��6$   
�������$��16(�6Q   �� 5      -   5        $��inputSearchPointName��5   S   $��30��6"   $	��195��6.   $��5q�6:   $��16(�6E   6S   �� 5      -   5        #��[  5   !   
�������$��35��6a   $��35��6p   $, &Поиск пунктов выдачи��5    !   $��3q�6@   ��5!      �� 5"   "   $��/Resources/search.png��6(   $��2q�6G   5$      5%      5&      �� 5(      -   5        #��[  5(      $��10 5 5 5q�6A   
�������$= 7Вернуться на главную страницу��5)      $��35��6[   $��35��6j   ��5*      �� 5+      $!��/Resources/gohomebutton.png��6    $��2q�6E   5-      5.      5/      �� 51   
   $��1��6   $��5q�6   
�������$ 5��6A   &   System.Windows.Controls.DataGrid  52   
   -   5        $��dateGridPickupPoints��52   ,   $��1��6   $��10q�6    
�������   AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .     CanUserResizeRows .  	   SelectionMode$	 Single=�54   -   
   Columns
 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      MinWidth$ 90Q�6K      FontSize$ 18Q�6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Id+6Y     57      $ 
Адрес��6%   $	 280Q�6P   $ 18Q�6_    64   �� *	Address+6_   4  .System.Windows.Controls.DataGridTemplateColumn  58      $	 130Q�6)      CellTemplate 59      �� 5:      .R�5;      �� -   5        $��Изменить��5;   %   $��18(�68   $��5q�6F   $��30��6Q   #��[  5<   %   6M   5=      5?        5@      $	 130Q�6)    5A      �� 5B      .R�5C      �� -	   5        $��Удалить��5C   %   $��18(�67   $��5q�6E   $��30��6P   #��[  5D   %   6M   5E      5G      5I      5J      5K      