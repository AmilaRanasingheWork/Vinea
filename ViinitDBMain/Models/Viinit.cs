using System;
using System.Collections.Generic;

namespace ViinitDBMain.Models
{
    public partial class Viinit
    {
        public int ViiniId { get; set; }
        public string Nimi { get; set; } = null!;
        public int Vuosi { get; set; }
        public int TyyppiId { get; set; }
        public string? Kommentit { get; set; }
        public decimal Hinta { get; set; }

        public virtual Viinityypit Tyyppi { get; set; } = null!;
    }
}
