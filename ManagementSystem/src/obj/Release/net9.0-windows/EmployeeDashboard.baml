   M S B A M L   `   `   `  ����   ManagementSystem2    ,Employee_Management_System.EmployeeDashboard   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Employee Dashboard��$	��650��$
��1350�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ 	CanResize=����#F5F5F5.���  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0�����#2C3E50$	��250��$��Stretch=�$��10q�.+��� $��Employee Dashboard��$��20(�$
��Bold"�
�������$��10,20,10,20q�$��Center=��� -   $��Message��$��5q�$��40�����#34495E
�������$��14(��� -   $��Mark Attendance��$��5q�$��40�����#34495E
�������$��14(��� -   $��View Attendance Logs��$��5q�$��40�����#34495E
�������$��14(��� -   $��Health Records��$��5q�$��40�����#34495E
�������$��14(��� -   $��
OHS Survey��$��5q�$��40�����#3498DB
�������$��14(��� -   $��Logout��$��5q�$��40�����#E74C3C
�������$��14(�� $��1��$��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#34495E$��2q� �� Padding$ 10q� �� CornerRadius$ 5�����#34495E$��0,0,0,10q�._���  �� Orientation$ 
Horizontal=�$��Center=�.+��� $#��Welcome to Employee Dashboard��$��28(�$
��Bold"�
�������$��Center=��� -   	 ��Name$	 lblUserName��$��20(�$��SemiBold"�
�������$��20,0,0,0q�$��Center=�$�� ���� -   $	 txtClock��$��28(�$
��Bold"�
�������$��Right=�$��30,0,0,0q�� $��1�� �� $��* ��� $	��300 �.+��� $��📝 To-Do List��$��16(�$��10q�$��10q�
����������#34495E$��2q�.���� .+��� -	   $��lstToDo��$	��200��$��5q����#ECF0F1���#BDC3C7$��1q��� $ 
Horizontal=�$��5q�.+��� -
   $��
txtNewTask��$	��200��$��5q�
 � ToolTip$
 Enter a task...�����#FFFFFF���#BDC3C7$��1q��� -   $��➕ Add��$��80�����#27AE60
�������$
��Bold"��� $ 
Horizontal=�$��5q�.+��� -   $��
❌ Remove��$	��100�����#E74C3C
�������$
��Bold"��� -   $��🗑 Clear All��$	��100�����#95A5A6
�������$
��Bold"��� $ Vertical=�$��5q�.+��� $ 
Horizontal=�$	��0,5q�.+��� $��	Due Date:��$��Center=�$	��5,0q�(  "System.Windows.Controls.DatePicker  -   $��
txtDueDate��$	��150��$��5q��� $ 
Horizontal=�$	��0,5q�.+��� $��	Priority:��$��Center=�$	��5,0q��� -   $��txtPriority��$	��150��$��5q�.@��� $	��Low���� $��Medium���� $
��High���� $��1��$��Right=�$	��Top=�$��10q�.+��� $��Attendance Status:��$��18(�$
��Bold"�$��0,0,0,10q�
���   � �� TextAlignment$ Center=��� $	��250��$��70��
������ ._��� .+��� -    ��Name$ lblClockInStatus��$�� ��$��16(�
���   �
������ $��Center=�$��Center=�$
��Bold"�$	��250���� -   $ lblClockOutStatus��$�� ��$��14(�
���   �
������ $��Center=�$��Center=�$
��Bold"�$	��400��$��50��$��5q�$	��250��$��50���� -   $��Clock In��$	��160��$��45��
������
���   �$��14(�$
��Bold"��� -   $��	Clock Out��$	��160��$��45��
�������
���   �$��14(�$
��Bold"�$��0,10,0,0q�