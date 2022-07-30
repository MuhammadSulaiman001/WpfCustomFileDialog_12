How to Use (3 steps)

1. Create your custom xaml file (extension area)

			<wpfCustomFileDialog:ControlAddOnBase
				x:Class="LaserProject.Views.Templates.SelectControl"
				xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
				xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
				Padding="0"
				Margin="0"
				xmlns:wpfCustomFileDialog="clr-namespace:WpfCustomFileDialog;assembly=WpfCustomFileDialog"
				xmlns:drawingPreviewPanel="clr-namespace:DrawingPreviewPanel;assembly=DrawingPreviewPanel"
				Width="350" Height="500" Loaded="Control_Loaded" Background="#F0F0F0">
		
				<StackPanel Orientation="Vertical">
					<drawingPreviewPanel:DrawingPreviewPanel
						Width="250"
						x:Name="MyDrawingPreviewPanel"
						Margin="-25,4,75,0"
						Height="150"
						MyBorderThickness="0.5" />
					<!-- DxfFilePath="{Binding ToImportDxfFilePath}" -->
				</StackPanel>		
			</wpfCustomFileDialog:ControlAddOnBase>

2. Define utility function

			public static void OpenCustomFileDialog(Action<string> onFileChosen
				, Action onDialogClose = null
			)
			{
				var filters = new List<string> {"Dxf files|*.dxf"};
				var ofd = new OpenFileDialog<SelectControl>
				{
					Multiselect = false,
			//                InitialDirectory = // dir,
					Title = "Select File",
					FileDlgStartLocation = AddonWindowLocation.Right,
					FileDlgDefaultViewMode = NativeMethods.FolderViewMode.Icon,
			//                FileDlgOkCaption = "&Select",
					FileDlgEnableOkBtn = false,
					Filter = string.Join("|", filters)
				};
		
				bool? res = ofd.ShowDialog(); // todo: pass caller window (parent) if you want
		
				if (res != null && res.Value)
				{
					var chosenFile = ofd.FileName;
					onFileChosen?.Invoke(chosenFile);
				}
		
				onDialogClose?.Invoke();
			}



3. Actual call

`Utils.OpenCustomFileDialog(async path => await OnFileChosen(path).ConfigureAwait(false), OnDialogClosed);`



Credit. code-base from https://github.com/dmihailescu/CustomFileDialog/tree/master/CSharp_Code