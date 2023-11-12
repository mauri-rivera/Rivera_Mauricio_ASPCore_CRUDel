#pragma warning disable CS8618

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDel.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId { get; set; }

        [Required(ErrorMessage = "El nombre del plato es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El nombre del Chef es requerido")]
        public string Chef { get; set; }

        [Required]
        [ValidaCalorias]
        public int Calories { get; set; }

        [Required]
        public int Tastiness { get; set; } 

        [Required(ErrorMessage = "La descripción del plato es requerido")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}