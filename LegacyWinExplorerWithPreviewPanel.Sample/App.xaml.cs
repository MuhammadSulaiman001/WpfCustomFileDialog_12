using System.Windows;
using LegacyWinExplorerWithPreviewPanel.Sample.ViewModels;
using LegacyWinExplorerWithPreviewPanel.Sample.Views;
using Prism.Ioc;
using Prism.Mvvm;

namespace LegacyWinExplorerWithPreviewPanel.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}