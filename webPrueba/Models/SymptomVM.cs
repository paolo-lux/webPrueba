using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webPrueba.Models
{
    public class SymptomVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string SymptomName { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string SynptomDescription { get; set; }

        [Display(Name = "URL Imagen")]
        public string URLImage { get; set; }

        [Display(Name = "Medida Mínima")]
        public decimal Measure { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }
    }

}