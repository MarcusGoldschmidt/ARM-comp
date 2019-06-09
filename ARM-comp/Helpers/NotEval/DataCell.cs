namespace ARM_comp.Helpers.NotEval{
    public class DataCell{

        public DataCell(string expresion){
            // Retirando espacos vazios
            var format = expresion.Replace(" ","");
            initCell(format);
        }

        private string Value { get; set; }
        
        private string Operation { get; set; }
        
        private DataCell Left { set; get; }
        
        private DataCell Right { set; get; }

        private void initCell(string expresion){
            if (expresion.Length == 1)
            {
                Value = expresion;
            }else{
                Tokeninze(expresion);
            }
        }

        private void Tokeninze(string expresion){
            var aux = expresion;
            
            var Left = DefineComandBlock(aux);
            string Right;
            
            if (aux[0] == '(')
            {   
                Operation = aux[Left.Length + 2].ToString();
                Right = aux.Substring(Left.Length + 3,aux.Length -(Left.Length + 3));
            }
            else
            {
                Operation = aux[Left.Length].ToString();
                Right = aux.Substring(2);
            }
            
            // Tratando de é um bloco separado
            if (Right[0] == '(')
            {
                Right = Right.Substring(1,Right.Length - 2);
            }

            this.Left = new DataCell(Left);
            this.Right = new DataCell(Right);
        }

        // Definindo bloco sem o '(' ')'
        private string DefineComandBlock(string expresion){
            var count = 0;
            var aux = expresion;
            var startBlock = 0;
            var endBlock = expresion.Length;
            
            // Se o bloco estiver normal
            if (aux[0] != '(')
            {
                return aux.Substring(0, 1);
            }
            
            //Comeco e final do bloco
            for (var i = 0; i < aux.Length; i++)
            {
                if (aux[i] == '(') count++;

                if (aux[i] != ')') continue;
                
                count--;
                if (count != 0) continue;
                endBlock = i;
                break;

            }
            
            // Definindo bloco sem o '(' ')'
            aux = "";
            for (var i = startBlock + 1; i < endBlock; i++)
            {
                aux += expresion[i].ToString();
            }

            return aux;
        }
    }
}