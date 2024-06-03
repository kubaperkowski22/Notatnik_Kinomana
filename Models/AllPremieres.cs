using Newtonsoft.Json;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.Models
{
    public class AllPremieres
    {
        [JsonProperty("AllPremieres")]
        public ObservableCollection<Premiere> Premieres { get; set; }

        public AllPremieres()
        {
            Premieres = new ObservableCollection<Premiere>();
        }
    }
}
