using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevOpsTests.Models
{
    public class Veichle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Wheels { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
