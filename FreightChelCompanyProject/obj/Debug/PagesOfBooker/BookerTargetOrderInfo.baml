   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:FreightChelCompanyProject.PagesOfBooker'FreightChelCompanyProject.PagesOfBooker  5      C    =FreightChelCompanyProject.PagesOfBooker.BookerTargetOrderInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:FreightChelCompanyProject.PagesOfBooker     5        N� Title$  BookerTargetOrderInfo��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��* �6   �� 5      $��55 �6   �� 5      $��* �6   .+�5   
   �� 
����d� �� CornerRadius$ 5��6-   $��0��6>   $��2��6K   (� 5   
   $��0��6   .��5      ��  �� Orientation$ Vertical=�6   $��0 5 0 0q�60   .+�5      �� $��5q�6   $��2q�6$   
�������$	��520��6Q   $��40��5      $ 5��6%   $��Center=�66   ._�5      �� $��Данные заказа��6    
�������$��20(�6M   $��5q�6[   $��Center=�6f   5      5      5      �� 5   
   
���   �$��2q�6%   $ 5��69   $��1��6J   
�������$��15 10 15 10q�6o   ._�5      (� $��15q�6   .��5      �� $ Vertical=�6   $��Center=�64   $��Center=�6O   .+�5      �� $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5      �� -   5        $��currentWorkerText��5   $   $��16(�6=      TextBlockOrderList#��[  6K   5       �� 5"      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5#      �� -   5        $��currentClientText��5#   $   $��16(�6=   #��[  6K   5$      �� 5&      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5'      �� -   5        $��currentClientPhoneText��5'   $   $��16(�6B   #��[  6P   5(      �� 5*      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5+      �� -   5        $��currentClientEmailText��5+   $   $��16(�6B   #��[  6P   5,      �� 5.      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5/      �� -   5         ��Name$ currentAddresDelText��5/   $   $��16(�6B   #��[  6P   50      �� 52      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�53      �� $ 
Horizontal=�6%   .+�54      �� -   5        $ currentDateEndText��54   (   $��16(�6D   #��[  6R   55      56      �� 58      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�59      �� -   5        $ currentWeightText��59   $   $��16(�6?   #��[  6M   5:      5;      5<      5=      �� 5?   
   
����d�$ 5��6-   $��2��6>   $��0 5 0 0q�6K   $��2��6\   (� 5@   
   $��2��6   .��5A      �� $ Vertical=�6   $��0 5 0 0q�60   .+�5B      �� $��5q�6   $��2q�6$   
�������$	��520��6Q   $��40��5C      $ 5��6   $��Center=�6+   ._�5D      �� $��Состав заказа��6    
�������$��20(�6M   $��5q�6[   $��Center=�6f   5E      5F      5G      &   System.Windows.Controls.DataGrid  5I   
   -   5        $��dateGridProdsInOrder��5I         AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  $��3��5J      $��5q�6    
�������   CanUserResizeRows .  	   Columns	 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Код товара��6%      MinWidth$ 90Q�6Y      FontSize$ 18Q�6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Products.Id+6g     5M      $
 Название��6%   $	 200Q�6Y   $ 18Q�6h    67   �� *Products.Name+6h     5N      $
 Количество��6%   $	 130Q�6V   $ 18Q�6e    69   �� *
Quantity+6e   5P      5Q      5R      