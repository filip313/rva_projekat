   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	       Client.Views.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	     � Title$  Login��5	   	   $	��270��6   $	��300��6$   $��Century Gothic)�5
   	   $��14(�5   	   ���#dee2e6.��5      �  � ColumnDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��30 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6!   $��5q�61   $��Username��6<   �� 5   
   -   5         ��Name$ Username��5      $��2��6%   $��1��62   �� 5!   
   $��3��6   $��1��6!   $��5q�61   $��Password��6<   G� 5$   
     Caliburn.Micro.Message   Attach$C =[Event PasswordChanged] = [Action OnPasswordChanged($source)]��6   $��4��6i   $��1��6v   �� 5&   
   -   5         ��Name$ 
LoginClick��5&      $��5��6%   $��1��62   $
��0 10q�6B   ���#5bc0de���#008cba.��6{   Login6�   �� 5(   
   $��6��6   $��1��6"   ��62   ��  �� Path$ Error� �� Mode$ OneWay=�5)      5*      