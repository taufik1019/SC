using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SC.Models
{
    public class Campus
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        
        
        
    }
}
