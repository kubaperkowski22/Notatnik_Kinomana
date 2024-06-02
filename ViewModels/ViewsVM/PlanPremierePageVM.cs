using Notatnik_Kinomana_v2.Helpers;
using Notatnik_Kinomana_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class PlanPremierePageVM : INotifyPropertyChanged
    {
        public AllPremieres AllPremieres { get; set; }

        public ObservableCollection<Premiere> Premieres { get; set; }

        public Premiere SelectedPremiere { get; set; }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;

                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
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

                OnPropertyChanged(nameof(Category));
                OnPropertyChanged(nameof(IsCategorySelected));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
        private EMovieCategory _category;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value.Date;

                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(IsSaveButtonEnabled));
            }
        }
        private DateTime _date;

        public bool IsAlreadySeen 
        {
            get
            {
                return _isAlreadySeen;
            }
            set
            {
                _isAlreadySeen = value;

                OnPropertyChanged(nameof(IsAlreadySeen));
            }
        }
        private bool _isAlreadySeen;

        public bool IsTitleEmpty
        {
            get => string.IsNullOrEmpty(Title);
        }
        public bool IsCategorySelected
        {
            get => Category is EMovieCategory.Brak? true: false;
        }

        public bool IsSaveButtonEnabled
        {
            get
            {
                if (!IsTitleEmpty && !IsCategorySelected)
                    return true;

                return false;
            }
        }
        public PlanPremierePageVM(AllPremieres premieres)
        {
            AllPremieres = premieres;
            Premieres = premieres.Premieres;
            Date = DateTime.Now.Date;
        }

        public void AddPremiere()
        {
            Premieres.Add(new Premiere(Title, Category, Date, IsAlreadySeen));

            MessageBox.Show("Pomyślnie dodano premierę.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);

            OnPropertyChanged(nameof(Premieres));
        }

        public void DeletePremiere()
        {
            Premieres.Remove(SelectedPremiere);

            MessageBox.Show("Pomyślnie usunięto premierę.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
