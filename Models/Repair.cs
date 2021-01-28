using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ASProjekt.Models
{
    public partial class Repair
    {
        
        public int Id { get; set; }
        public int? CarsId { get; set; }
        public int? MechanicId { get; set; }
        [Required(ErrorMessage = "Wpisz to pole")]
        [StringLength(160)]
        public string NazwaNaprawy { get; set; }
        [Required(ErrorMessage = "Wpisz to pole")]
        [StringLength(160)]
        public string OpisNaprawy { get; set; }
        [Required(ErrorMessage = "Wpisz to pole")]
        [StringLength(160)]
        [DataType(DataType.Date)]
        public DateTime? DataNaprawy { get; set; }

        public virtual Car Cars { get; set; }
        public virtual Mechanic Mechanic { get; set; }
    }
}
