   M S B A M L   `   `   `  ����I  ETestApiDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TestApiDesktop.PagesTestApiDesktop.Pages  5      +    %TestApiDesktop.Pages.AutorizationPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TestApiDesktop.Pages     5      $	��350��5	      $	��500��6     N� Title$  AutorizationPage��5
       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.1* �6   .+�5   
   � $��1��6   $��1��6   ���	#FFEFEFEF 5      �� 5      $
��auto �6#   �� 5       5      �� 5      �� 5      �� 5      �� 5       �� 5!      .+�5#      �� $��2��6   
��� ���$��0,0,0,10q�6=    �� CornerRadius$ 30��6O   ._�5$      �� $��Авторизация��6   $��Center=�6/   $
��Bold"�6L   5%      �� 5'      $��Логин: ��6   $��1��6'   �� 5(      -   5         ��Name$ LoginTextBox��5(   f      TextBoxTemplate1#���   6   $��Center=�6D    �� 	MaxLength$	 255��6|   $��1��6�   $��1��6�   �� 5*      $��Пароль: ��6   $��2��6(   �� 5+      -   5        $ PasswordTextBox��5+   f   #���   6   $��Center=�6D   $ 15��6   $��2��6�   $��1��6�   6�   �� 5.      -   5         ��Name$ RegisterButton��5.   B     ButtonTemplate1#���  6   $��Регистрация��6Z   $��3��6p   $��2��6}   6�   �� 5/      -   5        $ LoginButton��5/   B   #���  6   $��
Войти��6W   $��4��6g   $��2��6t   6�   50      51      52      