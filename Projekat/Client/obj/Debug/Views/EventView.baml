   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.EventView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f"calhttp://caliburnmicro.com  5      $��Century Gothic)�5
      $��14(�5      ���#dee2e6.��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��10 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Events��5         CanUserAddRows .     AutoGenerateColumns .  $��0��6V   $��1��6f    �� SelectedItem 6s   ��  �� Path$ SelectedEvent� �� Mode$ OneWayToSource=�   	CellStyle 5      �� 5      	 �� 
TargetType*  $System.Windows.Controls.DataGridCell"	  6   .�5      �� 
 �� Property
 �@��TextAlignment �� Value$ Center=�6@   5         ColumnHeaderStyle 5      �� 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"	  6   .�5      �� 
 � ��$ Center=�6I   5         Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� $ Event.Naziv�$ OneWay=�  5#      $
 Opis��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6d    63   �� $ 
Event.Opis�$ OneWay=�6d     5$      $ Pocetak��6%    66   �� $ Event.DatumVremePocetka�$ OneWay=�  5%      $
 Kraj��6%    63   �� $ Event.DatumVremeZavrsetka�$ OneWay=�  5&      $ Stanje Eventa��6%    6<   �� $ EventState.TekstStanja�$ OneWay=�   	CellStyle 5'      �� 5(      "	  6    .�5)      �� 
 � �� 6;   �� $  EventState.BackgroundColor��� 5*      
 � ��$ Center=�6K   5+      5-      4  .System.Windows.Controls.DataGridTemplateColumn  5.         CellTemplate 5/      �� 50      .R�51      ��  �� Orientation$ 
Horizontal=�6)   .+�52   "   ��  ��Name$ 	EditEvent��6)   $
��Edit��6<   	  Caliburn.Micro.Message 	  Attach$ 
EditButton��6�   $��5 5 5 5q�6�   
  Caliburn.Micro.Bind 
  Model 6K   �� *DataContext+ �� RelativeSource ��  �� AncestorType$ DataGridL���53   &   �� 54   *    �� Color$ 	#FF5BC0DE��6:    �� Opacity$	 0.6Q�6L   ��56   &   �� 57   *   "	 ��60    �� Triggers 58   .   �� 59   2    �� Binding 6>   �� $ EventState.IsEditable� �� Value True6m   .a�5:   6   �� 
 � {� .  6R   5;   3   5=   +   5?   #   �� 5@   "   $ RemoveEvent��6)   $��Remove��6>   $ RemoveButton��6�   $��0 5 5 5q�6	   6O   �� *DataContext+ �� $ DataGridL�{�6�   �� *EventState.IsRemovable+$ OneWay=���5A   &   �� 5B   *   $ 	#FFF04124��6:   $	 0.6Q�6L   5D   #   5E      5F      5H      5J      �� 5K   
   -   5        $ AddNewEvent��5K   ,   $��Dodaj Novi Event��6   $��0��6A   $��2��6Q   ���#5bc0de���#008cba6s   5L      5M      