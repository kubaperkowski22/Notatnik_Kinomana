﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.Models
{
    public class AllMovies
    {
        [JsonProperty("AllMovies")]
        public ObservableCollection<Movie> Movies { get; set; }

        public AllMovies()
        {
            Movies = new ObservableCollection<Movie>();
        }
    }
}
