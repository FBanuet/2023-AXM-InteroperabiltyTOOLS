   M S B A M L   `   `   `  ����B  >DATools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DATools.WPFUISDATools.WPFUIS  5      $    DATools.WPFUIS.PDFRenamaerPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:DATools.WPFUIS     5        � Title$  AXM MANSUR PDF EXPORTER��69    � SizeToContent$ WidthAndHeight=�5   7    � WindowStartupLocation$ CenterScreen=�6V    � Cursor$
 Hand��6{   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5       � RowDefinitions 5   
   �� 5      $��38 �6   �� 5      $��38 �6   �� 5      $	��38* �6   .+�5   
   �� $��	 Folder: ��6   $
��Left=�6$   $��10,6,0,0q�6?   $	��Top=�6Q   $��2��6i   �� 5   
   -   5         ��Name$ SourceFolder��5      $��26��6(   $��
104,6,48,0q�64    �� TextWrapping$
 Wrap=�6H   $�� ��6\   $	��Top=�6d   $��2��6|   �� 5   
   -   5         ��Name$ 	btnFolder��5      $	��...��6$   $��Right=�62   $��0,6,7,0q�6N   $	��Top=�6_   $��2��6w   $��26��6�   $��33��6�   6�   � 5   
   -   5        	 �Name$	 progressBar��5      $��Stretch=�6+   $��26��6I   $��
10,10,10,0q�6U   $��1��6i   $	��Top=�6v   $��2��6�   �� 5   
   -   5        $ 	btnRename��5      $�� RenamePDFS��6$   $
��Left=�6:   $��	10,26,0,0q�6U   $��3��6h   $	��Top=�6u   $��26��6�   $��80��6�   $��2��6�   �� 5   
   -   5        $ btnClose��5      $��	 CloseApp��6#   $
��Left=�67   $��
104,26,0,0q�6R   $��3��6f   $	��Top=�6s   $��26��6�   $��80��6�   $��2��6�   �� 5   
   $3��-pack://siteoforigin:,,,/Resources/log2008.png��6   $	��100��6G   $��	0,0,10,17q�6S   $��Right=�6f   $��Bottom=�6�   $��2��6�   $��2��6�   5      5      