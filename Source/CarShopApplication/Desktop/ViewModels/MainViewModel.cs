using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Desktop.Commands;
using Desktop.Views;

namespace Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand goToBrandsViewCommand;
        public RelayCommand GoToBrandsViewCommand => goToBrandsViewCommand ?? (goToBrandsViewCommand = new RelayCommand(OnGoToBrandsView));
       

        public MainViewModel()
        {
        }

        // obj parameter must be a Window type
        private void OnGoToBrandsView(object obj)
        {
            OnRequestClose();
            
            BrandsView brandsView = new BrandsView((Window)obj);            
            brandsView.Show();
        }
    }
}
