   M S B A M L   `   `   `  ����H  DProject_chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Project_chess.ViewModelsProject_chess.ViewModels  5   	       Project_chess.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Project_chess.ViewModels     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��700��6,   $	��450��6;   $	��700��6K    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � DataContext 5      2   ,Project_chess.ViewModels.MainWindowViewModel  5   
   6&    � 	Resources 5       �� 
TargetType �� Property �� Value   Buttons��%�  '��       &	      �� 5   
   " ��6   .�5   
   ��  � ��$ 43(�6/   6<   �� 5   
    �@��TextAlignment$ Center=�64   6E   �� 5   
    � ��$ 40q�6-   6:   �� 5   
    � ��$
 Bold"�61   6@   �� 5       � ��$ JetBrains Mono NL)�65   6Q   5      �� 5   
   .�5      ��  � ��
 �����6C   �� 5       � ��$	 125��6.   6<   �� 5       � ��$ 40��6/   6<   �� 5       � ��$ JetBrains Mono NL)�63   6O   5       5&      .��5(      � ��5)   
   �� 5*       �� Opacity$	 0.8Q�6   	 �� ImageSource$	 /Images/Font.jpg��6'   6H   
 � RowDefinitions
 5.   
   �� 5/      6   �� 50      $
��0.4* �6   6,   .+�53   
   �� $��0��6   Chess55      � 58   
   $��1��6    � ColumnDefinitions 59      �� 5:      6%   �� 5;      6%   .+�5>      �� -   5         ��Name$ Start_bt��5>   6   #��[  6   $��0��6n   ��6I   �� *StartGameCommand+.��6~   Start6�   �� 5?      -   5        $
 Exit��5?   6   #��[  6   
�������$��1��6m   .��6}   Exit6�   5@      5E      5L      