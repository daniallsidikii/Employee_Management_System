   M S B A M L   `   `   `  ����   ManagementSystem6    0Employee_Management_System.AdminAttendanceWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  All Attendance Records��$	��750��$
��1300�����#121212
������� � WindowStartupLocation$ CenterScreen=� � 	Resources    RoundedButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth	 �� 
TargetType
 �� CornerRadius �� Triggers P� Property P� Value��%�  &	        �� " ��.���  � ��$ Segoe UI)���  � ��$ 16(���  � ��$	 8,4q���  � ��$ 5q���  � ��
 �������  � �� �#4CA1AF��  � ��$ 0q���  �@�Cursor$
 Hand����  �@J�Effect   $ Black��$ 8Q�$ 2Q���  � �� �� "	 ��.R��� #��z��$
 10��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �#5DB1BF.��� $��15q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��3.5* ��� $
��2.5* �.+��� $��0��$��2��$
 8�� �� Padding$ 12q�$��0,0,0,10q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,0&�.���  � Color$ #2C3E50�� � Offset$ 0Q�� $ #4CA1AF��$ 1Q�._��� $��🗂  Attendance Records��$��26(�$
��Bold"�$��Center=�$��Center=�
��������� $��1��$��0�����#1E1E1E���#4CA1AF$��0q�$
 10��$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ AttendanceGrid��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   CanUserAddRows$ False�����#1E1E1E
�������   GridLinesVisibility$ 
Horizontal=�   AlternatingRowBackground �#2A2A2A   RowBackground �#1E1E1E$��14(�   	RowHeight$ 35Q�   HeadersVisibility$ Column=�   ColumnHeaderHeight$ 35Q�   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �#4CA1AF��  � ��
 �������  � ��$
 Bold"���  � ��$ Center=���  � ��$ 0q���  � ��$
 10,0q�    Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   Header$! Username��"   Width5  /System.Windows.Controls.DataGridLengthConverter$" * 1  +System.Windows.Controls.DataGridBoundColumn#   Binding# �� *
Username+  $
! Date��$" * # �� *Date+  $! Log Type��$" * # �� *	LogType+  $! Message��$" 2* # �� *
LogMessage+�� $��1��$��1��$ �� Orientation$$ Vertical=�$��20,0,0,0q�$��Stretch=�.+��� $��Filter Options��
�������$
��Bold"�$��10q�$��0,0,0,15q����#4CA1AF���#1E1E1E$��1q�$��14(�.���� $$ Vertical=�$	��0,5q�.+�R� -   % R�Name$% LogTypeTreeView�����#2C3E50
����������#4CA1AF$��1q�$��10q�$��14(�$	��150��.@�Q� $��All Logs��& Q� 
IsExpanded$
& True��.@�Q� $��Clock In��Q� $��	Clock Out��Q� $��
Attendance���� $$ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� $��Select Date:��$��SemiBold"�$��Center=�$��0,0,10,0q�(  "System.Windows.Controls.DatePicker  -   '  Name$' DateFilterPicker��$	��200��$��32�����#2C3E50$��14(����#4CA1AF$��1q� ��%K   '��       �� " ��.���  � ��
 �������  � �� �#2C3E50� $��0,15,0,0q� �� $��* ��� $
��Auto �.+��� -   $��1��$��Reset Filters��$	��160��$��35��#��[  �� $��Actions��
�������$
��Bold"�$��10q�$��0,0,0,0q����#1E1E1E���#4CA1AF$��1q�$��14(�.���� $$ 
Horizontal=�$��Right=�.+��� $��🔄 Refresh��$	��120��$��35��#��[  �� -   $��	❌ Close��$	��120��$��35��#��[  ���#D9534F$��10,0,0,0q�