   M S B A M L   `   `   `  ����   ManagementSystem0    *Employee_Management_System.SendEmailWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
Send Email��$	��750��$	��700�� � Left$	 118��
 � Top$ 33�� � WindowStartupLocation$ Manual=����#2C3E50 � 	Resources  �� 
TargetType   PrimaryButton �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius �� Triggers P� Property P� Value��%�  &	        �� " ��.���  � �� �#4CA1AF��  � ��
 �������  � ��$ 16(���  � ��$
 Bold"���  � ��$ 48����  � ��$	 170����  � ��$ 6q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $	 border��#��z��$
 14��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#5FB2C9.��� $��30q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��Center=�$��0,0,0,30q�$��Center=�.+��� $2��,pack://siteoforigin:,,,/Assets/EmailLogo.png��$��80��$��80��$��0,0,10,0q��� $��Email��$��28(�$
��Bold"�
�������$��Center=��� $��1��$��0,0,0,20q�.+��� $	��To:��$
��Bold"�$��16(�
�������$��0,0,0,5q��� ���#D3D3D3$��1q�$
 8��
�������._��  � ColumnDefinitions �� $��* ��� $
��Auto �.+��� -    ��Name$ 	ToTextBox��$��0��$��10q�$��14(�$��0q�
������ $��Center=��� $��
@gmail.com��$��1��$��5,0,10,0q�$��Center=�$��14(�
��������� $��2��$��0,0,0,20q�.+��� $��Subject:��$
��Bold"�$��16(�
�������$��0,0,0,5q��� ���#D3D3D3$��1q�$
 8��
�������._��� -   $ SubjectTextBox��$��10q�$��14(�$��0q�
������ $��Center=�$��40���� $��3��$��0,0,0,20q�.+��� $��Compose Email��$
��Bold"�$��16(�
�������$��0,0,0,5q��� ���#D3D3D3$��1q�$
 8��
�������._��� -   $ BodyTextBox�� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��10q�$��14(�$��0q�
������ $	��200���� $��4��$ 
Horizontal=�$��Right=�$��0,0,0,50q�.+��� -   $��
Send Email��#��[  