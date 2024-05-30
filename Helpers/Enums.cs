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
        Brak,
        [Description("Film akcji")]
        Akcja,
        [Description("Film animowany")]
        Animacja,
        [Description("Film dokumentalny")]
        Dokument,
        [Description("Film dramatyczny")]
        Dramat,
        [Description("Film familijny")]
        Familijny,
        [Description("Film fantasy")]
        Fantasy,
        [Description("horror")]
        Horror,
        [Description("Film komediowy")]
        Komedia,
        [Description("Film romantyczny")]
        Romans,
        [Description("Film Science-Fiction")]
        ScienceFiction,
        [Description("Thriller")]
        Thriller,
    }
}
