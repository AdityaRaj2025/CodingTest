   M S B A M L   `   `   `  ����F  BRailwayTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RailwayTaskRailwayTask  5   	       RailwayTask.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RailwayTask     5   	     � Title$  Crud Operations��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��10q�6;   .+�5      �� -   5        $��
Add Record��5      $��10q�6B      MaterialDesignFlatButton#��[  6N   �� 5      -   5        $��Update Record��5      $��10q�6H   #��[  6T   �� 5      -   5        $��Delete Record��5      $��10q�6H   #��[  6T   �� 5      -   5        $��
Track Data��5      $��10q�6B   #��[  6N   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��1��6%      AutoGenerateColumns .    CanUserAddRows .  $��10,10,10,59q�6d      RowBackground
 �����   AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   6�   �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Bottom=�6;   $��10q�6V   .+�5      �� $��Role: ��6   $��5q�6&   �� 5      -   5        	 ��Name$	 roleTextBlock��5      $��5q�6/   $
��Bold"�6:   �� 5      $��User: ��6   $��5q�6&   �� 5      -   5        $	 userTextBlock��5      $��5q�6/   $
��Bold"�6:   5      5      5      