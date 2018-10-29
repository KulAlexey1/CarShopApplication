using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Desktop.Models
{
    public class BrandModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public Brand BrandData { get; }

        public int Id => BrandData.Id;

        public string Name
        {
            get { return BrandData.Name; }
            set
            {
                BrandData.Name = value;
                OnPropertyChanged();
            }
        }

        public string ImageFileName
        {
            get { return BrandData.ImageFileName; }
            set
            {
                BrandData.ImageFileName = value;
                OnPropertyChanged();
            }
        }

        public BrandModel() : this(new Brand())
        {            
        }

        public BrandModel(Brand brand)
        {
            BrandData = brand;
        }

        public string this[string columnName]
        {
            get
            {

                PropertyInfo propertyInfo = BrandData.GetType().GetProperty(columnName);
                var results = new List<ValidationResult>();

                var result = Validator.TryValidateProperty(
                    propertyInfo.GetValue(this, null),
                    new ValidationContext(this, null, null)
                    {
                        MemberName = columnName
                    },
                    results);

                if (!result)
                {
                    var validationResult = results.First();
                    return validationResult.ErrorMessage;
                }

                return string.Empty;
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
