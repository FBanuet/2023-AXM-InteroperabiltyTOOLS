   M S B A M L   `   `   `  ����B  >DATools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DATools.MVVM.ViewDATools.MVVM.View  5      !    DATools.MVVM.View.SolidView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:DATools.MVVM.View     5        � Title$  AXM Rebar3D View Manager��5      $��Arial Narrow)�5	   	   $��16(�5
   	    � WindowStartupLocation$ CenterOwner=�5   	   $��287.197��5      $	��500��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��15q�6.   .+�5      �� $��Set Solid In View��6    d� 	IsChecked 63   �� *isCheckedSolid+�� 5      $��Set Unobscured In View��6   $��75 0 q�68    6G   �� *isCheckedUnobscured+5      �� 5   
   $ 
Horizontal=�6   $	�� 15q�6.   $��1��6;   .+�5      �� $'��!Métodos de Filtrado y Selección��6   �� 5      $	��250��6   $��40��6#   $
��6 0 q�6/    �� SelectedIndex 6=   �� *selectedIndex+.@�5      �� $��Todos Elementos en Vista��6   �� 5      $��Elementos Seleccionados��6   5      5      �� 5   
   $��Correr��6   $��2��6"   $��40��6/   ��6;   �� *	ButtonRun+5!      5"      