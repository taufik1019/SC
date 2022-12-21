using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class ResponKeluhan
    {
        [Key]
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public Keluhan Keluhan { get; set; }
        [ForeignKey("Keluhan")]
        public int KeluhanId { get; set; }
        public string KeluhanMhs { get; set; }
        public string Respon { get; set; }
        
       


    }
}
