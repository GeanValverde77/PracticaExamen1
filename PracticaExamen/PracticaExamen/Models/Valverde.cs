using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaExamen.Models
{
    public enum placeType
    {
        Burtown,
        Kiky,
        Macro,
        Upsa,
        PU
    }
    public class Valverde
    {
        [Key]
        public int ValverdeID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24,MinimumLength = 2 )]
        public string FriendofValverde { get; set; }
        [Required]
        public placeType Place { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}