using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAportes.Shared.Models
{
    public class TipoAporte
    {
        public int TipoAporteId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public double Meta { get; set; }

        public double Logrado { get; set; }

    }
}
