
using System.ComponentModel.DataAnnotations;
namespace HospiEnCasa.App.Dominio
{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>   
    public class Persona
    {
        // Identificador único de cada persona
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        
        public string Apellidos { get; set; }
        [Display(Name = "Numero telefónico")]
        public string NumeroTelefono { get; set; }
        // Genero de la persona
        public Genero Genero { set; get; }

    }
}