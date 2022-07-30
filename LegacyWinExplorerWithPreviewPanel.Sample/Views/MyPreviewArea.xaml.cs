using System.Diagnostics;
using System.Windows;
using WpfCustomFileDialog;

namespace LegacyWinExplorerWithPreviewPanel.Sample.Views
{
    public partial class MyPreviewArea : ControlAddOnBase
    {
        public MyPreviewArea()
        {
            InitializeComponent();
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Control Loaded");
            ParentDlg.EventFileNameChanged += (_, path) =>
                FileText.Text = $"Selected File: {path}";
        }
    }
}