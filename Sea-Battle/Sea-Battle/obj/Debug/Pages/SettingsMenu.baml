   M S B A M L   `   `   `  ����E  ASea-Battle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Sea_Battle.PagesSea_Battle.Pages  5      'clr-namespace:Sea_Battle
Sea_Battle  5      #    Sea_Battle.Pages.SettingsMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Sea_Battle.Pages     5      +customclr-namespace:Sea_Battle     5        N� Title$  SettingsMenu��5
      .��5      � .+�5   
   �� $5��//Assets/Images/Backgrounds/background_waves.png��6   $��UniformToFill=�6I   6d   (� 5   
    (� Stretch$ Uniform=�6   .��5      �� $	��800��6   $	��450��6!   .+�5      ��  �� Left$	 150��6   
 �� Top$ 50��6+   $	��500��6;   $	��350��6G   $:��4/Assets/Images/Backgrounds/Popups/popup_settings.png��6T   6�   �� 5      -   5         ��Name$ ExitButtonImage��5      $	 548��61   $ 50��6D   $��50��6T   $��50��6_   $,��&/Assets/Images/Buttons/button_exit.png��6k   6�   �� 5      -   5        $	 548��5      $ 50��6,   $��50��6<   $��50��6G    J� Opacity$ 0Q�6l   6z   �� 5      $	 250��6   $	 130��6+   $	��300��6<   $��40��6H   $
��Fill=�6T   $F��@/Assets/Images/Backgrounds/Input_fields/input_field_settings.png��6c   6�   �� 5      $	 260��6   $	 135��6+   $��30��6<   $��30��6G   $)��#/Assets/Images/Icons/icon_sound.png��6S   6�   �� 5      -   5         ��Name$ SoundSlider��5      $	 338��6.   $	 141��6A   $	��200��6R   $��20��6^   $
��Left=�6j   $��Center=�6�   6�   �� 5      $	 250��6   $	 190��6+   $	��300��6<   $��40��6H   $
��Fill=�6T   $F��@/Assets/Images/Backgrounds/Input_fields/input_field_settings.png��6c   6�   �� 5      $	 260��6   $	 195��6+   $��30��6<   $��30��6G   $)��#/Assets/Images/Icons/icon_music.png��6S   6�   �� 5       -   5        $ MusicSlider��5       $	 338��6.   $	 201��6A   $	��200��6R   $��20��6^   $
��Left=�6j   $��Center=�6�   6�   �� 5$      $	 250��6   $	 250��6+   $	��300��6<   $��40��6H   $
��Fill=�6T   $F��@/Assets/Images/Backgrounds/Input_fields/input_field_settings.png��6c   6�   �� 5%      $	 260��6   $	 255��6/   $	��110��6@   $��30��6L   $��25(�6X   
�������$��
Lilita One)�6y   
Language6�   �� 5'      $	 400��6   $	 256��6*   $	��120��6;   $��30��6G   $A��;/Assets/Images/Backgrounds/Input_fields/input_field_raw.png��6S   6�   �� 5(      -   5         ��Name$ CurrentLanguageText��5(      $	 405��69   $	 261��6K   $��85��6\   $��20��6g   $��18(�6s   
�������$��
Lilita One)�6�   	English6�      Sea_Battle.DropdownMenu  5+      $	 496��6&   $	 262��68    � 	Resources 5,      	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� Padding �� Triggers P� Property P� Value N� EnterActions �� TargetProperty	 �� To g� Duration N� ExitActions��%�  '��       �� 5-      "	 ��6    .�5.      �� 
 � ��
 ���� 6;   �� 5/      
 � ��$ 0q�6@   �� 50      
 � ��$
 10 5q�68   �� 51      
 � ��$ Center=�6K   �� 52      
 � ��$ Center=�6I   �� 53      
 � �� 54   "   �� 55   &   " ��66   .R�56   *   �� # z��57   )   #��z��58   )   #��z��59   )   #��z��5:   )   ._�5;   .   �� #��z��5<   -   $��Center=�5=   -   $��Center=�5>   -   5?   +   5@   '   5B       5D      P� 5E   "    �@J�IsMouseOver .  5F   &   �� 5G   *   .��5H   .   �� .��5I   2   �� $( "Background.(SolidColorBrush.Color)�5J   1   $ 	LightGrayX�5K   1   $ 0:0:0.1D�5L   1   5M   /   5N   +    5P   &   �� 5Q   *   .��5R   .   �� .��5S   2   �� $( "Background.(SolidColorBrush.Color)�5T   1   $ TransparentX�5U   1   $ 0:0:0.1D�5V   1   5W   /   5X   +   5Z   #   5\      5]      .��5^      �� 
�������
�������$��1q�5a      ._�5b      �� .+�5c      �� -   5        $��English��5c   8   5d      5e      5f      �� 5j      $	 250��6   $	 310��6+   $	��300��6<   $��40��6H   $
��Fill=�6T   $F��@/Assets/Images/Backgrounds/Input_fields/input_field_settings.png��6c   6�   �� 5k      $	 260��6   $	 315��6/   $	��110��6@   $��30��6L   $��25(�6X   
�������$��
Lilita One)�6y   
Fullscreen6�   �� 5m      -   5        $ FullscreenToggleImage��5m      $	 430��67   $	 315��6J   $��60��6[   $��30��6f   $.��(/Assets/Images/Icons/icon_toggle_off.png��6r   $
��Left=�6�   $��Center=�6�   6�   �� 5n      -   5        $	 430��5n      $	 315��6,   $��60��6=   $��30��6H   $ 0Q�6m   $
��Left=�6y   $��Center=�6�   6�   5o      5p      5q      5r      