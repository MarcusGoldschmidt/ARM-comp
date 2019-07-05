using System.ComponentModel.DataAnnotations;

namespace ARM_comp.Models
{
    public class Ponto
    {
        [Required] public double A { get; set; }

        [Required] public double B { get; set; }
    }
}