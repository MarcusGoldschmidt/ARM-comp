using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class Analyzer
    {
        public List<string> BlocoGeracao(string data)
        {
            var aux = RemovePareteses(FormataString(data));
            ValidacaoString(aux);
            var tokens = Lexico(aux);
            tokens = AjustePrioridade(tokens);
            return tokens;
        }
        
        public string FormataString(string data)
        {
            var aux = data.Replace(" ", ""); 
            return aux.Replace("E","*10^");
        }
        
        public string RemovePareteses(string data)
        {
            if (data[0] != '(') return data;
            var insideBlock = 0;

            for (var j = 0; j < data.Length; j++)
            {
                if (data[j] == '(')
                    insideBlock++;

                if (data[j] != ')' && insideBlock == 0) break;

                if (data[j] != ')') continue;
                insideBlock--;
                if (j == data.Length - 1)
                {
                    return data.Substring(1, data.Length - 2);
                }
            }

            return data;
        }
        
        public List<string> Lexico(string data)
        {
            var tokens = new List<string>();

            for (var i = 0; i < data.Length; i++)
            {
                // Gambiarra
                if (i == 0 && data[i] == '-')
                {
                    var aux = "-"+BlocoDecimal(data.Substring(i+1));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                    continue;
                }

                if (data[i] == 'e')
                {
                    tokens.Add(data[i].ToString());
                    continue;
                }

                if (data[i] == '(')
                {
                    var aux = BlocoParenteses(data.Substring(i));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                    continue;
                }
                
                if (TokenList.IsDecimal(data[i]))
                {
                    var aux = BlocoDecimal(data.Substring(i));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                    continue;
                }
                if (TokenList.IsLetterAndNotX(data[i]))
                {
                    var aux = BlocoFuncao(data.Substring(i));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                    continue;
                }
                
                // TODO: Verificar quando o valor é negativo
                tokens.Add(data[i].ToString());
                if (TokenList.IsOperators(data[i].ToString())
                    && data[i + 1] == '-')
                {
                    var aux = data[++i].ToString();
                    aux = $"{aux}{BlocoDecimal(data.Substring(i + 1))}";
                    tokens.Add(aux);
                    i += aux.Length - 1;
                }
            }

            return tokens;
        }
        
        public List<string> AjustePrioridade(List<string> lexemas)
        {
            var newList = new List<string>();

            // Funcao Trigonometrica
            // Primeira letra do primeiro lexema
            if (lexemas.Count == 1 && 
                TokenList.IsLetterAndNotX(lexemas[0][0]) &&
                !TokenList.IsConstants(lexemas[0][0].ToString()))
            {
                var interator = 0;
                while (TokenList.IsLetterAndNotX(lexemas[0][interator]))
                {
                    interator++;
                }

                newList.Add(lexemas[0].Substring(0, interator));
                var blocoInterno = lexemas[0].Substring(interator);
                newList.Add(blocoInterno.Substring(1, blocoInterno.Length - 2));

                return newList;
            }

            // Quando valor é negativo
            if (lexemas.Count == 2 && lexemas[0] == "-")
            {
                var retoro = $"{lexemas[0]}{lexemas[1]}";
                newList.Add(retoro);
                return newList;
            }

            if (lexemas.Count == 3 || lexemas.Count == 1)
            {
                return lexemas;
            }

            // TODO: Essa parte tem que arrumar para cada novo operador de prioridade maior tem que
            // Colocar um for aumentado com o if da confição
            // Então fixme

            // Procura prioridade
            for (var i = 1; i < lexemas.Count; i++)
            {
                if (TokenList.IsSpecialPreferenceOperators(lexemas[i]))
                {
                    var bloco = $"{lexemas[i - 1]}{lexemas[i]}{lexemas[i + 1]}";
                    lexemas[i - 1] = bloco;
                    lexemas.RemoveAt(i);
                    lexemas.RemoveAt(i);
                }
            }

            // Procura prioridade
            for (var i = 1; i < lexemas.Count; i++)
            {
                if (TokenList.IsPrecedenceOperators(lexemas[i]) && lexemas.Count > 3)
                {
                    var bloco = $"{lexemas[i - 1]}{lexemas[i]}{lexemas[i + 1]}";
                    lexemas[i - 1] = bloco;
                    lexemas.RemoveAt(i);
                    lexemas.RemoveAt(i);
                }
            }

            newList.Add(lexemas[0]);
            newList.Add(lexemas[1]);
            var aux = "";
            for (var i = 2; i < lexemas.Count; i++)
            {
                aux += lexemas[i];
            }

            newList.Add(aux);

            return newList;
        }
        
        public string BlocoParenteses(string data)
        {
            var block = 0;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                    block++;

                if (data[i] == ')')
                    block--;

                if (block == 0)
                {
                    block = i;
                    break;
                }
            }

            return data.Substring(0, block + 1);
        }
        
        public string BlocoDecimal(string data)
        {
            var i = 0;
            while (TokenList.IsDecimal(data[i]))
            {
                i++;
                if (i == data.Length)
                {
                    break;
                }
            }

            return data.Substring(0, i);
        }
        
        public void ValidacaoString(string data)
        {
            if (data.Any(e => e == '(' || e == ')'))
            {
                var abriu = data.Count(e => e == '(');
                var fechou = data.Count(e => e == ')');
                if (abriu - fechou != 0)
                {
                    throw new Exception("Formatação errada");
                }
            }
        }
        
        public string BlocoFuncao(string data)
        {
            var aux = 0;
            while (TokenList.IsLetterAndNotX(data[aux]))
            {
                aux++;
            }

            var block = 0;
            for (var i = aux; i < data.Length; i++)
            {
                if (data[i] == '(')
                    block++;

                if (data[i] == ')')
                    block--;

                if (block == 0)
                {
                    block = i;
                    break;
                }
            }

            var let = data.Substring(0, block + 1);
            return let;
        }

    }
}