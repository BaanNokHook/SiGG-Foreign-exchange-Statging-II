   M S B A M L   `   `   `  ????  StockTradingGraph.    (StockTradingGraph.WpfApp.DataGridControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        ? 	Resources  5         DGHeaderStyle ?? 
TargetType&   System.Windows.Controls.DataGrid ?? Property  DGCHeaderStyle ?? Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader??%(  &	        &	 X     ?? 5	   
   "  6&   .?5
      ??  ?@ ColumnHeaderStyle# ?  62   5      ?? 5   
   "  6'   .?5      ??  ? ??$ 30??6'   ?? 5       ? ?? ?#2020206+   ?? 5       ? ??
 ?????6+   ?? 5       ? ??$ 12(?6)   5      5      .??5      ? .+?5   
     -   5          Name$ dataGrid??5      ???#202020   RowBackground ?#202020   AlternatingRowBackground ?#353535
???????#???   5         CanUserSortColumns .    GridLinesVisibility$
 None=?5      	   AutoGenerateColumns	 .  $??1??5      $??2??5      
   Columns
 5       4  .System.Windows.Controls.DataGridCheckBoxColumn  5!      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ?? *
Selected+0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ X??6%      
IsReadOnly .  60   ?? *X.Name+6K     5#      $ Y??6%    .  60   ?? *Y.Name+6K     5$      $
 SD_X??6%    .  63   ?? *SD_X+ ?? StringFormat$ F4??6]     5%      $
 SD_Y??6%    .  63   ?? *SD_Y+$ F4??6]     5&      $ Alpha??6%    .  64   ?? *Regression.Alpha+$ F4??6j     5'      $
 Beta??6%    .  63   ?? *Regression.Beta+$ F4??6h     5(      $ R??6%    .  60   ?? *Regression.RValue+$ F4??6g     5)      $	 R^2??6%    .  62   ?? *Regression.RSquared+$ F4??6k     5*      $ Δ avg??6%    .  64   ?? *DeltaAverage+$ F4??6f     5+      $ Δ min??6%    .  64   ?? *
DeltaMin+$ F4??6b     5,      $ Δ max??6%    .  64   ?? *
DeltaMax+$ F4??6b     5-      $ Δ SD??6%    .  63   ?? *	DeltaSD+$ F4??6`     5.      $ 	Δ SD -3Q??6%    .  67   ?? *DeltaSDMinus3Q+$ F4??6k     5/      $ 	Δ SD +3Q??6%    .  67   ?? *DeltaSDPlus3Q+$ F4??6j   51      52      53      