   M S B A M L   `   `   `  ����I  ETestApiDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TestApiDesktop.PagesTestApiDesktop.Pages  5      '    !TestApiDesktop.Pages.RegisterPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TestApiDesktop.Pages     5      $	��350��5	      $	��400��6     N� Title$  RegisterPage��5
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
��� ���$��0,0,0,10q�6=    �� CornerRadius$ 30��6O   ._�5$      �� $��Регистрация��6   $��Center=�6/   $
��Bold"�6L   5%      �� 5'      $��Email: ��6   $��1��6'   �� 5(      -   5         ��Name$ EmailTextBox��5(   D      TextBoxTemplate1#���   6   $��Center=�6Z    �� 	MaxLength$	 255��6|   $��1��6�   $��1��6�   6�   �� 5*      $��Пароль: ��6   $��2��6(   �� 5+      -   5        $ PasswordTextBox��5+   D   #���   6   $��Center=�6]   $ 15��6�   $��2��6�   $��1��6�   �� 5-      -   5         ��Name$ AcceptButton��5-   B     ButtonTemplate1#���  6   $*��$Зарегистрироваться��6X   $��3��6u   $��2��6�   6�   �� 5.      -   5        $ ReturnBackButton��5.   B   #���  6   $��Вернуться��6\   
���  ��$��4��6�   $��2��6�   6�   5/      50      51      