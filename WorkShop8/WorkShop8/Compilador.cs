using System.Linq;
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
            }
            else
            {
                txt_Compiler.BackColor = Color.Red;
            }
        }

        private void CompilerFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Fitxers de text (*.txt)|*.txt|Tots els fitxers (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomFitxer = openFileDialog1.FileName;
                txt_Compiler.Text = nomFitxer; // Mostrar ruta al TextBox

                TaulaLlista<string> TlString = new TaulaLlista<string>();
                bool validacio = true;

                // Llegim el fitxer i omplim la TaulaLlista
                using (StreamReader sr = new StreamReader(nomFitxer))
                {
                    string linia;
                    while ((linia = sr.ReadLine()) != null)
                    {
                        TlString.Add(linia);
                    }
                }

                // Validem totes les línies
                for (int i = 0; i < TlString.Count(); i++)
                {
                    if (!Validar(TlString[i]))
                    {
                        validacio = false;
                        break;
                    }
                }

                // Canviem el color del TextBox segons si ha passat o no la validació
                txt_Compiler.BackColor = validacio ? Color.Green : Color.Red;
            }
        }
    }
}