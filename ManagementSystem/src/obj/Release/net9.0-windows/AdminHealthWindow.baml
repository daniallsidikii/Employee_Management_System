   M S B A M L   `   `   `  ����   ManagementSystem2    ,Employee_Management_System.AdminHealthWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  All Health Records��$	��750��$
��1300�����#121212
������� � WindowStartupLocation$ CenterScreen=�$��15q�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Padding$ 15q� �� CornerRadius$ 8��$��0,0,0,15q�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ #2C3E50�� � Offset$ 0Q�� $ #4CA1AF��$ 1Q�._��� $��Employee Health Records��$��26(�$
��Bold"�$��Center=�
��������� $��1�����#1A1A1A$ 8��$ 10q�$��0,0,0,15q�._�&   System.Windows.Controls.DataGrid  -   	  Name$	 
HealthGrid��
   AutoGenerateColumns$
 False�����#1A1A1A
�������   GridLinesVisibility$ 
Horizontal=�   RowBackground �#1A1A1A   AlternatingRowBackground �#2C2C2C   HorizontalGridLinesBrush �#444444   VerticalGridLinesBrush �#444444���#444444$��1q�   
IsReadOnly$
 True��   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   	RowHeight$ 40Q�$��0q�   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$
 Bold"���  � �� �#2C3E50��  � ��
 �������  � ��$ 10q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Username��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Username+   ElementStyle �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=�  $ Blood Pressure��$ *  �� *BloodPressure+ �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=�  $ Vision��$ *  �� *Vision+ �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=�  $ Last Checkup��$ *  �� *LastCheckup+ �� StringFormat$ {0:MM/dd/yyyy}�� �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@��TextAlignment$ Center=� � 	Resources )  #System.Windows.Controls.DataGridRow��%�   '        �� "  .���  � �� �#1A1A1A��  � ��
 �������  � �� �#2C3E50��  � ��$ 0,0,0,1q��� $��2�����#121212$ 15q�$ 8��._���  �� Orientation$ 
Horizontal=�$��Right=�$��0q�.+��� -   $��Refresh��$	��120��$��40��$��0,0,10,0q����#2C3E50
�������$
��Bold"����#2C3E50$��1q�����   �� 
TargetType"  ��.R��� #��z��#��z��$��1q�$ 20��$ 10q�._��� $��Center=�$��Center=��� -   $��Close��$	��120��$��40�����#E74C3C
�������$
��Bold"����#E74C3C$��1q����� "  ��.R��� #��z��#��z��$��1q�$ 20��$ 10q�._��� $��Center=�$��Center=�