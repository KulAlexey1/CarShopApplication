using System;
using System.Windows;
using Data;
using DataServices.EFService;
using Desktop.ViewModels.BrandsViewModels;

namespace Desktop.Views
{
    /// <summary>
    /// Interaction logic for BrandsView.xaml
    /// </summary>
    public partial class BrandsView : Window
    {
        public BrandsView(Window parentWindow)
        {
            InitializeComponent();

            CarShopDBContext context = new CarShopDBContext();
            GenericRepository<Brand> brandRepository = new GenericRepository<Brand>(context);
            BrandsViewModel brandsViewModel = new BrandsViewModel(brandRepository);
            brandsViewModel.RequestClose += (object sender, EventArgs e) =>
            {
                this.Close();
            };
            DataContext = brandsViewModel;

            this.Closed += (object sender, EventArgs e) =>
            {
                context.Dispose();
                parentWindow.Show();
            };
        }
    }
}
