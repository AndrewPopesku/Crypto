   M S B A M L   `   `   `  ����@  <Crypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Crypt.ViewsCrypt.Views  5   	       Crypt.Views.ShellView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Crypt.Views     5   	   $��15(�5        � Title$  	ShellView��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ LoadMainPage��5   .   $��1��6   $��1��6   $��5��6D   $��	0,0,708,0q�6X   .��6k   Main6q   �� 5   
   -   5        $ LoadDetailsPage��5   .   $��1��6   $��1��6   $��5��6G   $��
67,0,641,0q�6[   .��6o   	Details6x   �� 5   
   -   5         ��Name$ ActivateItem��5   J   $��3��6   $��1��6&   $��5��66   6J   5      5       