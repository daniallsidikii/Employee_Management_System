   M S B A M L   `   `   `  ����  ManagementSystem2    ,Employee_Management_System.EmployeeDashboard   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Employee Dashboard��5   	   $	��650��6$   $
��1350��61    � WindowStartupLocation$ CenterScreen=�6>    � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ 	CanResize=�6*    � AllowsTransparency$ False��6A   .��5      �  � ColumnDefinitions 5   
   �� 5	      $	��200 �6   �� 5
      $��* �6   .+�5   
   �� $��0��6   ���#2C3E50$	��200��6:   $��Stretch=�6F   $��10q�6b   .+�5      �� -   5        $��Mark Attendance��5      $��5q�6/   $��40��6:   ���#34495E
�������6n   �� 5      -   5        $��View Attendance Logs��5      $��5q�64   $��40��6?   ���#34495E
�������6s   �� 5      -   5        $��Logout��5      $��5q�6&   $��40��61   ���#34495E
�������6e   5      � 5   
   $��1��6   $��10q�6   .+�5      �� 
���   �$��2q�6)    �� Padding$ 5q�6=    �� CornerRadius$ 5��6I   $��2q�6Z   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   
���   �.+�5      �� $#��Welcome to Employee Dashboard��6    $��28(�5      $
��Bold"�6+   $��Center=�5      $��0,20,0,0q�6;   ���#34495E6M   �� 5      -   5        	 ��Name$	 txtClock��5       $��28(�5       $
��Bold"�6'   ���#34495E$��Right=�5!      $��	30,20,0,0q�5"      5#      5$      �� 54      $
��Left=�6   $��Bottom=�64   $��20q�6O   
��� ���.+�55      �� $��Health Records:��6   $��16(�63   $��0,0,0,10q�6A   �� 58      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�59      �� $��Blood Pressure:��6    $��14(�67   �� 5:      -   5        
 ��Name$
 txtBloodPressure��5:      $	��150��68   $��10,0,0,0q�6D   �� 5;      -   5        $	 
txtBPAlert��5;       $��14(�64   
��� � �$	��✅��6U   5<      �� 5?      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5@      �� $��Vision:��6    $��14(�6/   �� 5A      -   5        $
 	txtVision��5A      $	��150��61   $��10,0,0,0q�6=   �� 5B      -   5        $	 txtVisionAlert��5B       $��14(�68   
��� � �$	��✅��6Y   5C      �� 5F      $ 
Horizontal=�6   $��0,5,0,0q�66   .+�5G      �� $ ��Last Checkup (YYYY-MM-DD):��6    $��14(�6B   �� 5H      -	   5        $
 txtLastCheckup��5H      $	��150��66   $��10,0,0,0q�6B   �� 5I      -
   5        $	 txtCheckupAlert��5I       $��14(�69   
��� � �$	��✅��6Z   5J      �� 5L      -   5        $��Save Health Records��5L      $	��200��67   $��40��6C   $��0,20,0,0q�6O   6a   5M      5U      5V      5W      