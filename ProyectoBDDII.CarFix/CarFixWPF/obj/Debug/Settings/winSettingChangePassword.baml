   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarFixWPF.SettingsCarFixWPF.Settings  5   	   1    +CarFixWPF.Settings.winSettingChangePassword   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   ,local clr-namespace:CarFixWPF.Settings  5   	     � Title$  winSettingChangePassword��5	   	   $	��500��6*   $	��800��67    � WindowStartupLocation$ CenterScreen=�6C    � WindowStyle$
 None=�6h   .��5
      � .+�5   
   �� ���#1c2c3c.+�5      � $��30��6   $	��Top=�6   
���   �.+�5      �� -   5         ��Name$ btnClose��5      $��30��6+   $��30��66   $��Right=�6o   $��0q�6�    � Cursor$
 Hand��6�   ��6B   Z� ��6X   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   
�������$��30��6N   $��30��6Z   5      5      �� 5      $��20q�6   .+�5      �� $��CAMBIAR SU CONTRASEÑA��6   $��30q�69   $��Paladins Condensed)�6E   $��30(�6e   $	��Top=�6s   $��Center=�6�   $ Arrow��6�   ���#e16b346�   �� 5      $
 Hand��6   .+�5      �� $'��!Introduzca su Contraseña ACTUAL:��6    $��Paladins Condensed)�6H   $
��Bold"�6h   $��Center=�6z   $��20q�6�   G� 5      -   5         G�Name$ txtOldPassword��5   "   
�������$��Center=�6M   $ Arrow��6q   �� 5      -   5         ��Name$ txtNew��5       $&�� Introduzca su Nueva Contraseña:��60   $��Paladins Condensed)�6W   $
��Bold"�6w   $��Center=�6�   $��20q�6�   G� 5      -   5        $ txtNewPassword��5   "   
�������$��Center=�6M   $ Arrow��6q   �� 5      -   5        $ 
txtConfirm��5       $$��Confirme su Nueva Contraseña:��64   $��Paladins Condensed)�6Y   $
��Bold"�6y   $��Center=�6�   $��20q�6�   G� 5      -   5        $ txtConfirmPassword��5   "   
�������$��Center=�6Q   $ Arrow��6u   5      �� 5      -   5        $ btnChangePassword��5      $��REESTABLECER CONTRASEÑA��64   $��50 60 50 50q�6V   ���#dcdee0
���   �$��Paladins Condensed)�6�   $
 Hand��6�   ��6k   Z�  � Triggers 5      :� 5      	 :� RoutedEvent$	 Button.MouseEnter��6'   .[�5      �� .��5   "   �� .��5    &   �� 	
 �� To$
 #e16b34X�65    �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�5!   %    g� FillBehavior$ HoldEnd=�5"   %   5#   #   5$      5%      :� 5&      $	 Button.MouseLeave��6'   .[�5'      �� .��5(   "   �� .��5)   &   �� $>
 8#dcdee0                                                 X�65   $1 +(Button.Background).(SolidColorBrush.Color)�5+   %    g� Duration$ 0:0:0:0D�5,   %   5-   #   5.      5/      51      52      53      54      55      