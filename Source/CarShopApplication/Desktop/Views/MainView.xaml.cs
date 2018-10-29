using System.Windows;
using Desktop.ViewModels;

namespace Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.RequestClose += (sender, args) =>
            {
                this.Hide();
            };
            DataContext = mainViewModel;            
        }
    }
}
