   M S B A M L   `   `   `  ����  ManagementSystem+    %Employee_Management_System.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Employee Management System��5   	   $	��750��6,   $
��1300��69    � WindowStartupLocation$ CenterScreen=�6F   ���#555555 � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value��%'  '��       '�� �    �� 5   
   " ��6   .�5      ��  � �� �#B6B6B46+   �� 5	       � ��
 �����6+   �� 5
       � ��$ 35��6'   �� 5       � ��$	 485��6&   �� 5       � ��$ 5q�6(   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��5   !   $ 10��5   !   
�������$��1q�5   !   ._�5      �� $	 PART_ContentHost��6+   #��z��5   +   $��Center=�5   +   5      5      5      
 5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#A0A0A063   5       5"      �� 5%   
   " ��6   .�5&      ��  � ��
 � � �6+   �� 5'       � ��
 �����6+   �� 5(       � ��$ 40��6'   �� 5)       � ��$	 150��6&   �� 5*       � ��$ 5q�6(   �� 5+       � ��$ 0q�60   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� $ border��6!   #��z��50   !   $ 10��51   !   
�������$��1q�53   !   ._�54      �� $��Center=�6/   $��Center=�55   /   56      57      59      
 5:      P� 5;       �@J�IsMouseOver$
 True��61   . �5<      ��  � �� �#2E8B5763   �� 5=       �@�Cursor$
 Hand��6/   5>      5@      5A      .��5C      �  � RowDefinitions 5D   
   �� 5E      $
��Auto �6   �� 5F      $��* �6   .+�5J   
   �� ���#9A7E6F �� Orientation$ 
Horizontal=�6*   $��70��6C   .+�5K      �� ���#A5BFCC$	��300��6*   $��50��66   $��
20,10,0,10q�6B   $ 10��6V   ._�5L      �� $��Admin Panel��6   $��Center=�6/   $��	60,0,60,0q�6J   $��26(�6]   $
��Bold"�6k   
���   �$��Times New Roman)�6�   5M      �� 5N      -   5        
���  ��$��55��5O      $��45��6    $��	890,5,0,5q�6,   $��Right=�6?   .��5P      �� $/��)pack://siteoforigin:,,,/Assets/logout.png��6   $��30��6K   $��30��6V   5Q      5R      � 5U   
   $��1��6   $��20q�6    � ColumnDefinitions 5V      �� 5W      $��2* �6#   �� 5X      $��3* �6#   .+�5\      �� $��0��6   $	��Top=�6)   $��0,0,0,10q�6A   .+�5]      �� $-��'pack://siteoforigin:,,,/Assets/cred.png��6   $	��200��6I   $	��200��6U   $��Center=�6b   �� 5_      -   5         ��Name$ EmployeeIdTextBox��5_      $��Enter Employee ID��65   $��18(�6N   $��
ExtraLight"�6\   
���   �$��45��5`   h   $	��470��6t   $��5q�6�   �� 5a      -   5        $ NameTextBox��5a      $��
Enter Name��6/   $��18(�6A   $��
ExtraLight"�6O   
���   �$��45��5b   \   $	��470��6h   $��5q�6t   �� 5c      -   5        $ EmailTextBox��5c      $��Enter Email��60   $��18(�6C   $��
ExtraLight"�6Q   
���   �$��45��5d   ^   $	��470��6j   $��2q�6v   �� 5e      -   5        $ SalaryTextBox��5e      $��Enter Salary��61   $��18(�6E   $��
ExtraLight"�6S   
���   �$��45��5f   `   $	��470��6l   $��5q�6x   �� 5g      -   5        $ DesignationTextBox��5g      $��Enter Designation��66   $��18(�6O   $��
ExtraLight"�6]   
���   �$��45��5h   j   $	��470��6v   $��5q�6�   �� 5i      -   5        $��Add Employee��5i      $��5, 20, 0, 0q�6P   $��50��6e   $	��200��6q   $��18(�6}   $��Normal"�6�   
���   ����#D5C7A36�   5j      �� 5m      $��1��6   $	��Top=�6)   .+�5n      �� -   5         ��Name$ EmployeeListView��5n      $	��520��6W   ��65   �� *	Employees+ �� View 5o      �� 5p      .P�5q      �� $��ID��6-    �� Width$ 50��6]    �� DisplayMemberBinding 69   �� *Id+6]   �� 5r      $��Employee ID��6-   $	 100��6n    6B   �� *
EmployeeId+6n   �� 5s      $
��Name��6-   $	 150��6a    6;   �� *Name+6a   �� 5t      $��Email��6-   $	 205��6c    6<   �� *Email+6c   �� 5u      $��Salary��6-   $	 100��6e    6=   �� *Salary+6e   �� 5v      $��Designation��6-   $	 150��6o    6B   �� *Designation+6o   5w      5y      �� 5z      $ 
Horizontal=�6   $��Center=�66   .+�5{      �� -	   5        $
��Edit��5{      ���#D5C7A3$��50��6Z   $	��200��6f   
���   �$��20(�5|   0   $��Normal"�6>   $��50, 20, 0, 0q�6R   �� 5}      $��20��6   �� 5~      -
   5        $��Delete��5~      ���#D5C7A3$��0, 20, 50, 0q�6^   $��50��6t   $	��200��6�   $��20(�6�   $��Normal"�6�   
���   �6�   5      5�      5�      5�      5�      