using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notatnik_Kinomana_v2.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public AddMoviePageVM AddMoviePageVM
        {
            get
            {
                return _addMoviePageVM;
            }
            set
            {
                _addMoviePageVM = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddMoviePageVM));
            }
        }
        private AddMoviePageVM _addMoviePageVM;

        public MainWindowVM()
        {
            AddMoviePageVM = new AddMoviePageVM();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
