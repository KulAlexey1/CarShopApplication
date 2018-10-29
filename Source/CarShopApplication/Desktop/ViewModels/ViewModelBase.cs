using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Desktop.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
