   M S B A M L   `   `   `  ����E  ASea-Battle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sea_Battle.PagesSea_Battle.Pages  5      "    Sea_Battle.Pages.WaitingMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Sea_Battle.Pages     5        N� Title$  WaitingMenu��5	      .��5      � .+�5   
   �� $5��//Assets/Images/Backgrounds/background_waves.png��6   $��UniformToFill=�6I   6d   (� 5   
    (� Stretch$ Uniform=�6   .��5      �� $	��800��6   $	��450��6!   .+�5      ��  �� Left$	 150��6   
 �� Top$ 50��6+   $	��500��6;   $	��350��6G   $9��3/Assets/Images/Backgrounds/Popups/popup_waiting.png��6T   6�   �� 5      -   5         ��Name$ CurrentPlayerNumber��5      $	 440��69   $ 66��6L   $��29��6\   $��30��6g   $��
Lilita One)�6s   $��25(�6�   
������� �� TextAlignment$ Center=�6�   06�   �� 5      $	 467��6   $ 66��6/   $��29��6?   $��30��6J   $��
Lilita One)�6V   $��25(�6n   
�������/6�   �� 5      -   5        $ MaxPlayerNumber��5      $	 480��65   $ 66��6H   $��29��6X   $��30��6c   $��
Lilita One)�6o   $��25(�6�   
�������$ Center=�6�   06�   � 5      -   5         �Name$ PlayerContainer��5      $	 172��65   $	 108��6H   $	��450��6Y   $	��200��6e    � Orientation$ 
Horizontal=�6r   6�   �� 5      $	 205��6   $	 320��6+   $��40��6<   $��40��6G   $.��(/Assets/Images/Icons/icon_arrow_back.png��6S   6�   �� 5      -   5        $	 205��5      $	 320��6,   $��40��6=   $��40��6H    J� Opacity$ 0Q�6m   6{   �� 5      -   5        	 ��Name$	 StartButtonImage��5      $	 510��62   $	 310��6E   $��90��6V   $��55��6a   $-��'/Assets/Images/Buttons/button_start.png��6m   6�   �� 5      -   5        $	 510��5      $	 310��6,   $��90��6=   $��55��6H   $ 0Q�6n   6|   �� 5"      $	 330��6   $	 395��6+   $	��140��6<   $��45��6H   $;��5/Assets/Images/Backgrounds/Popups/popup_ipaddress.png��6T   6�   �� 5#      -   5        $ ServerIPAddress��5#      $	 365��66   $	 409��6I   $	��100��6Z   $��18��6f   $��
Lilita One)�6r   $��13(�6�   
�������$ Center=�6�   	127.0.0.16�   �� 5&      -   5        $ ErrorTextBlock��5&      $	 510��64   $	 416��6F   $	��150��6W   $��
Lilita One)�6c   $��12(�6{   
���  ��$
��Wrap=�6�   $
��Left=�6�   $	��Top=�6�   5(      5)      5*      5+      