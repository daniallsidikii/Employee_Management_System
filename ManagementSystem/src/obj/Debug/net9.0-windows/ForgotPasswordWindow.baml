   M S B A M L   `   `   `  ����  ManagementSystem5    /Employee_Management_System.ForgotPasswordWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Account Recovery��5   	   $	��650��6"   $	��575��6/    � Left$	 800��6;   
 � Top$ 82��6F    � WindowStartupLocation$ Manual=�5   	    � 
ResizeMode$ NoResize=�6(    � WindowStyle$
 None=�6>   ���#efebe6$��Segoe UI)�5      .��5      �� 
������� �� Padding$ 30q�6    $��30q�6-    �� CornerRadius$ 12��69   ���#CCCCCC$��1q�6a   ._�5	   
   �� $��Center=�6   $��Center=�60   $
��Auto��6M   .+�5      �� $5��/pack://siteoforigin:,,,/Assets/RecoveryLogo.png��6   $	��110��5      $	��110��6    $��Center=�5      $��0,0,0,25q�61   �� 5      $��Account Recovery��6   $��26(�5      $
��Bold"�5      ���#2C3E50$��Center=�5      $��0,0,0,15q�65   �� 5      $)��#Enter your registered email address��6   $��14(�5      ���#646f77$��0,0,0,8q�5      �� 5      -   5         ��Name$ txtEmail��5      $	��300��5      $��36��6"   $��6q�5       $��14(�5!      ���#4CA1AF$��1q�5#      
�������
���   �$��Center=�5&      �� 5)      -   5        	 ��Name$	 	btnSubmit��5)      $��Find Account��5*      $	��300��5+      $��38��6!   $��0,18,0,0q�5,      ���#4CA1AF
�������$
��Bold"�5/      $��14(�50      
 � Cursor$

 Hand��51      $��0q�52      ��54      �� 55       �� 
TargetType" ��6    �� Triggers 56      P� 57       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �58   "   ��  �� Property � �� �� Value �#646f776?   59      5;      5=      �� 5@      -   5        $	 btnBackToLogin��5@      $��Back to Login��5A      $	��300��5B      $��38��6!   $��0,10,0,0q�5C      ���#2C3E50
�������$
��Bold"�5F      $��14(�5G      $

 Hand��5H      $��0q�5I      5J      �� 5M      -   5         ��Name$ 
lblMessage��5M      $�� ��5N      $��13(�5O      
���  ��$
��Wrap=�5Q      $��0,16,0,0q�5R      $y�	Collapsed=�5S       �� TextAlignment$ Center=�5T      �� 5W      -   5         ��Name$ resultPanel��5W      $y�	Collapsed=�5X      $��0,20,0,0q�5Y      ���#F8F9FA$ 16q�5[      $ 6��5\      ���#CCCCCC$��1q�5^      ._�5_      �� .+�5`      �� $��Account Details:��6    $
��Bold"�5a       $��15(�5b       ���#2C3E50$��0,0,0,10q�5d       �� 5e      �� 6!   $�Employee ID: ��6%   �� 6<   -   5         ��Name$ txtEmployeeId��5e   @   
���   �6W   6m   �� 5f      �� 6!   $�Full Name: ��6%   �� 6:   -   5        $ txtEmployeeName��5f   >   
���   �6W   6m   �� 5g      �� 6!   $�Email: ��6%   �� 66   -   5        $ txtEmployeeEmail��5g   :   
���   �6T   6j   5h      5i      5k      5l      5m      