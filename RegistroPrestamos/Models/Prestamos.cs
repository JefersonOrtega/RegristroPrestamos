using RegistroPrestamos.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamos.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="Es obligatorio introducir la fecha")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el nombre de la Persona a que se presta")]
        public string NombrePersona { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el concepto")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir el balance")]
        public decimal Balance { get; set; }



        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalle { get; set; } = new List<MorasDetalle>();


    }
}
