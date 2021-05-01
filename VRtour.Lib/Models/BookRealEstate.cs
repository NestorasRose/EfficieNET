using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRtour.Lib.Models
{
    public class BookRealEstate : RealEstate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public ICollection<DateTime> BookedDates { get; set; }
    }
}
