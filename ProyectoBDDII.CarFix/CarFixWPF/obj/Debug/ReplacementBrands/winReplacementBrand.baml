   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CarFixWPF.ReplacementBrandsCarFixWPF.ReplacementBrands  5   	   5    /CarFixWPF.ReplacementBrands.winReplacementBrand   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:CarFixWPF.ReplacementBrands     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   
   $��Regular"�5
   
   $��13(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � Title$ winReplacementBrand��5   	   $	��480��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>    � WindowStyle$
 None=�6c   $��0q�6v   .��5      � .+�5   
   �� ���#1c2c3c.+�5      � $��30��6   $	��Top=�6   
���   �.+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6o   $��0q�6�   ��6B   Z� ��6X   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   
�������$��30��6N   $��30��6Z   5      5      �� 5      $��Marcas de Repuestos��6   $��10q�63   $��Center=�6?   $��Center=�6Z   $��20(�6w   $
��Bold"�6�   ���#e16b34$��Paladins Condensed)�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��5q�62   $��Center=�6>   .+�5      �� $��Tipo de Repuesto:��6   ���#e16b34$��15(�6J   $��
ExtraBlack"�6X   �� 5      -   5         ��Name$ txtBrandName��5      $	��300��60   {�.  $��20 0 0 0q�6N   	 � Cursor$	 Arrow��6`   5      �� 5       $ 
Horizontal=�6   $��5q�62   $��Center=�6=   .+�5!      �� -   5        $ 	btnInsert��5!      $��5q�6,   $��95��67   $
	 Hand��6B   ���#44373c��6}   Z� .��5"        $ Upload=�6.   5#      �� 5$      -   5        $ 	btnUpdate��5$      $��5q�6,   $��95��67   ���#44373c��6o   Z� .��5%        $ ModeEdit=�6.   5&      �� 5'      -   5        $ 	btnDelete��5'      $��5q�6,   $��95��67   $
	 Hand��6B   ���#44373c��6}   Z� .��5(        $ Delete=�6.   5)      �� 5*      -   5        $ btnSave��5*      $��5q�6*   $��95��65   {�.  ���#44373c��6~   Z� .��5+        $ ContentSave=�6.   5,      �� 5-      -   5        $ 	btnCancel��5-      $��5q�6,   $��95��67   {�.  ���#44373c��6�   Z� .��5.        $ Cancel=�6.   5/      50      &   System.Windows.Controls.DataGrid  51      -	   5        
  Name$
 dgvData��51      $��5q�6(   $	��244��63      
IsReadOnly .    CanUserAddRows .  
������ ���#dddfe16�   �� 52      -
   5         ��Name$ lblInfo��52      
�������$��	ExtraBold"�68   $��15(�6O   $��5q�6]   $��41��6h   53      54      55      