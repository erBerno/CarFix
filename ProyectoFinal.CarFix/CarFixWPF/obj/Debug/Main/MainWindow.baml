   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarFixWPF	CarFixWPF  5   	       CarFixWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CarFixWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1080��6)    � WindowState$ 	Maximized=�66    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6d    � WindowStyle$
 None=�6�    � 	Resources 5        menuCollapse �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  menuOpen��%�  &	       &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Height)�6,   $	 gridMenu��6b   .\�5        $
 0��6'   $ 70Q�63     5      $
 0:0:0:1��6'   $ 0Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Height)�6,   $	 gridMenu��6b   .\�5        $
 0��6'   $ 0Q�63     5      $
 0:0:0:1��6'   $ 70Q�69   5      5      5       � Triggers 5!      :� 5"   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ btnCollapseMenu��66   .[�5#      �� #��[ 6   5$      :� 5&   
   $ ButtonBase.Click��6   $ btnExpandMenu��66   .[�5'      �� #��[ 6   5(      .��5+      �� ���#1C2C3C.+�5,   
   � $	��100��6   .+�5-      �� $��CarFix��6   $��50(�6&   $��Paladins Condensed)�64   $��Center=�6T   $��20 0 0 0q�6o   ���#e16b346�   �� 5.       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��20 0 0 0q�6N   .+�5/      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6*      	StaysOpen .     ToggleContent 50      '  !MaterialDesignThemes.Wpf.PackIcon  51         Kind$ Settings=�62   ���#e16b34$��25��6�   $��25��6�   ��6B   Z� ��6X   Z� 6�      PopupContent. 53      �� .+�54      �� $��	ACERCA DE��6!   �� 55      $��AYUDA��6!   �� 56      $��CONFIGURACION��6!   �� 57      �� 58      $��	MI CUENTA��6!   59      5:      �� 5;      -   5         ��Name$ btnExit��5;      $��Center=�6W   ��6*   Z� ��6@   Z� .��5<        $ Power=�6.   ���#e16b34$��25��6P   $��25��6[   5=      5>      5?      � 5@   
   $��70��6   .+�5A      � $
��Left=�6   $��	10 0 0 30q�6.   .+�5B      �� -   5        $ btnExpandMenu��5B      $
��Left=�60    � Cursor$
 Hand��6x   $y�	Collapsed=�6�   ��6K   Z� ��6a   Z� .��5C        $ ArrowDownDropCircle=�6.   5D      �� 5E      -   5        $ btnCollapseMenu��5E      $
��Left=�62   $
 Hand��6z   ��6M   Z� ��6c   Z� .��5F        $ ArrowUpDropCircle=�6.   5G      5H      � 5I      -   5         �Name$ gridMenu��5I      .+�5J      � $��30��6   $	��Top=�6#   .+�5K        $
 Home=�6.   ���#dddfe1$��30��6O   $��30��6Z   $��	310,0,0,0q�6f   $��Center=�6y     5L      $ 	CarWrench=�6.   ���#dddfe1$��30��6T   $��30��6_   $��	458,0,0,0q�6k   $��Center=�6~   5M      � 5N      $��50��6   $��Bottom=�6#   .+�5O      �� $ 
Horizontal=�6!   $
��Left=�6:   $��Center=�6U   $��	250,0,0,0q�6p   $��2��6�   .+�5P      �� -   5        
 J� Uid$ 0��5P   !   $	��150��6)   $��INICIO��65   $��30��6F   ���#dddfe1$
 Hand��6�   ��6R   Z� ��6h   Z� 6�   �� 5Q      -   5        $ 1��5Q   !   $	��150��6)   $��	REPUESTOS��65   $��30��6I   ���#dddfe1$
 Hand��6�   ��6U   Z� ��6k   Z� 6�   5R      5S      5T      5U      � 5V   
   -   5        $ gridMain��5V      
������ 5X      5Y      5Z      