   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	       Client.Views.NewEventView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Event��5	   	   $	��300��6   $	��320��6$   $��Century Gothic)�5
   	   $��14(�5   	   ���#dee2e6 � 	Resources 5         	boolToVis��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5       $��40 �6   �� 5!      $��* �6   �� 5"      $��40 �6   .+�5%   
   �� $��Naziv:��6   $��1��6"   $��1��6/   �� 5&   
   -   5         ��Name$ Naziv��5&      $��2��6!   $��1��6.   �� 5(   
   $��Opis:��6   $��3��6!   $��1��6.   �� 5)   
   -   5        $
 Opis��5)      $��4��6    $��1��6-    �� MinLines$ 3��6=   �� 5+   
   $��	Pocetak: ��6   $��5��6%   $��1��62   &   Xceed.Wpf.Toolkit.DateTimePicker  5,   
   -   5          Name$ Pocetak��5,      $��6��6/   $��1��6<   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6L   ��  �� Path$ Pocetak��� 5.   
   $��Kraj:��6   $��7��6!   $��1��6.     5/   
   -   5        $
 Kraj��5/      $��8��6,   $��1��69    6I   �� $
 Kraj��� 51   
   -   5        	 ��Name$	 AddNewEvent��51   /   $��Kreiraj novi Event!��6   $��9��6D   $��1��6Q   $
��0 10q�6a   ���#5bc0de���#008cbay�52      �� $ IsNew�
 �� 	Converter#
 [  6n   �� 53   
   -   5        $	 	EditEvent��53   (   $��Izmeni Event��6   $��9��6;   $��1��6H   $
��0 10q�6X   ���#5bc0de���#008cbay�54      �� $ IsChange�#
 [  6q   �� 56   
   -   5         ��Name$ Error��56      $��10��6#   $��1��61   58      59      