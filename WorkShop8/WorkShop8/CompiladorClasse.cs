using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop8
{
    internal class CompiladorClasse
    {
        public bool Validar(string expressio)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expressio)
            {
                // Quan trobem un parèntesi, clau o corxet obert, el posem a la pila
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Quan trobem un parèntesi, clau o corxet tancat, validem amb el top de la pila
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Comprovem si la pila està buida o el top de la pila no coincideix amb el corresponent obert
                    if (pila.Count == 0)
                    {
                        return false;
                    }

                    char top = pila.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == '}' && top != '{') ||
                        (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }

            // Si la pila està buida al final, tots els parèntesis han estat balancejats
            return pila.Count == 0;
        }
    }
}
