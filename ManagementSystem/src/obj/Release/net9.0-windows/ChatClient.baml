   M S B A M L   `   `   `  ����   ManagementSystem+    %Employee_Management_System.ChatClient   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  	Chat Area�����#2C3E50���#FFFFFF$	��750��$	��700�� � Left$	 118��
 � Top$ 33�� � WindowStartupLocation$ Manual=� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType   PrimaryButton �� Property	 �� Value
 �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value  SentMessageStyle  ReceivedMessageStyle��%�  &	        &	 j    &	      �� " ��.���  � ��	 �#4CA1AF��  � ��
	 �������  � ��$	 14(���  � ��$
	 Bold"���  � ��$	 34����  � ��$	 80����  � ��$	 0q���  �@�Cursor$
	 Hand����  � ��	 �� "
 ��.R��� #��z��$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��	 �#5FB2C9�� " ��.���  � ��$	 Right=���  � ��$		 0,5q���  � ��	 �� "
 ��.R��� $ 10�����#4CA1AF$��5q�$��Right=�._��� $
��10,5q�$��Right=�$
��True���� " ��.���  � ��$
	 Left=���  � ��$		 0,5q���  � ��	 �� "
 ��.R��� $ 10�����#557174$��5q�$
��Left=�._��� $
��10,5q�$
��Left=�$
��True��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$��60��$ 10��$��0,0,0,20q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #2C3E50�� � Offset$ 0Q�� $ #4CA1AF��$ 1Q�._��� $��	Chat Room��
�������$��24(�$
��Bold"�$��Center=�$��Center=� �� Padding$ 10q��� $��1�� �� Orientation$ 
Horizontal=�$��Right=�$��0,0,0,10q�.+��� $��	Username:�����#D3D3D3$��Center=�$��0,0,5,0q��� -    ��Name$ txtUsername��$	��120��$��30��$��0,0,10,0q����#557174
�������$��0q�$��5q��� -   $��Connect��#��[  �� -    ��Name$ lstMessages��$��2�����#1E1E1E
���   �$��0q�$��Disabled=����� " ��.���  � ��$	 Stretch=���  � ��$		 0,5q��� $��3��$ 
Horizontal=�$
��0,10q�.+��� $	��To:�����#D3D3D3$��Center=�$��0,0,5,0q��� -   $ 	txtTarget��$	��150��$��28��$��0,0,10,0q����#557174
�������$��0q�$��5q��� -    ��Name$ comboBoxUsers��$	��120��
���   ����#557174$��0q�.@��� $��Everyone���� $��4��$ 
Horizontal=�$
��0,10q�.+��� -   $ 
txtMessage��$	��470��$��32��$��0,0,10,0q����#557174
�������$��0q�$��5q��� -   $��40��$��40�� � ToolTip$ 	Send File��$��5q����� "
 ��.R��� ���#2C3E50$ 8��._��� $1��+pack://siteoforigin:,,,/Assets/FileLogo.png��$��40��$��30��$��Center=�$��Center=��� -	   $��40��$��40��$
 Send��$��5q����� "
 ��.R��� ���#2C3E50$ 8��._��� $1��+pack://siteoforigin:,,,/Assets/SendLogo.png��$��40��$��30��$��Center=�$��Center=�