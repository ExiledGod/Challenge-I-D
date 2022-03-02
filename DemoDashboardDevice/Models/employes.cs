using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DemoDashboardDevice.Models
{
    public class employes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string rut { get; set; }
        public string company_name { get; set; }
        public string img_name { get; set; }
        public string img_ref_validator { get; set; } 
    }
}
        // la idea, es guardar la imagen como binario en la db para luego ser reconstruida y usada por el identificar biometrico cuando se haga una peticion de marcaje,
        // asi no hay que guardar la imagen y se puede descartar luego la usada en para el reconocimiento