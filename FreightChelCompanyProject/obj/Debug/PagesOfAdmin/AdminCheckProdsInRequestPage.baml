   M S B A M L   `   `   `  ����T  PFreightChelCompanyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:FreightChelCompanyProject.PagesOfAdmin&FreightChelCompanyProject.PagesOfAdmin  5      I    CFreightChelCompanyProject.PagesOfAdmin.AdminCheckProdsInRequestPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:FreightChelCompanyProject.PagesOfAdmin     5      -   5          N� Title$   AdminCheckProdsInOrderPage��5	      .��5
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
Quantity+6e   5      �� 5   
   $��2��6   
�������$��2q�66   $��5q�6J   $ 5��6U   ._�5      �� -   5        $��
Назад��5         ButtonStandard#��[  6%   $��40��6M   $	��190��6Y   $��18(�5       $��5q�6=   5!      5"      5#      