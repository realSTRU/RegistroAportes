using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroAportes.Shared.Models
{
    public class Aportes
    {

        [Key]
        public int AporteId { get; set; }
        public DateTime Fecha_Aporte { get; set; }

        public int PersonaId { get; set; }

        public string Concepto { get; set; } = string.Empty;

        public double Monto { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> DetalleAporte { get; set; } = new List<AportesDetalle>();
        


    }

    public class AportesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int AporteId {get; set;}

        public int PersonaId {get; set;}

        public int TipoAporteId { get; set; }

        public double Valor { get; set; }

        

        
    }

   
}
