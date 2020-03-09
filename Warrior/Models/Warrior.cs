using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warrior.Models
{
    public class Warrior
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Warrior name")]
        public string WarriorName { get; set; }
        public string Race { get; set; }
        public string Skill { get; set; }
        public Weapon Weapon { get; set; }
    }
}
