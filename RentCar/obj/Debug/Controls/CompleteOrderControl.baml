   M S B A M L   `   `   `  ����B  >RentCar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RentCar.ControlsRentCar.Controls  5      +    %RentCar.Controls.CompleteOrderControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:RentCar.Controls     5      -   5        $	��290��5   8   $	��500��6D     � 	Resources  5	       �� MergedDictionaries �� Source �� 
TargetType   
BaseButton �� BasedOn �� Property �� Value�� 5
   
    5      �� 5      $ ../Styles/BaseStyle.xaml?�6%   %�   '��       7   �� 5      " ��6   8   .�5      ��  � ��$ 90��6*   �� 5       � ��$ 30��6+   �� 5       � ��$ 15q�6+   5      5      .��5      ]� $��Center=�6   $��Stretch=�6-   $��10q�6I   .+�5   
   �� $	��Top=�6   .+�5      �� 
�������
�������$��1,1,1,1q�6D    �� CornerRadius$ 8,8,8,8��6^   $��Stretch=�6u   ._�5      �� $��20(�6   $
��15 5q�6*   $
��Left=�68   Ваш заказ6^   5      �� 5      
���iii�
�������$��1,1,1,1q�6>   $ 1��6X   $��Stretch=�6i   $
��0 10q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 7Q�6'   
   ShadowDepth$
 3Q�66   ._�5!      �� $
��12 5q�6   .+�5"      �� #!Прокат автомобиля63   �� 5#      -   5         ��Name$ NameTextBlock��5#       $	��0 5q�67   ��6D   ��  �� Path$ Car.FullName�6i   �� 5$      Дата проката6.   �� 5%       �� Orientation$ 
Horizontal=�6!   $
��Left=�6:   .+�5&      �� -   5         ��Name$ BeginRentDate��5&   "   {�.  $��80��6K   $��0 5 5 5q�6V   ��6g   �� *BeginRentDate+ �� StringFormat$ 
dd.MM.yyyy��6�   �� 5'      $��Center=�6$   -6C   �� 5(      -   5        $ EndRentDate��5(   "   {�.  $��80��6I   $��5q�6T   ��6_   �� *EndRentDate+$ 
dd.MM.yyyy��6�   5)      5*      5+      �� 5-      
���iii�
�������$��1,1,1,1q�6>   $ 1��6X   $��Stretch=�6i    5.        5/      $	 7Q�6'   $
 3Q�66   ._�52      �� $
��12 5q�6   $	��100��6+   .+�53      �� +)Дополнительные услуги67   �� 54      -   5         ��Name$ AddServicesListBox��54      
�������$��85��6N   $��Disabled=�6]   ��55      �� *AdditionalServices+��56      �� 57      " ��6$    �� Triggers 58   "   �� 59   &    �� Binding 62   �� $ Checked� �� Value true6S   .a�5:   *   ��  � �� 6Q   �� $
 Name�5;   '   �� 5<   &    62   �� $ Checked�	 false6S   .a�5=   *   ��  � y�$ 	Collapsed=�6T   5>   '   5@      5B      5C      5D      5E      �� 5G   
   $��Bottom=�6   $��Bottom=�6-   .+�5H      �� $
��10 0q�6   .+�5I      �� 
���iii�
���iii�$��1,1,1,1q�6D   $ 8,8,8,8��6^   $	��100��6u   $
��Left=�6�   ._�5J      �� 
�������$	��5 3q�63   $��Center=�6@   Способ оплаты6l   5K      	� 5M      -   5        $��CashBtn��5M   2    	� 	GroupName$ PayType��6    d� 	IsChecked$
 TrueY�6B   $	��0 7q�6S   .��6`   Наличные6j   	� 5N      -   5        $��BankBtn��5N   2   $ PayType��6   .��6A   %#Банковский перевод6U   5O      �� 5Q      $��Center=�6   $��0 10 0 3q�65   Итоговая цена6V   �� 5R      $��Center=�6   $	��150��62   $��30��6>   ���#2196F3���#2196F3$��1,1,1,1q�6u   $ 8,8,8,8��6�   ._�5S      �� 
�������$��Center=�6/   $��Center=�6L   ��6g   �� *TotalCostString+6�   5T      �� 5U      $ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   $��3q�6j   .+�5V      �� -   5         ��Name$ CompleteBtn��5V      .��6J   ОК6N   �� 5W      -	   5        $ 	CancelBtn��5W      .��6F   Отмена6N   5X      5Y      5\      5]      