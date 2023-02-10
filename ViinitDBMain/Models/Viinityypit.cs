using System;
using System.Collections.Generic;

namespace ViinitDBMain.Models
{
    public partial class Viinityypit
    {
        public Viinityypit()
        {
            Viinits = new HashSet<Viinit>();
        }

        public int TyyppiId { get; set; }
        public string Viinityyppi { get; set; } = null!;

        public virtual ICollection<Viinit> Viinits { get; set; }
    }
}
