using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Campus")]
        public int Id { get; set; }
        public string Password { get; set; }
       
        public Campus Campus { get; set; }
        
        
     
       
    }
}
