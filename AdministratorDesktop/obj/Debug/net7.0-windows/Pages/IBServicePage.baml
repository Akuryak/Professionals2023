   M S B A M L   `   `   `  ����O  KAdministratorDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AdministratorDesktop.PagesAdministratorDesktop.Pages  5      .    (AdministratorDesktop.Pages.IBServicePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:AdministratorDesktop.Pages     5      -   5          N� Title$H  BСтражник - Управление безопасностью��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      �� 5      $��0.05* �6    � RowDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��auto �6   �� 5      �� 5      $��0.05* �6   .+�5   
   � $��1��6   $��1��6   $
��auto��6,   $	��Top=�6:    5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      .+�5      �� -   5         ��Name$ VerificationButton��5      $��Верификация��61   
����ح�6^   �� 5      -   5        $ AccessСredentialsButton��5      $#��Мандаты доступа��66   $��1��6P   6`   5      � 5    
   -   5         �Name$ AccessСredentialsGrid��5       $��2��6.   $��1��6;   $y�	Collapsed=�6K    5!      �� 5"      �� 5#      $
��auto �6#   .+�5%      &   System.Windows.Controls.DataGrid  -   5          Name$% AccessСredentialsUsersDataGrid��5%         AutoGenerateColumns$ False��6?   $��5��6[      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Фамилия��6)   
   
IsReadOnly$

 True��6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *	Surname+6V     5(      $	 Имя��6)   $

 True��6O    66   �� *Name+6O     5)      $	 Отчество��6)   $

 True��6Z    6;   �� *
Patronomic+6Z     5*      $	 Должность��6)   $

 True��6[    6<   �� *
StringPost+6[   4  .System.Windows.Controls.DataGridCheckBoxColumn  5+      $'	 !Добавление данных��6-     5,      $#	 Просмотр данных��6-     5-      $-	 'Формирование отчетов��6-   5/      � 50      $��1��6    51      �� 52      �� 53       55      �� 56      �� 57      �� 58      �� 59      $
��auto �6$   .+�5;      �� $'��!Добавление данных��6   $��Center=�65   �� 5<      -   5         ��Name$ CanUserAddInfoCheckBox��5<      $��1��6;   $��Center=�6K   �� 5>      $#��Просмотр данных��6   $��Center=�63   $��1��6N   �� 5?      -   5        $ CanUserCheckInfoCheckBox��5?      $��1��6=   $��Center=�6M   $��1��6h   �� 5A      $-��'Формирование отчетов��6   $��Center=�68   $��2��6S   �� 5B      -   5        $ CanUserAddReportCheckBox��5B      $��1��6=   $��Center=�6M   $��2��6h   �� 5D      -	   5        $ AcceptUserButton��5D      $��Применить��63   $��4��6G   $��2��6T   6h   5E      5F      � 5G   
   -
   5        $ VerificationGrid��5G      $��2��6)   $��1��66    5H      �� 5I      $
��auto �6#   �� 5J      $
��auto �6#   �� 5K      �� 5L      $
��auto �6#    5N      �� 5O      .+�5Q        -   5        $ UsersDataGrid��5Q      $ False��6.      
IsReadOnly$
 True��6J   $��1��6]   $��3��6j    5R        5S      $	 Фамилия��6)   $

 True��6V    6:   �� *	Surname+6V     5T      $	 Имя��6)   $

 True��6O    66   �� *Name+6O     5U      $	 Отчество��6)   $

 True��6Z    6;   �� *
Patronomic+6Z     5V      $	 Должность��6)   $

 True��6[    6<   �� *
StringPost+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5W      	 5X      �� 5Y      $%��Тип пользователя��6(      CellTemplate 5[      �� 5\      .R�5]   "   �� .@�5^   &   �� $/��)Администратор доступа��63   �� 5_   &   $��Служба ИБ��63   �� 5`   &   $%��Руководитель ПОП��63   �� 5a   &   $��Контролёр МО��63   5b   #   5c      5e        5f      $	 
Логин��6)    68   �� *Login+  5g      $	 Пароль��6)    69   �� *
Password+  5h      $#	 Секретное слово��6)    6B   �� *
SecretWord+  5i      $	 Одобрить��6-    6?   �� *IsVerificated+ �� Mode$ OneWay=�5k      � 5m      $��3��6   $��0��6#   $��3��60    5n      �� 5o      $
��auto �6'   �� 5p      $	��200��6'    5r      �� 5s      �� 5t      �� 5u      �� 5v      �� 5w      �� 5x      $
��auto �6$   .+�5z      �� $'��!Тип пользователя: ��6   �� 5{      -   5         ��Name$ UserType��5{      $��1��6-   �� 5}      $��Логин: ��6   $��1��6+   �� 5~      -   5         ��Name$ 	UserLogin��5~      $��1��6-   $��1��6=   �� 5�      $��Пароль: ��6   $��2��6,   �� 5�      -   5        $ UserPassword��5�      $��1��60   $��2��6@   �� 5�      $%��Секретное слово: ��6   $��3��65   �� 5�      -   5        $ UserSecretWord��5�      $��1��62   $��3��6B   �� 5�      $��Одобрить��6   $��4��6,   �� 5�      -   5        $ VerificateUserCheckBox��5�      $��4��6;   $��1��6H   $��Center=�6X   �� 5�      -   5        $ AcceptButton��5�      $��Одобрить��6/   $��5��6B   $��2��6O   6c   5�      5�      5�      5�      