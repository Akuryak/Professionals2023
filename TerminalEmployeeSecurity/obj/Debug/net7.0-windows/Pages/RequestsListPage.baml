   M S B A M L   `   `   `  ����S  OTerminalEmployeeSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TerminalEmployeeSecurity.PagesTerminalEmployeeSecurity.Pages  5      5    /TerminalEmployeeSecurity.Pages.RequestsListPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TerminalEmployeeSecurity.Pages     5      -   5          N� Title$  RequestsListPage��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $��0.01* �6   �� 5      �� 5      $��0.01* �6    � RowDefinitions 5   
   �� 5      $��0.01* �6   �� 5      �� 5      $��0.01* �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $
��auto �6    �� 5       5      �� 5      $
��auto �6#   �� 5      �� 5      $
��auto �6#   .+�5       �� $��Поиск: ��6   �� 5!      -   5         ��Name$ SearchTextBox��5!      $��1��6-   6=   �� 5"      -   5         ��Name$ 
ExitButton��5"      $��
Выйти��6)   
���  ��$��2��6J   6Z   &   System.Windows.Controls.DataGrid  5#      -   5          Name$ RequestsDataGrid��5#         AutoGenerateColumns$ False��61   $��1��6M   $��3��6Z      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Код��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   ��  �� Path$ Id�  5&      $	 Тип��6)   
 66   �� $
 Type�  5'      $2	 ,Время заполнения заявки��6)   
 6J   �� $ Datetime�4  .System.Windows.Controls.DataGridCheckBoxColumn  5(      $	 Статус��6-   
 6=   �� $ CheckStatus�4  .System.Windows.Controls.DataGridTemplateColumn  5)         CellTemplate 5*      �� 5+      .R�5,   "   �� $ OpenRequestButton��6)   -   5        $��Открыть��5,   D   6V   5-      5/      51      52      53      54      