   M S B A M L   `   `   `  ����F  BRailwayTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RailwayTaskRailwayTask  5   	   '    !RailwayTask.RailwayTrackRouteData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RailwayTask     5   	     � Title$  Railway Track Route Data��5   	   $	��600��6*   $
��1000��67   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��10q�6;   .+�5      �� $��Data Source : :��6   $��Center=�6.   �� 5      -   5         ��Name$ txtBrowseXMLPath��5       �� TextWrapping$
 Wrap=�60   $	��508��6E   $��10,0,0,0q�6Q   �� 5      -   5         ��Name$ 	btnBrowse��5      $��Browse��6(   $��69��69   $��10,0,0,0q�6D   6V   5      �� 5   
   $��Search by Date or Status��6   $��1��65   $��10,10,562,10q�6B   .��5      �� .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Search by Status:��6   $��Center=�68   �� 5      -   5         ��Name$ 	cmbStatus��5      $��88��62   $��5q�6=   .@�5      �� $��Active��6'   �� 5       $��Inactive��6'   5!      5"      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��Start Date:��6   $��Center=�62   (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ startDatePicker��5'   !   $��5q�6:   5(      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��	End Date:��6   $��Center=�60     5+      -   5        $ endDatePicker��5+   !   $��5q�68   5,      �� 5/      $ 
Horizontal=�6   .+�50      �� -   5        $ btnSearchByDate��50      $��Search��66   $��80��6G   $��5q�6R   6]   �� 51      -   5        $ btnClearSearch��51      $��Clear Search��65   $	��100��6L   $��5q�6X   6c   52      53      54      &   System.Windows.Controls.DataGrid  59   
   -   5          Name$ dataGrid��59      $��2��6%   $��10q�62   	   AutoGenerateColumns	 .  
   Columns
 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Route Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ 
RouteTitle�  5<      $ First Station��6%    6<   �� $ FirstStation�  5=      $ Last Station��6%    6;   �� $ LastStation�  5>      $ Distance��6%    67   �� $ Distance�  5?      $ Status��6%    65   �� $ Status�  5@      $ Modified Datetime��6%    6@   �� $ LastModifiedDateTime�  5A      $ Reference Code��6%    6=   �� $ ReferenceCode�5C      �� 5F   
   $ 
Horizontal=�6   $��3��6.   $��10q�6;   .+�5G      �� -	   5        $��Import��5G      $��80��6&   62   �� 5H      -
   5        $��Updatet��5H      $��80��6'   63   �� 5I      $��Role: ��6   $��5q�6&   �� 5J      -   5         ��Name$ roleTextBlock��5J      $��5q�6/   $
��Bold"�6:   �� 5K      $��User: ��6   $��5q�6&   �� 5L      -   5        $ userTextBlock��5L      $��5q�6/   $
��Bold"�6:   5M      5N      5O      