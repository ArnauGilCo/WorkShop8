using System.Security.Cryptography.X509Certificates;

namespace WorkShop8
{
    public partial class Compilador : Form
    {
        public Compilador()
        {
            InitializeComponent();
        }

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

        private void Compiler_Click(object sender, EventArgs e)
        {
            string expressio = txt_Compiler.Text;
            bool validacio = Validar(expressio);
            if (validacio)
            {
                txt_Compiler.BackColor = Color.Green;
                txt_Compiler.Text = "Correcte";
            }
            else
            {
                txt_Compiler.BackColor = Color.Red;
                txt_Compiler.Text = "Erroni";
            }
        }
    }
}