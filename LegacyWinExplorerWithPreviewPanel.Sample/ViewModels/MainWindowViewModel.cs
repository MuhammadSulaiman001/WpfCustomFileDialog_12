using System.Diagnostics;
using System.Windows;
using LegacyWinExplorerWithPreviewPanel.Sample.Views;
using Prism.Commands;
using WpfCustomFileDialog;

namespace LegacyWinExplorerWithPreviewPanel.Sample.ViewModels
{
    public class MainWindowViewModel
    {
        public DelegateCommand OpenSampleDialogCommand { set; get; }

        public MainWindowViewModel()
        {
            OpenSampleDialogCommand = new DelegateCommand(() =>
            {
                LegacyOpenFileDialogHelper.OpenCustomFileDialog<MyPreviewArea>(
                    onFileChosen: s => MessageBox.Show(s + " File Chosen"),
                    onDialogClose: () => Debug.WriteLine("Custom Dialog Closed")
                );
            });
        }
    }
}