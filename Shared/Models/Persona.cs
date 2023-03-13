using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace RegistroAportes.Shared.Models
{
    public class Persona
    {
        [Key]

        public int PersonaId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Celular { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

        public double Total_Aportado { get; set; }

        public DateOnly Fecha_Nacimiento { get; set; }
        



        

    }
}
