using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ASProjekt.Models
{
    public partial class Mechanic
    {
        public Mechanic()
        {
            Repairs = new HashSet<Repair>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Wpisz to pole")]
        [StringLength(160)]
        public string Imie { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
