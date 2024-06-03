using Notatnik_Kinomana_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class SettingsPageVM
    {
        public AllMovies AllMovies { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public AllPremieres AllPremieres { get; set; }
        public ObservableCollection<Premiere> Premieres { get; set; }
        public SettingsPageVM(AllMovies allMovies, AllPremieres allPremieres)
        {
            AllMovies = allMovies;
            AllPremieres = allPremieres;
            Movies = allMovies.Movies;
            Premieres = allPremieres.Premieres;
        }
    }
}
