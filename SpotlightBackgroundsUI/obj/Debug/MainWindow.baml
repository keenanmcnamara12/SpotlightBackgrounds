   M S B A M L   `   `   `  ����Q  MSpotlightBackgroundsUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotlightBackgroundsUISpotlightBackgroundsUI  5   	   '    !SpotlightBackgroundsUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SpotlightBackgroundsUI     5   	     � Title$  Spotlight to Backgrounds��5   	   $	��350��6*   $��729.341��67    � 
ResizeMode$ NoResize=�6G   .��5	      � .+�5
   
   � $
��Left=�6   $	��301��6*   $��	10,10,0,0q�67   $	��Top=�6J   $	��703��6b    J� RenderTransformOrigin$ 0.424,0.507&�6n    � RowDefinitions 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ lbl_BackgroundPath��5      $��Background Path:��60   $��Center=�6K   $��0q�6h   $��Center=�6s   �� 5      -   5        $ lbl_Dimension��5      $#��Dimensions (ex: 1920 x 1080):��6+   $��Center=�6S   $��0q�6p   $��1��6{   $��Center=�6�   �� 5      -   5        $ lbl_RunOptions��5      $��Run options:��6,   $��Center=�6C   $��0q�6`   $��2��6k   $��Center=�6x   �� 5      -   5         ��Name$ txt_YDimension��5      $��1��6Y   $
��Left=�6i   $��23��6�   $��
194,40,0,0q�6�   $��1��6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��70��6�   6�   �� 5      -   5        $ txt_XDimension��5      $��1��6Y   $
��Left=�6i   $��24��6�   $��	98,40,0,0q�6�   $��1��6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��70��6�   6�   �� 5      -   5        $ lbl_X��5      $��x��6#   $��1��6/   $
��Left=�6?   $��
173,38,0,0q�6Z   $��1��6n   $	��Top=�6{   �� 5      -   5        $ txt_BackgroundDirectory��5      $��1��67   $
��Left=�6G   $��23��6b   $��	10,40,0,0q�6n   $
 Wrap=�6�   $��Choose a directory��6�   $	��Top=�6�   $	��306��6�    �� 
IsReadOnly . 6�   �� 5      -   5        	 ��Name$$	 btn_BackgroundDirectoryChooser��5      $	��...��6=   $��1��6K   $
��Left=�6[   $��
321,40,0,0q�6v   $	��Top=�6�   $��20��6�   6�   �� 5      -	   5        $	 btn_RunOnce��5      $	��Run��6*   $��1��68   $
��Left=�6H   $��	63,44,0,0q�6c   $��2��6v   $	��Top=�6�   $��75��6�   
 � ToolTip$?
 9Copy files from the SpotLight directory once (right now).��6�   6�   �� 5      -
   5        $	 btn_ScheduleTask��5      $��
Sched Task��6/   $��1��6D   $
��Left=�6T   $��
143,44,0,0q�6o   $��2��6�   $	��Top=�6�   $��75��6�   $X
 RSchedule a task to periodically copy Spotligh images to your background directory.��6�   6  �� 5      -   5        $	 btn_unScheduleTask��5      $��Unsched Task��61   $��1��6H   $
��Left=�6X   $��
223,44,0,0q�6s   $��2��6�   $	��Top=�6�   $��75��6�   6�   5      5!      5"      