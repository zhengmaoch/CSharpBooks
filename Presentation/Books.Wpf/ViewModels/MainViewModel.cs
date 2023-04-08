using Books.Wpf.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Wpf.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public DelegateCommand<string> OpenCommand { get; private set; }
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand<string>(Open);
        }

        private object body;
        public object Body { 
            get { return body; } 
            set { body = value; RaisePropertyChanged(); } 
        }

        private void Open(string obj)
        {
            switch (obj)
            {
                case "A": Body = new ViewA(); break;
                case "B": Body = new ViewB(); break;
                case "C": Body = new ViewC(); break;
            }
        }
    }
}
