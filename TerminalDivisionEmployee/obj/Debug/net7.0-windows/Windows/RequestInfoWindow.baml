   M S B A M L   `   `   `  ����S  OTerminalDivisionEmployee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:TerminalDivisionEmployee.Windows TerminalDivisionEmployee.Windows  5   	   8    2TerminalDivisionEmployee.Windows.RequestInfoWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:TerminalDivisionEmployee.Windows     5   	   -   5          � Title$  Заявка��5   	   $	��150��6   $	��150��6(   $	��700��65   $	��700��6D   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ VisitorLeaveDatePicker��5      $��3��65   �� 5   
   -   5         ��Name$ AcceptVisitorButton��5      
��� � �$��1��6A   ��5      �� 5      $=��7Разрешить доступ на територию��6   $
��Wrap=�6A   5      �� 5   
   -   5        $ AcceptVisitorLeaveButton��5      
���  ��$��1��6D   $��1��6Q   ��5      �� 5      $-��'Зафиксировать убытие��6   $
��Wrap=�68   5      �� 5   
   -   5        $ BlockVisitorButton��5      $��1��6-   $��2��6:   ��5      �� 5       $1��+Занести в черный список��6   $
��Wrap=�6;   5"      5#      5$      