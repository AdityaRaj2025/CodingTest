   M S B A M L   `   `   `  ����F  BRailwayTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RailwayTaskRailwayTask  5   	   !    RailwayTask.AddRecordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RailwayTask     5   	     � Title$  Add/Update Route��5   	   $	��300��6"   $	��400��6/   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Route Title:��6   $��0��6(   $��0��65   $��0,0,10,0q�6E   �� 5   
   -   5         ��Name$ routeTitleTextBox��5      $��0��6-   $��1��6:   �� 5   
   $��First Station:��6   $��1��6*   $��0��67   $��	0,10,10,0q�6G   �� 5   
   -   5        $ firstStationTextBox��5      $��1��6/   $��1��6<   $��0,10,0,0q�6L   �� 5   
   $��Last Station:��6   $��2��6)   $��0��66   $��	0,10,10,0q�6F   �� 5   
   -   5        $ lastStationTextBox��5      $��2��6.   $��1��6;   $��0,10,0,0q�6K   �� 5    
   $��Distance (km):��6   $��3��6*   $��0��67   $��	0,10,10,0q�6G   �� 5!   
   -   5        $ distanceTextBox��5!      $��3��6+   $��1��68   $��0,10,0,0q�6H   �� 5#   
   $��Status:��6   $��4��6#   $��0��60   $��	0,10,10,0q�6@   �� 5$   
   -   5        $ statusTextBox��5$      $��4��6)   $��1��66   $��0,10,0,0q�6F   �� 5&   
   -   5        $	��Add��5&      $��5��6   $��2��6,   $��Center=�6R   $��	0,20,0,67q�6o   $	��116��6�   5'      5(      