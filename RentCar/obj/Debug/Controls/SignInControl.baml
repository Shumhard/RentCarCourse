   M S B A M L   `   `   `  ����B  >RentCar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RentCar.ControlsRentCar.Controls  5      $    RentCar.Controls.SignInControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:RentCar.Controls     5      $	��250��5   7   $	��370��6C     � 	Resources  5	       �� MergedDictionaries �� Source �� 
TargetType   
BaseButton �� BasedOn �� Property �� Value�� 5
   
    5      �� 5      $ ../Styles/BaseStyle.xaml?�6%   %�   '��       7   �� 5      " ��6   8   .�5      ��  � ��$	 125��6*   �� 5       � ��$ 40��6+   �� 5       � ��$	 0 7q�6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��Center=�6"   $��10q�6=   .+�5      �� $��0 40 0 0q�6   
Логин61   �� 5      -   5         ��Name$ LoginTxt��5      $��0 5 0 0q�6(   6;   �� 5      $��0 10 0 0q�6   Пароль62   G� 5       -   5        	 G�Name$	 PasswordTxt��5       $��0 5 0 0q�6/   6B   5!      �� 5"   
   $��1��6   $��Center=�6"   .+�5#      �� -   5        
 ��Name$
 	SignInBtn��5#      .��6@   
Вход6F   �� 5$      -   5        $
 GuestBtn��5$      .��6@   
Гость6G   �� 5%      -   5        $
 	SignUpBtn��5%      .��6@   Регистрация6M   �� 5&       �� TextAlignment$ Center=�6   $	��0 5q�6/   �� 6=   -   5        .�5&   _   
Выход6f   6r   5'      5(      5)      