   M S B A M L   `   `   `  ����C  ?Practice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Practice.Views.WindowsPractice.Views.Windows  5   	   +    %Practice.Views.Windows.EditUserWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Practice.Views.Windows     5   	     � Title$  EditUserWindow��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   .+�5      �� $��0 10 0 0q�6   $
��Name��6'   �� 5      $	��250��61   
���iii�
���������6   �� *	temp.name+6R   �� 5      $��0 0 0 0q�6   $��Username��6&   �� 5      $	��250��65   
���iii�
���������6   �� *temp.username+6V   �� 5      $��0 0 0 0q�6   $��Email��6&   �� 5      $	��250��62   
���iii�
���������6   �� *
temp.email+6S   �� 5      $��0 0 0 0q�6   $��Street��6&   �� 5      $	��250��6;   
���iii�
���������6   �� *temp.address.street+6\   �� 5      $��0 0 0 0q�6   $
��City��6&   �� 5      $	��250��69   
���iii�
���������6   �� *temp.address.city+6Z   �� 5      $��0 0 0 0q�6   $��Website��6&   �� 5      $	��250��64   
���iii�
���������6   �� *temp.website+6U   �� 5      $��0 0 0 0q�6   $��Company Name��6&   �� 5      $	��250��69   
���iii�
���������6   �� *temp.company.name+6Z   �� 5!      $��0 0 0 0q�6   $��
Company Bs��6&   �� 5"      $	��250��67   
���iii�
���������6   �� *temp.company.bs+6X   �� 5%      $ 
Horizontal=�6   .+�5&      �� $
��Save��6   $��10 0 0 0q�6(   ��6:   �� *SaveCommand+�� 5'      -   5        $��Cancel��5'      $��10 1 0 0q�6*   6<   5(      5)      5*      5+      