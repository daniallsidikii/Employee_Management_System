   M S B A M L   `   `   `  ����  ManagementSystem+    %Employee_Management_System.AdminPanel   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc7wpfAnimatedGif"http://wpfanimatedgif.codeplex.com  5   	     � Title$  Admin Panel��5   	   $	��750��6   $
��1300��6*    � WindowStartupLocation$ CenterScreen=�5   	   ���#efebe6
������� � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ 	CanResize=�6*    � 	Resources 5
         ModernButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color	   
BlurRadius
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property P� Value��%`  &	        �� 5   
   " ��6*   .�5      ��  � ��$ Segoe UI)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 20q�6'   �� 5       � ��$ 10q�6(   �� 5       � ��
 �����6+   �� 5       � �� �#4CA1AF6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ Black��6'   $	 10Q�65   $
 2Q�6E   5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 12��5    !   # z��5!   !   ._�5"      �� $��Center=�6/   $��Center=�6L   5#      5$      5&       5'      P� 5(       �@J�IsMouseOver$
 True��61   . �5)      ��  � �� �#646f7763   5*      5,      5-      .��5/      � .+�51   
   �� $	��120��6   $	��Top=�6   $ 	0,0,15,15��66   ��52      �� 53       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,0&�67   .��54      �  � Color$ #2C3E50��6#    � Offset$ 0Q�63   � 55      $ #4CA1AF��6#   $ 1Q�63   56      ._�59      ]� $��Center=�6   $��Center=�65   .+�5:      �� $��Admin Dashboard��6   $��42(�5;      $
��Bold"�5<      $��Segoe UI)�5=      
�������$��Center=�5?      $
��10,0q�5@      �� 5A      -   5         ��Name$ lblAdmin��5A      $��18(�5B      $��SemiBold"�5C      
�������$��20,0,0,0q�5E      $��Center=�5F      $��(Controller)��5G      �� 5H      -   5        
������ $��0q�5H   G   $��Right=�6[   $��	500,0,0,0q�6w   $��1��6�   .��5I      ��  �� Orientation$ 
Horizontal=�6!   .+�5J      �� $/��)pack://siteoforigin:,,,/Assets/logout.png��6    $��25��6S   $��25��6^   $��0,0,5,0q�6j   �� 5K      $��Logout��6$   
�������$��16(�6E   $��Center=�6S   5L      5M      5N      5O      � 5R   
   $��40,200,140,40q�6   $	��420��5S      $��Right=�5T      $	��Top=�5U       � Orientation$ 
Horizontal=�5V       � 	ItemWidth$	 200��5W       � 
ItemHeight$	 120��5X      .+�5Z      �� -   5        $��button1��5Z      $��16(�5[      $��Manage Employees��5\      #��[  5^      �� 5`      -   5        $��button3��5`      $��16(�5a      $��Check Attendance��5b      #��[  5d      �� 5f      -   5        $��button4��5f      $��16(�5g      $��Health Records��5h      #��[  5j      �� 5l      -   5        $��button5��5l      $��16(�5m      $��
Send Email��5n      #��[  5p      �� 5r      -   5        $��button2��5r      $��16(�5s      $��	Open Chat��5t      #��[  5v      �� 5x      -   5        $��Survey Report��5x      $��16(�5z      #��[  5{      5|      �� 5}   
   $ 
Horizontal=�6   .+�5~      �� $2��,pack://siteoforigin:,,,/Assets/AdminLogo.png��6   $	��300��6N   $	��300��6Z   $��	250,0,5,0q�6g   5      5�      5�      