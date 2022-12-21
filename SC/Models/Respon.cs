using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Respon
    {
        [Key]
        public int ResponId { get; set; }

        public DateTime TanggalRespon { get; set; }

        public string ResponKeluhan { get; set; }

        public Keluhan Keluhan { get; set; }

        [ForeignKey("Keluhan")]

        public int KeluhanId { get; set; } 

        public User User { get; set; }

        [ForeignKey("User")]
        //public int UserId { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
