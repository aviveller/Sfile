   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   SfileHelper   SfileHelper.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;Controls,http://metro.mahapps.com/winfx/xaml/controls   Jcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro   $��0q�(   "MahApps.Metro.Controls.MetroWindow    	GlowBrush
  �   � � Title$ S File Helper �� � WindowStyle$ SingleBorderWindow=�$��570.984��$��1027.542�� � WindowStartupLocation$ CenterScreen=� � Icon$ icon.png�� � 
ResizeMode$ CanMinimize=�.���  � ColumnDefinitions �� $	��32* ��� $
��367* ��� $	��36* �.+��� -    ��Name$ 
tabControl��$
��Left=�$	��523��$��	10,10,0,0q�$	��Top=�$
��1002��$��3��.@��� $��SFile��.��� ���	#FFE5E5E5 � RowDefinitions �� $
��142* ��� $	��95* � �� $��5* ��� $	��22* �.+��� -   	 ��Name$	 button��   AccentedSquareButtonStyle#��[  $��create S file��$
��Left=�$��
27,149,0,0q�$	��Top=�$	��147��$��31��$��1��{��� *SurveyNameOk+
 �� Mode$
 TwoWay=��� -   $	 button1��$��generate tamplate��$��1��$
��Left=�$��42.2,148.6,0,0q�$��1��$	��Top=�$��31��$	��144���� -    ��Name$ 
L_location��$��Insert csv location:��$
��Left=�$��	27,76,0,0q�$	��Top=�$��29��$	��127���� -    ��Name$ 
B_location��*   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $
��Left=�$��23��$��103,105,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��270��$��2���� -   $	 Browse��$��Browse��$
��Left=�$��
27,105,0,0q�$	��Top=�$��60��$��22���� -   $ L_SurveyName��$��Survey name:��$
��Left=�$��	27,24,0,0q�$	��Top=�$��29��$	��127���� -   $ 
SurveyName�� . $
��Left=�$��23��$��	27,53,0,0q�$
 Wrap=�$	��Top=�$	��131���� -	   $ L_Total��$��Total quatas:��$
��Left=�$��	42,24,0,0q�$	��Top=�$��29��$	��127��$��1���� -
   $ Total�� . $
��Left=�$��23��$��	42,53,0,0q�$
 Wrap=�$	��Top=�$	��147��$��1���� -    ��Name$ MyData�� �� IsTextSearchEnabled .  J� IsManipulationEnabled .  �� SelectionMode$ Extended=�$
��Left=�$	��359��$��
281,58,0,0q�$	��Top=�$	��496��$��1��$��2���� -   $	 B_Delete_record��$��9(�$��Delete record��$��192,191,536,0q�$	��Top=�$��1��$��22���� -   $	 B_Add_record��{�.  $��9(�$��
Add record��$	��Top=�$��22��$��192,218,536,0q�$��1��&   System.Windows.Controls.DataGrid  -     Name$ ShowBrowseCsv��$��0��   
IsReadOnly .    SelectionMode$ Extended=�   SelectionUnit$
 Cell=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 100* $
��Left=�$	��226��$��
27,191,0,0q�$	��Top=�$	��344��$��2��$��2���� -   $ L_CreateCsv��$,��&this will be the result of the S file:��$
��Left=�$��
281,24,0,0q�$	��Top=�$��29��$	��340��$��1���� -   $	 B_Add_record_Copy��{�.  $��9(�$��Move Up��$	��Top=�$��22��$��192,245,536,0q�$��1���� -   $	 B_Add_record_Copy1��{�.  $��9(�$��	Move Down��$	��Top=�$��22��$��192,272,536,0q�$��1��$��2���� -    ��Name$ 	runchecks��{�.  d� 	IsChecked$
 TrueY�$��
run checks��$
��Left=�$��
27,159,0,0q�$	��Top=�$��89��#   MahApps.Metro.Controls.Badged  $	��100��$��22��$��1��$��87,151,621,103q�E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null  ControlzEx.BadgedEx   Badge ��  �� ElementName$ ShowBrowseCsv�� �� Path$ Items.Count�.���� $��records��$��	35,0,0,-3q��� -   $��RedBorderSurveyname��
���  ��$	��1.5q�$
��Left=�$��26��$��	27,53,0,0q�$	��Top=�$	��131��y��� *
RedBorder1+$
 TwoWay=��� -    ��Name$ RedBorderTotal��
���  ��$	��1.5q�$
��Left=�$��26��$��	42,53,0,0q�$	��Top=�$	��147��$��1��y��� *
RedBorder2+$
 TwoWay=��� -    ��Name$ image2��$��	test2.png��$
��Left=�$��81��$��	144,1,0,0q�$	��Top=�$	��117�� J� RenderTransformOrigin$ 0.5,0.5&�$��2��y��� *
RedBorder1+z�V� .~��� ��   �� AngleY$  -9.757Q��� ! �� Angle$! 12.804Q�T� " T� X$" 1.543Q�# T� Y$# -6.791Q��� $��0q�$ �� 
IsReadOnly$ . $
��Bold"�$��11(�
������ 
������ % �� AcceptsReturn% . $
 Wrap=�$��147,2,749,224q�$��2��y��� *
RedBorder1+.��0.5 letters (A - Z) 3 numbers (1-9) ex. 12345abc�� -   $ image2_Copy��$y�Hidden=�$��	test2.png��$
��Left=�$��81��$��
175,-2,0,0q�$	��Top=�$	��117��$ 0.5,0.5&�$��1��z�V� .~��� �� $  -9.757Q��� $! 12.804Q�T� $" 1.543Q�$# -6.791Q��� $��0q�$ . $y�Hidden=�$
��Bold"�$��11(�
������ 
������ $
 Wrap=�$��179,8,542,238q�$��only numbers ex. 500��$��1���� $
��help��.���� $
��Wrap=�$��20q��� �� $
��Bold"�$�to create S file:���� �� $���fill all fileds as needed including, survey name, and the total quatas for the survey, after that load the survey quata csv, fields must be execlly as showing in the bellow exmple:���� �� Column A - the quata name.��  Column B - the quata quantity.�� .,Column C - the quata position in the T file.�� %#Column D - the quata code for data.�� �� �� .F��� -   $ image��$��0,0,0,0q�$��Center=�$��Resources\help.JPG��$	��114��$	��296���� �� $
��Bold"�$�to edit exist S file:���� �� $6�0go to edit S tab, load s file. do what you want.���� �� �� �� $��about��.���� $
��Wrap=�$��20q��� $���**********************************************************************************************************************************************************************************************���� �� $p�jThis program was created to help survey programmers create S files easyily and safty without any mastakes.���� �� $�This program was made for���� $� ���� $
��Bold"�$� Kantar TNS IL.���� �� $&� This is beta version number 1.01���� �� $�	Credit to���� $� ���� $
��Bold"�$�Avi Veller.���� �� �� $+�%For more information please contact: ���� $� ���� -   $P��Jmailto:aviveller@gmail.com?subject=question about Sfile helper &body=hello?�.��� $�aviveller@gmail.com���� �� �� $���**********************************************************************************************************************************************************************************************���� $� ���� $
��Bold"�$�Feature in this version:���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $� create new s File���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $8�2 import quatas from csv or create them right here.���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $Y�S auto check and add zeros to quata codes if needed. (limites to 4 digits diffrence)���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $:�4 auto check if quatas are Comes down to total quata.���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $H�B auto cuclation the quatas position on Tfile (quata position -286)���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $2�, auto check that no quata code are reapeted.���� �� .F��� ._�A� $��6��$��6��
��������� $� ���� .F��� �� $'�! generate basic s File template. ���� $� ���� .F��� -   $ image1��$��
770,50,0,0q�$��Resources/me.png��$	��130��$	��127���� 