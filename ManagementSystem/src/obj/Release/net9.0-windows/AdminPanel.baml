   M S B A M L   `   `   `  ����   ManagementSystem+    %Employee_Management_System.AdminPanel   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc7wpfAnimatedGif"http://wpfanimatedgif.codeplex.com    � Title$  Admin Panel��$	��750��$
��1300�� � WindowStartupLocation$ CenterScreen=����#121212
������� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ 	CanResize=� � 	Resources    ModernButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color	   
BlurRadius
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property P� Value��%�  &	        �� " ��.���  � ��$ Segoe UI)���  � ��$ 18(���  � ��$ SemiBold"���  � ��$ 20q���  � ��$ 10q���  � ��
 �������  � �� �#4CA1AF��  � ��
 ���� ��  � ��$ 0q���  �@�Cursor$
 Hand����  �@J�Effect   $ Black��$	 10Q�$
 2Q���  � �� �� " ��.R��� #��z��$ 12��# z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#646f77.��� .+��� $	��120��$	��Top=�$ 	0,0,15,15������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #2C3E50�� � Offset$ 0Q�� $ #4CA1AF��$ 1Q�._�]� $��Center=�$��Center=�.+��� $��Admin Dashboard��$��42(�$
��Bold"�$��Segoe UI)�
�������$��Center=�$
��10,0q��� -    ��Name$ lblAdmin��$��18(�$��SemiBold"�
�������$��20,0,0,0q�$��Center=�$��(Controller)���� -   
������ $��0q�$��Right=�$��	500,0,0,0q�$��1��.����  �� Orientation$ 
Horizontal=�.+��� $/��)pack://siteoforigin:,,,/Assets/logout.png��$��25��$��25��$��0,0,5,0q��� $��Logout��
�������$��16(�$��Center=�� $��60,200,100,40q�$	��420��$��Right=�$	��Top=� � Orientation$ 
Horizontal=� � 	ItemWidth$	 200�� � 
ItemHeight$	 120��.+��� -   $��button1��$��16(�$��Manage Employees��#��[  �� -   $��button3��$��16(�$��Check Attendance��#��[  �� -   $��button4��$��16(�$��Health Records��#��[  �� -   $��button5��$��16(�$��
Send Email��#��[  �� -   $��button2��$��16(�$��	Open Chat��#��[  � $	��500��$	��475��$��0,150,500,20q�$��Center=�.+���  �� RadiusX$ 30�� �� RadiusY$ 30��$	��500��$	��475����!�  j� Stretch$
 Fill=� !� Visual (� $	��500��$	��475��.���� -    ��Name$ myGif��$	��500��$	��475��"  WpfAnimatedGif.ImageBehavior   AnimatedSource$4 .pack://siteoforigin:,,,/Assets/AdminPannel.gif��