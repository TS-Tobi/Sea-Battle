   M S B A M L   `   `   `  ����E  ASea-Battle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sea_Battle.PagesSea_Battle.Pages  5      %    Sea_Battle.Pages.PlaceShipsMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Sea_Battle.Pages     5      -   5          N� Title$  PlaceShipsMenu��5	      .��5      � .+�5   
   �� $5��//Assets/Images/Backgrounds/background_waves.png��6   $��UniformToFill=�6I   6d   (� 5   
    (� Stretch$ Uniform=�6   .��5      �� -   5         ��Name$ myCanvas��5      $	��800��6'   $	��450��63   .+�5      ��  �� Left$	 150��6   
 �� Top$ 55��6+   $	��500��6;   $	��350��6G   $5��//Assets/Images/Backgrounds/Popups/popup_raw.png��6T   6�   � 5      -   5         �Name$ gameGrid��5      $	 370��6)   $	 105��6;   $	��250��6L   $	��250��6X    � RowDefinitions 5      �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5       $��* �6(    � ColumnDefinitions 5"      �� 5#      $��* �6+   �� 5$      $��* �6+   �� 5%      $��* �6+   �� 5&      $��* �6+   �� 5'      $��* �6+   �� 5(      $��* �6+   �� 5)      $��* �6+   �� 5*      $��* �6+   �� 5+      $��* �6+   �� 5,      $��* �6+   �� 5-      $��* �6+   .+�51      �� $��0��6    $��1��6-   $��A��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 52      $��0��6    $��2��6-   $��B��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 53      $��0��6    $��3��6-   $��C��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 54      $��0��6    $��4��6-   $��D��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 55      $��0��6    $��5��6-   $��E��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 56      $��0��6    $��6��6-   $��F��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 57      $��0��6    $��7��6-   $��G��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 58      $��0��6    $��8��6-   $��H��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 59      $��0��6    $��9��6-   $��I��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5:      $��0��6    $��10��6-   $��J��6>   $��Center=�6G   $��Center=�6d   
�������$
��Bold"�6�   �� 5=      $��1��6    $��0��6-   $��1��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5>      $��2��6    $��0��6-   $��2��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5?      $��3��6    $��0��6-   $��3��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5@      $��4��6    $��0��6-   $��4��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5A      $��5��6    $��0��6-   $��5��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5B      $��6��6    $��0��6-   $��6��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5C      $��7��6    $��0��6-   $��7��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5D      $��8��6    $��0��6-   $��8��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5E      $��9��6    $��0��6-   $��9��6=   $��Center=�6F   $��Center=�6c   
�������$
��Bold"�6�   �� 5F      $��10��6    $��0��6.   $��10��6>   $��Center=�6H   $��Center=�6e   
�������$
��Bold"�6�   �� 5I      $��1��6   $��1��6*   
�������$��1q�6N   
������  J� 	AllowDrop . 6{   �� 5J      $��1��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5K      $��1��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5L      $��1��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5M      $��1��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5N      $��1��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5O      $��1��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5P      $��1��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5Q      $��1��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5R      $��1��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5U      $��2��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5V      $��2��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5W      $��2��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5X      $��2��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5Y      $��2��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5Z      $��2��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5[      $��2��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5\      $��2��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5]      $��2��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5^      $��2��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5a      $��3��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5b      $��3��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5c      $��3��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5d      $��3��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5e      $��3��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5f      $��3��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5g      $��3��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5h      $��3��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5i      $��3��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5j      $��3��6   $��10��6*   
�������$��1q�6O   
������  . 6}   �� 5m      $��4��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5n      $��4��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5o      $��4��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5p      $��4��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5q      $��4��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5r      $��4��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5s      $��4��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5t      $��4��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5u      $��4��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5v      $��4��6   $��10��6*   
�������$��1q�6O   
������  . 6}   �� 5y      $��5��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5z      $��5��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5{      $��5��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5|      $��5��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5}      $��5��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5~      $��5��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5      $��5��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��5��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��5��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��5��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5�      $��6��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��6��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5�      $��7��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��7��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5�      $��8��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��8��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5�      $��9��6   $��1��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��2��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��3��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��4��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��5��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��6��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��7��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��8��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��9��6*   
�������$��1q�6N   
������  . 6{   �� 5�      $��9��6   $��10��6*   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��1��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��3��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��4��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��2��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��5��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��6��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��7��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��8��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��9��6+   
�������$��1q�6O   
������  . 6|   �� 5�      $��10��6   $��10��6+   
�������$��1q�6P   
������  . 6}   5�      �� 5�      $	 201��6   $	 110��6.   $��35��6?   $��15��6J   $��
Lilita One)�6V   $��12(�6n   
�������Ships:6�   �� 5�      $	 195��6   $	 127��6.   $	��150��6?   $	��228��6K   ���#808080	 �� RadiusX$	 20��6g   
 �� RadiusY$
 20��6t   6�   � 5�      $	 195��6   $	 127��6)   $��75��6:   $	��228��6E    5�      �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ Ship_2��5�      $��0��6,   $*��$/Assets/Images/Icons/icon_2_ship.png��69   $��Uniform=�6g   $��5q�6y   6�   �� 5�      -   5        $ Ship_3_1��5�      $��1��6.   $,��&/Assets/Images/Icons/icon_3.1_ship.png��6;   $��Uniform=�6k   $��5q�6}   6�   �� 5�      -   5        $ Ship_3_2��5�      $��2��6.   $,��&/Assets/Images/Icons/icon_3.2_ship.png��6;   $��Uniform=�6k   $��5q�6}   6�   5�      � 5�      $	 270��6   $	 127��6)   $��75��6:   $	��228��6E    5�      �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� -   5        $ Ship_4��5�      $��0��6,   $*��$/Assets/Images/Icons/icon_4_ship.png��69   $��Uniform=�6g   $��5q�6y   6�   �� 5�      -   5        $ Ship_5��5�      $��1��6,   $*��$/Assets/Images/Icons/icon_5_ship.png��69   $��Uniform=�6g   $��5q�6y   6�   5�      �� 5�      -	   5        $ ReadyButtonImage��5�      $	 675��62   $	 395��6E   $��90��6V   $��55��6a   $-��'/Assets/Images/Buttons/button_ready.png��6m   6�   �� 5�      -
   5        $	 675��5�      $	 395��6,   $��90��6=   $��55��6H    J� Opacity$ 0Q�6n   6|   �� 5�      -   5        $ RandomButtonImage��5�      $ 25��63   $	 395��6E   $��90��6V   $��55��6a   $.��(/Assets/Images/Buttons/button_random.png��6m   6�   �� 5�      -   5        $ 25��5�      $	 395��6+   $��90��6<   $��55��6G   $ 0Q�6n   6|   �� 5�      $	 190��6   $	 410��6.   $��80��6?   $��15��6J   $��
Lilita One)�6V   $��12(�6n   
�������$��Place direction:��6�    J� Effect 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�         ShadowDepth$ 0Q�6+      Color$ Black��6;      Opacity$ 1Q�6I      
BlurRadius$ 3Q�6U   5�      �� 5�      -   5         ��Name$' !PlaceDirectionTextBlockHorizontal��5�      $	 280��6G   $	 410��6Y   $��70��6j   $��15��6u   $��
Lilita One)�6�   $��12(�6�   
�������$��1: Horizontal��6�    5�        5�      $ 0Q�6+   $ Black��6;   $ 1Q�6I   $ 3Q�6U   5�      �� 5�      -   5        $% PlaceDirectionTextBlockVertical��5�      $	 360��6E   $	 410��6W   $��60��6h   $��15��6s   $��
Lilita One)�6   $��12(�6�   ���#00ff00$��2: Vertical��6�    5�        5�      $ 0Q�6+   $ Black��6;   $ 1Q�6I   $ 3Q�6U   5�      �� 5�      -   5        $ ErrorTextBlock��5�      $	 483��64   $	 414��6F   $	��150��6W   $��
Lilita One)�6c   $��12(�6{   
���  ��$
��Wrap=�6�   $��Center=�6�   $	��Top=�6�   5�      5�      5�      5�      