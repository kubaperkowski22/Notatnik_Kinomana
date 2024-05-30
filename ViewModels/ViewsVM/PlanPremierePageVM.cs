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

        public PlanPremierePageVM(AllPremieres premieres)
        {
            AllPremieres = premieres;
            Premieres = premieres.Premieres;
        }

        public void AddPremiere(string title, EMovieCategory category, DateTime date, bool watched)
        {
            Premieres.Add(new Premiere(title, category, date, watched));

            MessageBox.Show("Pomyślnie dodano premierę.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);

            OnPropertyChanged(nameof(Premieres));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
