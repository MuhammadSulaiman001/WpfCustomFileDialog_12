using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfCustomFileDialog
{
    public static class LegacyOpenFileDialogHelper
    {
        public static void OpenCustomFileDialog<T>(Action<string> onFileChosen,
            string dialogTitle = "Select File",
            Action onDialogClose = null
        ) where T : UserControl, IWindowExt, new()
        {
            var filters = new List<string> { "Text Files|*.txt" };
            var ofd = new OpenFileDialog<T>
            {
                Title = dialogTitle,
                Multiselect = false,
                // InitialDirectory = @"C:\",
                FileDlgStartLocation = AddonWindowLocation.Right,
                FileDlgDefaultViewMode = NativeMethods.FolderViewMode.Icon,
                // FileDlgOkCaption = "&Select",
                FileDlgEnableOkBtn = false,
                Filter = string.Join("|", filters)
            };
            // pass caller window (parent) if you want
            var res = ofd.ShowDialog();

            if (res != null && res.Value)
            {
                var chosenFile = ofd.FileName;
                onFileChosen?.Invoke(chosenFile);
            }

            onDialogClose?.Invoke();
        }

    }
}