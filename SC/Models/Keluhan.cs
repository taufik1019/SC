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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prodi { get; set; }
        public DateTime Tanggal { get; set; }
        public string KeluhanMhs { get; set; }
    }
}
