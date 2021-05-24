using System.ComponentModel.DataAnnotations;

namespace HarcosApp.Abstractions
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
