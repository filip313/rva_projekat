   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	        Client.Views.NewPlanerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	     � Title$  Planer��5   	   $	��300��6   $	��320��6%   $��Century Gothic)�5	   	   $��14(�5
   	   ���#dee2e6 � 	Resources 5   
      	boolToVis��%   &	        �� 5      6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5"   
   �� $��Naziv Planera:��6   $��1��6*   $��1��6:   �� 5#   
   -   5         ��Name$ Naziv��5#      $��2��6!   $��1��6.   �� 5%   
   $��Opis: ��6   $��1��6"   $��3��62   �� 5&   
   -   5        $
 Opis��5&      $��1��6    $��4��60    �� MinLines$ 3��6=   �� 5(   
   $��Datum pocetka: ��6   $��1��6+   $��5��6;   (  "System.Windows.Controls.DatePicker  5)   
   -   5          Name$ DatumPocetka��5)      $��1��6+   $��6��6;      FirstDayOfWeek$ Monday=�6H   �� 5+   
   $��Datum zavrsetka: ��6   $��1��6-   $��7��6=     5,   
   -   5        $ DatumZavrsetka��5,      $��1��6-   $��8��6=   $ Monday=�6J   $��0 0 0 10q�6b   �� 5.   
   -   5         ��Name$ CreateNewPlaner��5.   0   $��Napravi novi planer!��6   $��1��6I   $��9��6Y   ���#5bc0de���#008cbay�5/      �� *IsNew+	 �� 	Converter#	 [  6i   �� 50   
   -   5        $ 
EditPlaner��50   *   $��Izmeni planer!��6   $��1��6>   $��9��6N   ���#5bc0de���#008cbay�51      �� *
IsChange+#	 [  6l   53      54      