using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Warrior.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        [Display(Name = "Weapon")]
        public string Name { get; set; }
        public int Power { get; set; }
        public string Status { get; set; }
        public ICollection<Warrior> Warriors { get; set; }
    }
}
