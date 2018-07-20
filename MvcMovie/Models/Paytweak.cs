using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAmiable.Models
{
    public class Paytweak
    {

        [StringLength(100)]
        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Le prénom est requis")]
        [Display(Name = "Prénom")]
        public string Prénom { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Le Téléphone est requis")]
        [Display(Name = "Portable")]
        public string Portable { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Le montant de la dette est requis")]
        [Display(Name = "Dette")]

        public string Dette { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Le texte du SMS est requis")]
        [Display(Name = "SMS")]
        public string SMS { get; set; }
            
    }
}
