   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:FreightChelCompanyProject.PagesOfManager(FreightChelCompanyProject.PagesOfManager  5      G    AFreightChelCompanyProject.PagesOfManager.ManagerTargetRequestInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:FreightChelCompanyProject.PagesOfManager     5        N� Title$  ManagerTargetRequestInfo��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��* �6   �� 5      $��55 �6   �� 5      $��* �6   .+�5   
   �� 
����d� �� CornerRadius$ 5��6-   $��0��6>   $��2��6K   (� 5   
   $��0��6   .��5      ��  �� Orientation$ Vertical=�6   $��0 5 0 0q�60   .+�5      �� $��5q�6   $��2q�6$   
�������$	��520��6Q   $��40��5      $ 5��6%   $��Center=�66   ._�5      �� $��Данные заявки��6    
�������$��20(�6M   $��5q�6[   $��Center=�6f   5      5      5      �� 5   
   
���   �$��2q�6%   $ 5��69   $��1��6J   
�������$��15 10 15 10q�5   )   ._�5      (� $��15q�6   .��5      �� $ Vertical=�6   $��Center=�64   $��Center=�6O   .+�5      �� $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5       �� -   5        $��currentWorkerText��5    $   $��16(�6=      TextBlockOrderList#��[  6K   5!      �� 5#      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5$      �� -   5        $��currentClientText��5$   $   $��16(�6=   #��[  6K   5%      �� 5'      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5(      �� -   5        $��currentClientPhoneText��5(   $   $��16(�6B   #��[  6P   5)      �� 5+      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�5,      �� -   5        $��currentClientEmailText��5,   $   $��16(�6B   #��[  6P   5-      �� 5/      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�50      �� -   5         ��Name$ currentAddresDelText��50   $   $��16(�6B   #��[  6P   51      �� 53      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�54      �� -   5        $ currentDateText��54   $   $��16(�6=   #��[  6K   55      �� 57      $	��475��6   $��25��6)   
���   �$��0 0 0 2q�6I   $��0 8 0 8q�6c   ._�58      �� -   5        $ currentWeightText��58   $   $��16(�6?   #��[  6M   59      5:      5;      5<      �� 5>   
   
����d�$ 5��6-   $��2��6>   $��0 5 0 0q�6K   $��2��6\   (� 5?   
   $��2��6   .��5@      �� $ Vertical=�6   $��0 5 0 0q�61   .+�5A      �� $��5q�6   $��2q�6$   
�������$	��520��6Q   $��40��5B      $ 5��6%   $��Center=�66   ._�5C      �� $��Состав заявки��6    
�������$��20(�6M   $��5q�6[   $��Center=�6f   5D      5E      5F      &   System.Windows.Controls.DataGrid  5H   
   -   5        $��dateGridProdsInRequest��5H         AutoGenerateColumns .     
IsReadOnly .    CanUserReorderColumns .  $��3��5I      $��5q�6    
�������   CanUserResizeRows .  	   Columns	 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Код товара��6%      MinWidth$ 90Q�6Y      FontSize$ 18Q�6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Products.Id+6g     5L      $
 Название��6%   $	 200Q�6Y   $ 18Q�6h    67   �� *Products.Name+6h     5M      $
 Количество��6%   $	 130Q�6V   $ 18Q�6e    69   �� *
Quantity+6e   5O      5P      5Q      