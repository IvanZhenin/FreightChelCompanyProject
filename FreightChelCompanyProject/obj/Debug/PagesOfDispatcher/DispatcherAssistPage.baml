   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:FreightChelCompanyProject.PagesOfDispatcher+FreightChelCompanyProject.PagesOfDispatcher  5      F    @FreightChelCompanyProject.PagesOfDispatcher.DispatcherAssistPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:FreightChelCompanyProject.PagesOfDispatcher     5      -   5          N� Title$  DispatcherAssistPage��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��* �6   �� 5      $��55 �6   �� 5      $��* �6   .+�5   
   �� 
����d� �� CornerRadius$ 5��6-   $��0��6>   $��2��6K   (� 5   
   $��0��6   .��5      ��  �� Orientation$ Vertical=�6   $��0 5 0 0q�61   .+�5      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5      �� $��Клиенты��6    
�������$��18(�6G   $��5q�6U   �� 5      $��5q�6   $��2q�6(   
�������$	��520��6U   $��40��5      $ 5��6)   $��Center=�6:   ._�5      �� $��Center=�6%   $ 
Horizontal=�6B   .+�5      �� $��Имя: ��6(   
�������$��16(�6M   �� 5      -   5        $��inputSearchNameClient��5   W   $��30��6&   $	��165��62   $��5q�6>   $��16(�6I   6W   �� 5      $��Телефон: ��6(   
�������$��16(�6Q   �� 5      -   5        $��inputSearchPhoneClient��5   W   $��30��6&   $	��165��62   $��5q�6>   $��16(�6I   5      �� 5      -   5           ButtonStandard#��[  5   %   
������� � ToolTip$! Поиск клиентов��5      $��3q�62   ��5    "   �� 5!   &   $��/Resources/search.png��6,   $��2q�6K   5#      5$      5%      5&      5'      5(      &   System.Windows.Controls.DataGrid  5)   
   -   5        $��dateGridClients��5)         AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  $��1��5*      $��5q�6    
�������   CanUserResizeRows .  	   SelectionMode$	 Single=�6]   
   Columns
 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      MinWidth$ 50Q�6K      FontSize$ 16Q�6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Id+6Y     5-      $ Имя��6%   $	 190Q�6K   $ 16Q�6Z    62   �� *Name+6Z     5.      $ Телефон��6%   $	 120Q�6V   $ 16Q�6e    66   �� *PhoneNumber+6e     5/      $ Эл. почта��6%   $	 120Q�6R   $ 16Q�6a    68   �� *Email+6a   51      �� 53   
   
����d�$ 5��6-   $��2��6>   $��0 5 0 0q�6K   $��2��6\   (� 54   
   $��2��6   .��55      �� $ Vertical=�6   $��0 5 0 0q�60   .+�56      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�57      �� $��Товары��6    
�������$��18(�6F   $��5q�6T   �� 58      $��5q�6   $��2q�6(   
�������$	��520��6U   $��40��59      $ 5��6   $��Center=�6/   ._�5:      �� $��Center=�6%   $ 
Horizontal=�6B   .+�5;      �� $��Название: ��6(   
�������$��16(�6R   $��5 0 0 0q�6`   �� 5<      -   5        $��inputSearchNameProduct��5<   W   $��30��6&   $	��135��62   $��5q�6>   $��16(�6I   6W   �� 5=      $��Категория: ��6(   
�������$��16(�6S   �� 5>      -   5        $!��choseSearchCategorieProduct��5>   X   $��30��6'   $	��155��63   $��5q�6?   $��16(�6J   6X   �� 5?      -   5        #��[  5?   %   
�������$ Поиск товаров��5@      $��3q�62   ��5A   "   �� 5B   &   $��/Resources/search.png��6,   $��2q�6K   5D      5E      5F      5G      5H      5I        5J   
   -	   5        $��dateGridProds��5J       .   .  .  $��3��5K      $��5q�6    
������� .  $	 Single=�6]   
 5L        5M      $ 
Номер��6%   $ 50Q�6K   $ 16Q�6Y    64   �� *Id+6Y     5N      $ Название��6%   $	 190Q�6P   $ 16Q�6_    67   �� *Name+6_     5O      $ Категория��6%   $	 130Q�6\   $ 16Q�6k    68   �� *Categories.Name+6k     5P      $ Комплектация��6%   $	 140Q�6Y   $ 16Q�6h    6;   �� *	Equipment+6h     5Q      $ Вес (кг)��6%   $	 100Q�6R   $ 16Q�6a    67   �� *Weight+6a     5R      $ Цена (руб)��6%   $	 100Q�6j   $ 16Q�6y    69   �� *Price+ �� StringFormat$ {0:F2}��6y   5T      5U      5V      