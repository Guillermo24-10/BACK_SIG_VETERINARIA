using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG_VETERINARIA.DTOs.DTOs.Tratamientos
{
    public class ProductsTratamientoCreateRequestDto
    {
        public int id {  get; set; }
        public int tratamiento_id { get; set; }
        public int product_id { get; set; }
    }
}
