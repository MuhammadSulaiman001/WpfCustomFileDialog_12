using System.Windows.Interop;

namespace WpfCustomFileDialog
{
    public interface IWindowExt //: IWin32Window
    {

        HwndSource Source
        {
            set;
        }
        IFileDlgExt ParentDlg
        {
            set;
        }
    }
}