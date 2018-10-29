using DataServices.EFService;
using System.Collections.ObjectModel;
using Data;
using Desktop.Commands;
using Desktop.Models;

namespace Desktop.ViewModels.BrandsViewModels
{
    public class BrandsViewModel : ViewModelBase, IUnitOfWork
    {
        public GenericRepository<Brand> BrandRepository { get; }

        public ObservableCollection<BrandModel> Brands { get; }

        private BrandModel selectedBrand;
        public BrandModel SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand => refreshCommand ?? (refreshCommand = new RelayCommand(OnRefresh));

        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(OnAdd));

        private RelayCommand editCommand;
        public RelayCommand EditCommand => editCommand ?? (editCommand = new RelayCommand(OnEdit));

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(OnDelete));

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand => cancelCommand ?? (cancelCommand = new RelayCommand(OnCancel));

        public BrandsViewModel(GenericRepository<Brand> brandRepository)
        {
            this.BrandRepository = brandRepository;
            Brands = new ObservableCollection<BrandModel>();

            OnRefresh(null);
        }

        private void OnRefresh(object obj)
        {
            Brands.Clear();
            
            foreach (Brand brand in BrandRepository.Get())
            {
                Brands.Add(new BrandModel(brand));
            }

            OnPropertyChanged(nameof(Brands));
        }

        private void OnAdd(object obj)
        {
        }

        private void OnEdit(object obj)
        {   
        }

        private void OnDelete(object obj)
        {
        }

        private void OnCancel(object obj)
        {
            OnRequestClose();
        }

        public void Save()
        {
            BrandRepository.Context.SaveChanges();
        }
    }
}
