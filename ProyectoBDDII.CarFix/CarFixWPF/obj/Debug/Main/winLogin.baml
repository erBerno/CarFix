   M S B A M L   `   `   `  ����D  @CarFixWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CarFixWPF.MainCarFixWPF.Main  5   	       CarFixWPF.Main.winLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CarFixWPF.Main     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   
������ 
������  � Title$ winLogin��5   	   $	��700��6   $	��450��6'   $��Paladins Condensed)�5   	    � AllowsTransparency . .��5      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 15Q�6   ���	#FF1A2331$��0q�6J   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth4=�6U   .��5   
   �� .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6&   $��	0 20 20 0q�6B      PlacementMode$ BottomAndAlignRightEdges=�6U      	StaysOpen .  $��25��6�   
�������	   PopupContent.	 5      �� .+�5      �� 
 � ToolTip$&
  Comuniquese con un Administrador��6   $��0 8 0 0q�6H   $��Ayuda��6Y   �� 5      -   5         ��Name$ btnExit��5      $
 Salir de la Aplicacion��6.   $��Salir��6O   6_   5      5      �� 5      $��0,10,0,5q�6   $��/Imgs/logoCarFix.png��6&   $	��200��6D   6S   �� 5      $��0,25,0,5q�6   $��Center=�6*   $��28(�6G   $
��Bold"�6U   
�������$��
BIENVENIDO��6z   �� 5      $��17(�6   $��SemiBold"�6&   $��Center=�6<   
�������$!��Inicie sesion con su cuenta��6l   6�   �� 5      -   5         ��Name$ txtUsername��5   N   $��Arial)�6   
�������$��0,50,0,0q�6<   $	��300��6c   $��18(�6o   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ USUARIO��6}      
FontFamily$ Paladins Condensed)�6�   $��2q�6�   
������� !  MaterialDesignOutlinedTextBox#��[  6   � Cursor$ Arrow��6?  G� 5      -   5         G�Name$ txtPassword��5   R   $��Arial)�6   
�������$��0,20,0,0q�6@   $	��300��6g   $��18(�6s   $ Enter Password��6�   $��2q�6�   
�������$ Paladins Condensed)�6�    % !MaterialDesignOutlinedPasswordBox#��[ 6  $ Arrow��6N  �� 5      -   5        $ btnReset��5   (   $��0 20 0 0q�6   $ Depth0=�6Q   $��53��6�   $	��300��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��14(�6�   $!��¿OLVIDASTE TU CONTRASEÑA?��6�   $
 Hand��6�   ���#dcdee0
���   ���6:   Z� 61  �� 5      -   5        $ btnLogin��5   (   $��0,20,0,0q�6   $ Depth0=�6Q   $��53��6�   $	��300��6�   $ 10��6�   $��18(�6�   $��INICIAR SESION��6�   $
 Hand��6�   ���#e16b34
���   ���6:   Z� 6%  5       5!      5"      