   M S B A M L   `   `   `  ����   ManagementSystem+    %Employee_Management_System.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$   Employee Management System��$	��750��$
��1300�� � WindowStartupLocation$ CenterScreen=����#121212 � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value��%(  '��       '�� o    �� " ��.���  � ��
 �������  � �� �#333��  � ��$ 16(���  � ��$ 40����  � ��$	 485����  � ��$
 10,5q���  � ��$ 0q���  � �� �� " ��.R��� $ border��#��z��$ 12�����#ccc$��1q�._��� $	 PART_ContentHost��#��z��
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#f9f9f9�� " ��.���  � �� �#4CA1AF��  � ��
 �������  � ��$ 16(���  � ��$
 Bold"���  � ��$ 48����  � ��$	 170����  � ��$ 6q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��#��z��$ 14�����#4CA1AF$��1q�._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#5FB2C9.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $	��120��$	��Top=�$ 	0,0,15,15������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #2C3E50�� � Offset$ 0Q�� $ #4CA1AF��$ 1Q�._��  � ColumnDefinitions �� $��* ��� $
��Auto �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�$��0��.+��� $��Employee Management��$��42(�$
��Bold"�$��Segoe UI)�
�������$��Center=��� -    ��Name$ lblAdmin��$��18(�$��SemiBold"����#D3D3D3$��20,0,0,0q�$��Center=�$��(Controller)��� $��1��$��20q� �� $��2* ��� $��3* �.+��� $��0��$	��Top=�$��0,0,20,0q�.+��� $-��'pack://siteoforigin:,,,/Assets/cred.png��$	��130��$	��180��$��Center=��� -    ��Name$ EmployeeIdTextBox��$��Enter Employee ID��$��0,0,0,10q�$	��350���� -   $ NameTextBox��$��
Enter Name��$��0,0,0,10q�$	��350���� -   $ EmailTextBox��$��Enter Email��$��0,0,0,10q�$	��350���� -   $ SalaryTextBox��$��Enter Salary��$��0,0,0,10q�$	��350���� -   $ DesignationTextBox��$��Enter Designation��$��0,0,0,20q�$	��350���� -   $��Add Employee�����#4CA1AF
��������� $��1��.+��� 
�������$ 10�� �� Padding$ 10q����#DDD$��1q�$��0,0,0,10q�._��� -    ��Name$ EmployeeListView��$	��430������ *	Employees+ ��%�  '��       '�� p     �� " ��.���  � �� �#ECEFF1��  � ��$
 Bold"���  � ��$ 15(���  � �� �#333�� " ��.���  � ��$ 14(���  � �� �#FAFAFA��  � �� �#111��  � ��$ 2q�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �#c8d0dcP�  �@��
IsSelected$
 True��. ���  � �� �#adb9cb��  � ��$
 Bold"� �� View �� .P��� $��ID�� �� Width$ 50�� �� DisplayMemberBinding �� *Id+�� $��Emp ID��$ 90�� �� *
EmployeeId+�� $
��Name��$	 160�� �� *Name+�� $��Email��$	 195�� �� *Email+�� $��Salary��$	 110�� �� *Salary+�� $��Designation��$	 180�� �� *Designation+�� $ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� -	   $
��Edit�����#4CA1AF$��0,0,10,0q��� -
   $��Delete�����#EF5350