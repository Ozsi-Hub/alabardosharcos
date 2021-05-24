using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alabardos.Abstractions
{
    public enum HarcosTipus
    {
        [Display(Name =  "Alabárdos")]
        Alabardos = 1,
        [Display(Name = "Lovag")]
        Lovag = 2,
        [Display(Name = "Íjjász")]
        Ijjasz = 3
    }
}
