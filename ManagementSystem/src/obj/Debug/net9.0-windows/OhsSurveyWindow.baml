   M S B A M L   `   `   `  ����  ManagementSystem0    *Employee_Management_System.OhsSurveyWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
OHS Survey��5   	   $	��600��5   	   $	��670��6    � Left$	 390��6"   
 � Top$	 160��6-    � WindowStartupLocation$ Manual=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#f4f6f7 � 	Resources 5
       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Padding �� Triggers P� Property P� Value��%  '��       '�� �     '�� �    '�� /    �� 5   
   " ��6   .�5      ��  � �� �#2C3E506+   �� 5       � ��$ 14(�6)   �� 5       � ��$ 5,10,5,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 32��6'   �� 5       � ��$ 5,0,5,10q�6'   �� 5       � ��
 �����6+   �� 5       � �� �#4CA1AF6,   �� 5       � �� �#2C3E506+   �� 5       � ��$ 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 60��6'   �� 5       � ��$ 5,0,5,10q�6'   �� 5       � ��
 �����6+   �� 5       � �� �#4CA1AF6,   �� 5       � �� �#2C3E506+   �� 5        � ��$ 5q�6(   �� 5!       �@��TextWrapping$
 Wrap=�6-   �� 5"      # �@��VerticalScrollBarVisibility$
 Auto=�6<   5#      �� 5%   
   " ��6   .�5&      ��  � ��$	 120��6&   �� 5'       � ��$ 40��6'   �� 5(       � �� �#4CA1AF6+   �� 5)       � ��
 �����6+   �� 5*       � ��$ 14(�6)   �� 5+       � ��$ SemiBold"�6+   �� 5,       � ��$ 	0,20,0,10q�6'   �� 5-       �@�Cursor$
 Hand��6'   �� 5.       � ��$ 0q�60   �� 5/       � �� 50      �� 51      "	 ��6&   .R�52      �� #��z��6!   $
 4��53   !   $
 10,5q�54   !   ._�55      �� $��Center=�6/   $��Center=�6L   56      57      59       5:      P� 5;       �@J�IsMouseOver$
 True��61   . �5<      ��  � �� �#3D8B9663   5=      5?      5@      .��5B      � $��15q�6   .+�5C   
   �� ���#efebe6$
 8��6&   $ 15q�67   ._�5D      �� $
��Auto=�6   $��Disabled=�6>   .��5E      �� .+�5G      �� ���#2C3E50$
 4��62   $ 10q�6C   $��0,0,0,15q�6P   ._�5H      �� $1��+Occupational Health and Safety (OHS) Survey��6$   $��18(�5I   $   $
��Bold"�5J   $   
�������$��Center=�5L   $   5M      �� 5P      
�������$
 4��60   $ 10q�6A   ._�5Q      �� .+�5S      �� $=��71. Have you experienced any workplace hazards recently?��6(   $��SemiBold"�6g   �� 5T      -   5        $��
cmbHazards��5T   '   .@�5U   "   �� $	��Yes��6/   �� 5V   "   $��No��6/   5W      �� 5Z      $&�� 2. How often do you take breaks?��6(   $��SemiBold"�6P   �� 5[      -   5        $��	cmbBreaks��5[   '   .@�5\   "   �� $��
Every hour��6/   �� 5]   "   $��Every 2 hours��6/   �� 5^   "   $��Rarely��6/   5_      �� 5b      $3��-3. Do you feel comfortable in your workspace?��6(   $��SemiBold"�6]   �� 5c      -   5        $��
cmbComfort��5c   '   .@�5d   "   �� $	��Yes��6/   �� 5e   "   $��No��6/   5f      �� 5i      $K��E4. Have you faced any ergonomic issues (e.g., back pain, wrist pain)?��6(   $��SemiBold"�6u   �� 5j      -   5        $��cmbErgonomics��5j   '   .@�5k   "   �� $	��Yes��6/   �� 5l   "   $��No��6/   5m      �� 5p      $F��@5. Do you feel your workplace provides adequate safety measures?��6(   $��SemiBold"�6p   �� 5q      -   5        $��	cmbSafety��5q   '   .@�5r   "   �� $	��Yes��6/   �� 5s   "   $��No��6/   5t      �� 5w      $?��96. Have you received proper training on workplace safety?��6(   $��SemiBold"�6i   �� 5x      -   5        $��cmbTraining��5x   '   .@�5y   "   �� $	��Yes��6/   �� 5z   "   $��No��6/   5{      �� 5~      $;��57. Do you experience stress or mental strain at work?��6(   $��SemiBold"�6e   �� 5      -   5        $��	cmbStress��5   '   .@�5�   "   �� $��Often��6/   �� 5�   "   $��	Sometimes��6/   �� 5�   "   $��Rarely��6/   5�      �� 5�      $B��<8. Are emergency exits and first aid kits easily accessible?��6(   $��SemiBold"�6l   �� 5�      -   5        $��cmbEmergency��5�   '   .@�5�   "   �� $	��Yes��6/   �� 5�   "   $��No��6/   5�      �� 5�      $>��89. Do you have any concerns regarding workplace hygiene?��6(   $��SemiBold"�6h   �� 5�      -	   5        $��
cmbHygiene��5�   '   .@�5�   "   �� $	��Yes��6/   �� 5�   "   $��No��6/   5�      �� 5�      $6��010. Any suggestions to improve workplace safety?��6(   $��SemiBold"�6`   �� 5�      -
   5        $��txtSuggestions��5�   &   5�      5�      �� 5�      -   5        $��Submit Survey��5�      $��Center=�5�      5�      5�      5�      5�      5�      5�      