using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class Expression
    {
        public Expression(string funcao)
        {
            Funcao = funcao;
        }
        
        private DataCell DataCell { set; get; }
        public string Funcao { get; set; }
    }
}