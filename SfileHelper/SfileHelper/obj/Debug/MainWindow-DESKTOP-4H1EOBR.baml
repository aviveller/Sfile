   M S B A M L   `   `   `  ����F  BSfileHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SfileHelperSfileHelper  5   	       SfileHelper.MainWindow   5   
   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SfileHelper     5   	     � Title$  S File Helper ��5   	    � WindowStyle$ SingleBorderWindow=�6!   $��570.984��6B   $��440.542��6S    � WindowStartupLocation$ Manual=�6d    � 
ResizeMode$ CanMinimize=�6�    � Icon$ icon.png��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��14* �6   �� 5      $	��26* �6   �� 5      $
��361* �6   �� 5      $	��22* �6   .+�5   
   �� -   5         ��Name$ button��5      $��create S file��6"   $
��Left=�6:   $��	6,147,0,0q�6U   $	��Top=�6h   $��74��6�   $��2��6�   $��19��6�   �� 5   
   -   5         ��Name$ 
L_location��5      $��Insert csv location:��6$   $
��Left=�6C   $��0,76,0,0q�6^   $	��Top=�6p   $��29��6�   $	��127��6�   $��2��6�   �� 5   
   -   5         ��Name$ 
B_location��5      $
��Left=�6&   $��23��6A   $��
84,105,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��252��6�   $��2��6�   �� 5   
   -   5        $ Browse��5      $��Browse��6!   $
��Left=�62   $��	6,105,0,0q�6M   $	��Top=�6`   $��50��6x   $��2��6�   $��22��6�   �� 5   
   -   5        $ L_SurveyName��5      $��Survey name:��6&   $
��Left=�6=   $��0,24,0,0q�6X   $	��Top=�6j   $��29��6�   $	��127��6�   $��2��6�   �� 5   
   -   5        $ 
SurveyName��5      $
��Left=�6&   $��23��6A   $��6,53,0,0q�6M   $
	 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��131��6�   $��2��6�   �� 5   
   -   5        $ L_Total��5      $��Total quatas:��6!   $
��Left=�69   $��
183,24,0,0q�6T   $	��Top=�6h   $��29��6�   $	��127��6�   $��2��6�   �� 5   
   -   5        $ Total��5      $
��Left=�6!   $��23��6<   $��
189,53,0,0q�6H   $
	 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��147��6�   $��2��6�   �� 5   
   -	   5        $ B_Databrows��5      $��Browse��6&   $
��Left=�67   $��10.4,473,0,0q�6R   $	��Top=�6h   $��46��6�   $��2��6�   $��22��6�   �� 5   
   -
   5        $ L_Databrows��5      $
��Left=�6'   $��23��6B   $��84.4,473,0,0q�6N   $
	 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��252��6�   $��2��6�   �� 5   
   -   5        
 ��Name$
 MyData��5       �� IsTextSearchEnabled .  J� IsManipulationEnabled .  �� SelectionMode$ Extended=�6Z   $��2��6s   $
��Left=�6�   $	��226��6�   $��10.4,191,0,0q�6�   $	��Top=�6�   $	��326��6�   �� 5   
   -   5        $ B_Delete_record��5      $��Delete record��6*   $��240.4,422,34,0q�6B   $	��Top=�6Z   $��2��6�   $��22��6�   5       5!      