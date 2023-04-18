using System.Drawing;

namespace proyectoCalculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calculadora_KeyPress);
            this.KeyDown += new KeyEventHandler(Calculadora_KeyDown);
        }

        List<char> operadores = new List<char>();
        List<dynamic> numeros = new List<dynamic>();
        string? numero = null;
        int numInt;
        double numDec;

        private void BotonPunto_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(",");
            CambioTextoRichTextBox();
        }
        private void BotonCero_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("0");
            CambioTextoRichTextBox();
        }

        private void BotonUno_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("1");
            CambioTextoRichTextBox();
        }

        private void BotonDos_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("2");
            CambioTextoRichTextBox();
        }

        private void BotonTres_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("3");
            CambioTextoRichTextBox();
        }

        private void BotonCuatro_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("4");
            CambioTextoRichTextBox();
        }

        private void BotonCinco_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("5");
            CambioTextoRichTextBox();
        }

        private void BotonSeis_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("6");
            CambioTextoRichTextBox();
        }

        private void BotonSiete_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("7");
            CambioTextoRichTextBox();
        }

        private void BotonOcho_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("8");
            CambioTextoRichTextBox();
        }

        private void BotonNueve_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("9");
            CambioTextoRichTextBox();
        }

        private void BotonSuma_Click(object sender, EventArgs e)
        {
            Operacion('+');
        }

        private void BotonResta_Click(object sender, EventArgs e)
        {
            Operacion('-');
        }

        private void BotonMultiplicacion_Click(object sender, EventArgs e)
        {
            Operacion('*');
        }

        private void BotonDivision_Click(object sender, EventArgs e)
        {
            Operacion('/');
        }

        private void BotonIgual_Click(object sender, EventArgs e)
        {
            if (numeros.Count == 0)
            {
                richTextBox1.Clear();
            }
            else
            {
                AdicionNumeros();
                foreach (var i in numeros)
                {
                    Console.WriteLine(i);
                }
                double resultado = numeros[0];

                for (int i = 0; i < operadores.Count; i++)
                {

                    try
                    {
                        switch (operadores[i])
                        {
                            case '+':
                                resultado += numeros[i + 1];
                                break;
                            case '-':
                                resultado -= numeros[i + 1];
                                break;
                            case '*':
                                resultado *= numeros[i + 1];
                                break;
                            case '/':
                                resultado /= numeros[i + 1];
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                numeros.Clear();
                operadores.Clear();
                richTextBox1.Text = resultado.ToString();
                CambioTextoRichTextBox();
            }

        }

        private void BotonC_Click(object sender, EventArgs e)
        {
            numeros.Clear();
            operadores.Clear();
            richTextBox1.Clear();
        }

        private void BotonCE_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Operacion(char operador)
        {
            if (richTextBox1.Text.Length > 0)
            {
                operadores.Add(operador);
                AdicionNumeros();
            }
        }

        private void AdicionNumeros()
        {
            numero = richTextBox1.Text;
            if (int.TryParse(numero, out numInt))
            {
                numeros.Add(numInt);
            }
            else if (double.TryParse(numero, out numDec))
            {
                numeros.Add(numDec);
            }
            richTextBox1.Clear();
        }

        private void CambioTextoRichTextBox()
        {
            int width = richTextBox1.Width;
            int height = richTextBox1.Height;
            int heightB = richTextBox1.Height;
            int fontHeight = (int)richTextBox1.Font.GetHeight();

            Font font = new Font("Microsoft Sans Serif", 50F, FontStyle.Bold, GraphicsUnit.Point);

            SizeF size = richTextBox1.CreateGraphics().MeasureString(richTextBox1.Text, font);

            if (size.Width > width || size.Height > height)
            {

                float fontScale = Math.Min(width / size.Width, height / size.Height);
                float fontSize = font.Size * fontScale;


                font = new Font(font.FontFamily, fontSize, font.Style);

            }
            richTextBox1.Font = font;
        }

        private void Calculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    BotonCero_Click(null, null);
                    break;
                case '1':
                    BotonUno_Click(null, null);
                    break;
                case '2':
                    BotonDos_Click(null, null);
                    break;
                case '3':
                    BotonTres_Click(null, null);
                    break;
                case '4':
                    BotonCuatro_Click(null, null);
                    break;
                case '5':
                    BotonCinco_Click(null, null);
                    break;
                case '6':
                    BotonSeis_Click(null, null);
                    break;
                case '7':
                    BotonSiete_Click(null, null);
                    break;
                case '8':
                    BotonOcho_Click(null, null);
                    break;
                case '9':
                    BotonNueve_Click(null, null);
                    break;
                case ',':
                case '.':
                    BotonPunto_Click(null, null);
                    break;
            }
        }

        private void Calculadora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                case Keys.Oemplus:
                    BotonSuma_Click(null, null);
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    BotonResta_Click(null, null);
                    break;
                case Keys.Multiply:
                    BotonMultiplicacion_Click(null, null);
                    break;
                case Keys.Divide:
                    BotonDivision_Click(null, null);
                    break;
                case Keys.Enter:
                    BotonIgual_Click(null, null);
                    break;
            }
        }
    }
}