using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers.NotEval{
    public class DataCell{

        public DataCell(string expresion){
            // Retirando espacos vazios
            var format = FormatExpression(expresion);
            initCell(format);
        }

        public string Value { get; set; }
        
        public string Operation { get; set; }
        
        public DataCell Left { set; get; }
        
        public DataCell Right { set; get; }

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

            if (Operation == "*" || Operation == "/")
            {
                
            }else{
                this.Left = new DataCell(Left);
                this.Right = new DataCell(Right);
            }
        }

        private string FormatExpression(string expresion)
        {
            var aux = expresion.Replace(" ", "");
            var tokeList = new List<Token>();
            var response = "";

            while (aux.Length > 0)
            {
                var bloco = ParentesisBlock(aux);
                var token = new Token(bloco);
                tokeList.Add(token);
                aux = aux.Substring(bloco.Length);
            }
            
            // Formatar para a ordem dos * e /
            for (int i = 0; i < tokeList.Count - 1; i++)
            {
                if (tokeList[i].ContainsSpecialOperator)
                {
                    response = string.Concat(response,"(");
                    response = string.Concat(response,tokeList[i].Expresion);
                    response = string.Concat(response,tokeList[++i].Expresion);
                    response = string.Concat(response,")");
                }else{
                    response = string.Concat(response,tokeList[i].Expresion);
                }
            }
            return tokeList.ToString();
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

        private string ParentesisBlock(string block)
        {
            var count = 0;
            var aux = block;
            var endBlock = block.Length;
            var startBlock = 0;

            if (aux[0] != '(')
            {

                if (new TokenList().Operators.Contains(aux[0].ToString()))
                {
                    return aux.Substring(0, 2);
                }

                try
                {
                    return aux[0] + aux[1].ToString();
                }
                catch (Exception e)
                {
                    return aux[0].ToString();
                }
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
            
            // Definindo bloco coom o '(' and ')'
            aux = "";
            for (var i = startBlock; i <= endBlock + 1; i++)
            {
                aux += block[i].ToString();
            }

            return aux;
        }
    }
}