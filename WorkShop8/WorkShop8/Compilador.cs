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
                txt_Compiler.Text = nomFitxer;

                TaulaLlista<string> TlString = new TaulaLlista<string>();
                bool validacio = true;
                int liniaError = -1;

                using (StreamReader sr = new StreamReader(nomFitxer))
                {
                    string linia;
                    while ((linia = sr.ReadLine()) != null)
                    {
                        TlString.Add(linia);
                    }
                }

                for (int i = 0; i < TlString.Count(); i++)
                {
                    if (!Validar(TlString[i]))
                    {
                        validacio = false;
                        liniaError = i + 1; // línies comencen en 1
                        break;
                    }
                }

                if (validacio)
                {
                    txt_Compiler.BackColor = Color.Green;
                }
                else
                {
                    txt_Compiler.BackColor = Color.Red;
                    MessageBox.Show($"Error de validació a la línia {liniaError}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string expressio = txtExpressio.Text;
                int resultat = AvaluarPostfix(expressio);
                lblResultat.Text = "Resultat: " + resultat.ToString();
            }
            catch (Exception ex)
            {
                lblResultat.Text = "Error: " + ex.Message;
            }
        }

        private int AvaluarPostfix(string expressio)
        {
            Pila<int> pila = new Pila<int>();
            string[] tokens = expressio.Trim().Split(' ');

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int nombre))
                {
                    pila.Push(nombre);
                }
                else
                {
                    int operand2 = pila.Pop();
                    int operand1 = pila.Pop();
                    int resultat;

                    switch (token)
                    {
                        case "+":
                            resultat = operand1 + operand2;
                            break;
                        case "-":
                            resultat = operand1 - operand2;
                            break;
                        case "*":
                            resultat = operand1 * operand2;
                            break;
                        case "/":
                            resultat = operand1 / operand2;
                            break;
                        default:
                            throw new InvalidOperationException("Operador invàlid: " + token);
                    }

                    pila.Push(resultat);
                }
            }

            return pila.Pop();
        }
    }
}
    