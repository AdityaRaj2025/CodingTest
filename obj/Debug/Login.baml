   M S B A M L   `   `   `  ����F  BRailwayTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RailwayTaskRailwayTask  5   	       RailwayTask.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RailwayTask     5   	     � Title$  Railway - Login��5   
   $	��200��6"   $	��300��6/   .��5	      � .+�5
   
   �� $��Select User Role:��6   $��Center=�6.   $	��Top=�6K   $��10q�6c   .��5      �� .+�5      �� -   5         ��Name$ roleComboBox��5      $	��212��61   $
��Left=�6=   $��Center=�6X   .@�5      �� $��Operator��6#   �� 5      $��Admin��6#   5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��	Password:��6   $��Center=�60   $��0,0,5,0q�6K   G� 5      -   5         G�Name$ passwordBox��5   "   $	��147��67   $��Center=�6C   5      5      5      �� 5   
   $��
User Name:��6   $	��Top=�6%   $��	10,97,0,0q�6=   �� 5   
   -   5         ��Name$ txtUser��5   J   $	��Top=�6   $	��120��6*   $��
80,101,0,0q�66    �� 
IsReadOnly . 6[   �� 5   
   -   5        $��Login��5      $
��Left=�65   $��27��6P   $	��Top=�6\   $��80��6t   $��183,128,0,0q�6   5      5      