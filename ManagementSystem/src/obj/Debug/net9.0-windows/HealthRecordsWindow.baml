   M S B A M L   `   `   `  ����  ManagementSystem4    .Employee_Management_System.HealthRecordsWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Health Records��5   	   $	��600��6    $	��670��6-    � Left$	 390��69   
 � Top$	 170��6D    � WindowStartupLocation$ Manual=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#f4f6f7 � 	Resources 5	      3  -System.Windows.Media.Effects.DropShadowEffect   DropShadowEffect   
BlurRadius   ShadowDepth   Opacity	   Color��%c   &	          5
   
   $ 10Q�5      $ 4Q�5      $	 0.3Q�5      $	 Black��5      5      .��5      � $��30q�6   .+�5   
   �� ���#efebe6
 �� CornerRadius$
 12��6&    �� Padding$ 30q�68    J� Effect# �   5      ._�5      �� .+�5      �� $��60��6   $
 10��6%   $��0,0,0,25q�67   ��5      �� 5       �� 
StartPoint$	 0,0&�6.    �� EndPoint$	 1,0&�6?   .��5      �  � Color$ #2C3E50��6+    � Offset$	 0.0Q�6;   � 5      $ #4CA1AF��6+   $	 1.0Q�6;   5      ._�5      �� $��Health Record Entry��6    
�������$��20(�5       $
��Bold"�6.   $��Center=�5        $��Center=�6;   5!      �� 5$      $��Blood Pressure��6   $��SemiBold"�62   ���#2C3E50$��0,0,0,6q�6]   $��16(�6n   �� 5%      -   5         ��Name$ txtBloodPressure��5%      $��35��64   $��14(�6@   $��0,0,0,15q�6N   �� 5'      $��Vision��6   $��SemiBold"�6*   ���#2C3E50$��0,0,0,6q�6U   $��16(�6f   �� 5(      -   5        $ 	txtVision��5(      $��35��6-   $��14(�69   $��0,0,0,15q�6G   �� 5*      $��Last Checkup Date��6   $��SemiBold"�65   ���#2C3E50$��0,0,0,6q�6`   $��16(�6q   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ dpLastCheckup��5+      $��35��64   $��14(�6@   $��0,0,0,15q�6N   �� 5.       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0,30,0,0q�6S   .+�5/      �� -   5         ��Name$ btnSave��5/      $��Save Record��6.   $	��150��50      $��40��6)   $��0,0,20,0q�51      ���#3498DB
�������$
��Bold"�52   E   $��14(�53       � Cursor$
 Hand��54      
������ 55      �� 57      -   5        $ btnLoad��57      $��Load Record��6.   $	��150��58      $��40��6)   ���#E74C3C
�������$
��Bold"�59   E   $��14(�5:      $
 Hand��5;      
������ 5<      5=      5?      5@      5A      5B      