   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CarFixWPF.StorehouseCarFixWPF.Storehouse  5   	   ,    &CarFixWPF.Storehouse.winStorehouseList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:CarFixWPF.Storehouse     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$ winStorehouseList��5   	   $	��480��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�6<    � WindowStyle$
 None=�6a   $��0q�6t   .��5      � .+�5   
   �� ���#1c2c3c.+�5      � $��30��6   $	��Top=�6   
���   �.+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6o   $��0q�6�   ��6B   Z� ��6X   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   
�������$��30��6N   $��30��6Z   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgvData��5      $��15q�6(   
������ $
��Bold"�6M   
�������   CanUserAddRows .  	   
IsReadOnly	 . $	��438��6�   
   Columns
 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Foto del Almacen��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6G      
IsReadOnly .    CellTemplate 5      �� 5      .R�5   "   �� $��80��6(   $��80��63   ��6?   �� *photo+5      5       5"      5#      5$      5%      