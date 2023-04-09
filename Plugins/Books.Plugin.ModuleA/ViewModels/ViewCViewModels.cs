using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Plugin.ModuleA.ViewModels
{
    public class ViewCViewModels : IDialogAware
    {
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand OKCommand { get; set; }
        public ViewCViewModels() {
            CancelCommand = new DelegateCommand(Cancel);
            OKCommand = new DelegateCommand(OK);
        }

        private void OK()
        {
            OnDialogClosed();
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            var keys = new DialogParameters
            {
                { "Value", "Hello Dialog" }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
        }
    }
}
