   M S B A M L   `   `   `  ����U  QMyPrismDemo.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:MyPrismDemo.Infrastructure;assembly=MyPrismDemo.InfrastructureMyPrismDemo.Infrastructure  5       ModuleA   ModuleA.ModuleAView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \infLclr-namespace:MyPrismDemo.Infrastructure;assembly=MyPrismDemo.Infrastructure     5      .��5      �   � 	Resources  5	   
      k1 �� 
StartPoint �� EndPoint � Offset � Color��%�   &	        7���� 5
      $	 0,0&�6-   $	 0,1&�6>   .��5      � $ 0Q�6   $ White��6*   � 5      $ 1Q�6   8   6*   5      5      .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  -   5        $��ribbon1��5       �� SelectedIndex$ 0��6       HelpPaneContent 5      1  +System.Windows.Controls.Ribbon.RibbonButton  5         QuickAccessToolBar 5      =  7System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  5      .@�5        -   5          Name$
 Save��5   #   6  0System.Windows.Controls.Ribbon.RibbonSplitButton  5      -   5        	  Name$
	 Undo��5   (   .@�5      8  2System.Windows.Controls.Ribbon.RibbonSplitMenuItem  $��Undo 1��6.     5      $��Undo 2��6.     5      $��Undo 3��6.   5        5      -   5        $
	 Redo��5   (   .@�5        $��Redo 1��6.     5      $��Redo 2��6.   5       5!      
   ApplicationMenu
 5%      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5&      5  /System.Windows.Controls.Ribbon.RibbonMenuButton   KeyTip$ F��6(   .@�5'      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  $��Options��60     5(      $
��Exit��60   5)      .@�5-      .	  (System.Windows.Controls.Ribbon.RibbonTab	  $
��Home��6    	  KeyTip$ H��6&   .@�5/      0
  *System.Windows.Controls.Ribbon.RibbonGroup
  -   5         
 Name$ ClipboardGroup��5/      $��Home1��66   .@�50      
  -   5        $ subgroup��50   "   $��SubHome��64   .@�51           Label$ Sub-Cut��6'      KeyTip$ X��67     52      $	 Sub��6'   $ C��63   53        54         Label$ Paste��6'   $ V��65   .@�55      3  -System.Windows.Controls.Ribbon.RibbonMenuItem  $��Keep Text Only��6)      KeyTip$ T��6A     56      $��Paste Special...��6)   $ S��6C   �� 57      $��check3��6#   58        59      $	 Cut��6#   $ X��6/     5:      $
 Copy��6#   $ C��60     5;      $ Format Painter��6#   $ FP��6:     5<      $ splitbutton��6(   .@�5=      �� $
��chk1��6#   64   �� 5>      $
��chk2��6#    d� 	IsChecked$
 TrueY�62   6E   5?      5@      
  5B      -   5        $ Employee��5B      $��Employee And Payroll��60   .@�5C        $ Employee��6'   $ V��68   .@�5D        $��Keep Text Only��6)   $ T��6A     5E      $��Paste Special...��6)   $ S��6C   5F        5G      $
 Save��6#   $ X��60     5H      $	 Add��6#   $ C��6/   7  1System.Windows.Controls.Ribbon.RibbonToggleButton  5I         KeyTip$ L��6f   /   )MyPrismDemo.Infrastructure.GlobalCommands   NavigateCommand#��Z 6q      Label 6)   ��  �� ElementName$ ribbon1�� �� Path$ DataContext.Text�6q   5J      5K      	  5M      $��Insert��6   $ I��6(   5N      	  5P      $��
PageLayout��6   $ L��6,   5Q      5R      5S      5T      