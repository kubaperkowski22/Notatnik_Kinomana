using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.Helpers
{
    public enum EMovieCategory
    {
        [Description("Brak")]
        Brak = 0,
        [Description("Film akcji")]
        Akcja = 1,
        [Description("Film animowany")]
        Animacja = 2,
        [Description("Film dokumentalny")]
        Dokument = 3,
        [Description("Film dramatyczny")]
        Dramat = 4,
        [Description("Film familijny")]
        Familijny = 5,
        [Description("Film fantasy")]
        Fantasy = 6,
        [Description("horror")]
        Horror = 7,
        [Description("Film komediowy")]
        Komedia = 8,
        [Description("Film romantyczny")]
        Romans = 9,
        [Description("Film Science-Fiction")]
        ScienceFiction = 10,
        [Description("Thriller")]
        Thriller = 11,
    }
}
