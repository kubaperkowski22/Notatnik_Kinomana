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
        None,
        [Description("Film akcji")]
        Action,
        [Description("Film animowany")]
        Animated,
        [Description("Film dokumentalny")]
        Documentary,
        [Description("Film dramatyczny")]
        Drama,
        [Description("Film fantasy")]
        Fantasy,
        [Description("horror")]
        Horror,
        [Description("Film komediowy")]
        Comedy,
        [Description("Film romantyczny")]
        Romance,
        [Description("Film Science-Fiction")]
        Scifi,
        [Description("Thriller")]
        Thriller,
    }
}
