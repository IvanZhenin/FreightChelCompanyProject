   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:FreightChelCompanyProject.PagesOfDispatcher+FreightChelCompanyProject.PagesOfDispatcher  5      Q    KFreightChelCompanyProject.PagesOfDispatcher.DispatcherProductsInRequestPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:FreightChelCompanyProject.PagesOfDispatcher     5      -   5          N� Title$%  DispatcherProductsInRequestPage��5	      .��5
      �  � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $
��649* �6   �� 5      $��80 �6   .+�5   
   �� 
����d�$��0��6-   $��3��6:    �� CornerRadius$ 5��6K   �� 5   
   $��0��6   $��	15 5 15 5q�6   
�������$��2q�6J   $ 5��6^   ._�5      �� -   5         ��Name$ txtBlockStartPage��5      $��Center=�63   
�������$��18(�6h   5      �� 5   
   $��1��6   $��5q�6   
�������$ 5��6A   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dateGridProdsInRequest��5   ,   $��1��6   $��10q�6    
�������   
IsReadOnly .    CanUserReorderColumns .     CanUserResizeRows .     AutoGenerateColumns .     SelectionMode$ Single=�5   /   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Код товара��6%      MinWidth$	 100Q�6T      FontSize$ 16Q�6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *ProdId+6c     5      $
 
Товар��6%   $	 150Q�6V   $ 16Q�6e    64   �� *Products.Name+6e     5      $
 Количество��6%   $	 100Q�6V   $ 16Q�6e    69   �� *
Quantity+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 120Q�6)      CellTemplate 5      �� 5      .R�5      �� -   5        $��Изменить��5   %      ButtonStandard#��[  68   $��16(�6`   $��5q�5    K   $��30��6V   5!      5#        5$      $	 120Q�6)    5%      �� 5&      .R�5'      �� -   5        $��Удалить��5'   %   #��[  67   $��16(�6_   $��5q�5(   M   $��30��6X   5)      5+      5-      �� 5.   
   $��2��6   
�������$��2q�66   $��5q�6J   $ 5��6U   ._�5/      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   $��5q�6j   .+�50      �� -   5        $��Добавить��50      #��[  6,   $��40��6T   $	��170��6`   $��18(�51      $��5 5 15 5q�6N   �� 52      -   5        $��
Назад��52      #��[  6)   $��40��6Q   $	��170��6]   $��18(�53      $��5q�6A   54      55      56      57      