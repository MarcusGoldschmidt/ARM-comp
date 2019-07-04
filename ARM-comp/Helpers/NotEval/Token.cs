namespace ARM_comp.Helpers.NotEval
{
    public class Token
    {
        public string Lexama { get; set; }

        enum Type
        {
            Number = 0,
            Operador = 1,
            Variavel = 2,
        }
    }
}