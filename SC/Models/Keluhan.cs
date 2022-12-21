using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Keluhan
    {
        [Key]
        public int KeluhanId { get; set; }

        public DateTime TanggalKeluhan { get; set; }

        public string KeluhanMahasiswa { get; set; }
        
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
