using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Notatnik_Kinomana_v2.Helpers;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class AddMoviePageVM : INotifyPropertyChanged
    {
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _title;

        public EMovieCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Category));
                OnPropertyChanged(nameof(IsCategorySelected));
            }
        }
        private EMovieCategory _category;

        public bool IsTitleEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                    return true;
                return false;
            }
        }

        public bool IsCategorySelected
        {
            get
            {
                if (Category == EMovieCategory.None)
                    return true;
                return false;
            }
        }
        public AddMoviePageVM()
        {
            Title = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
