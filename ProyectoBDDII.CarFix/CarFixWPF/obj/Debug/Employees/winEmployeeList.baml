   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CarFixWPF.EmployeesCarFixWPF.Employees  5   	   )    #CarFixWPF.Employees.winEmployeeList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -local!clr-namespace:CarFixWPF.Employees  5   	   -   5          � Title$  winEmployeeList��5	   	   $	��450��6!   $	��950��6.    � WindowStyle$
 None=�6:   .��5
      � .+�5   
   �� ���#1c2c3c.+�5      � $��30��6   $	��Top=�6   
���   �.+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6o   $��0q�6�    � Cursor$
 Hand��6�   ��6B   Z� ��6X   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   
�������$��30��6N   $��30��6Z   5      5      �� 5      $��50��6    �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $��Buscar:��6   $��Center=�6+   $��20(�6F   ���#e16b34$
��Bold"�6i   $��Paladins)�6{   �� 5      -   5         ��Name$ txtSearchName��5      $	��300��61   $��Center=�6=   $��10q�6X   
�������$ Arrow��6w   �� 5      -   5        $ 	btnSearch��5      $��10q�6,   ��68   Z� ��6O   Z� .��5        $ Search=�6.   $��20��6<   $��20��6G   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgvData��5      $	��367��6(   
������ $
��Bold"�6N   
�������   CanUserAddRows .  	   
IsReadOnly	 . 
   Columns
 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Foto del Empleado��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6H      
IsReadOnly .    CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ imgPhotoEmployee��6(   $��80��6B   $��80��6M   ��6Y   �� *photo+5      5       5"      5#      5$      5%      