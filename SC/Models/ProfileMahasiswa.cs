using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class ProfileMahasiswa
    {
        [Key]

        public int ProfileMahasiswaId { get; set; }

        public int StudentId { get; set; }

        public string Prodi { get; set; }

        public int Semester { get; set; }
        public DateTime TanggalLahir { get; set; }

        public string Alamat { get; set; }


    }
}
