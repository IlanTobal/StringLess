using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Binario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Reproducir(string nota, string octava)
        {
            // Funcion que reproduce las notas.
            Stream str = (Stream)Properties.Resources.ResourceManager.GetObject(nota.Replace("#", "S") + octava);
            SoundPlayer Sonido = new SoundPlayer(str);
            Sonido.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analizarArduino();
            /*
            string input = (txtValor.Text); //se guarda la informacion que le llega desde el arduino, en este caso lo qu3e recibe desde el textbox. 
            string[] notas = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };


            for (int l = 13; l < 17; l++)  
            {
                string laser = input.Substring(l, 1); // declara que laser fue interumpido 
                if (laser == "1")
                {
                    for (int i = 0; i < 13; i++)
                    {
                        string btn = input.Substring(i, 1); // declara que boton fue precionado 
                        if (btn == "1")
                        {
                            Reproducir(notas[i], (l-12).ToString()); //ejecuta la funcion 

                            MessageBox.Show(notas[i]+(l-12).ToString());
                        }
                    }
                }
            }*/
        }

        void analizarArduino ()
        {
            string input = (txtValor.Text);
            
            string[] notas = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            // int[] numeros = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            // string[] letrasCuerdas = { "E", "A", "D", "G" };
            int[] valoresCuerdas = { 4, 9, 3, 7 };

            List<int> presionados = new List<int>();

            for (int i = 0; i < 12; i++)
            {
                if (input[i] == '1') presionados.Add(i+1);
            }

            for (int i = 12; i < 16; i++)
            {
                if (input[i] == '1')
                {
                    int valorCuerda = i - 12;
                    int numeroSonido = valoresCuerdas[valorCuerda];

                    bool toqueAlguna = false;

                    foreach (int presionado in presionados)
                    {
                 
                        toqueAlguna = true;
                        numeroSonido += presionado;
                        Reproducir(notas[numeroSonido % 12], (numeroSonido / 12 + 1).ToString());
                        MessageBox.Show(notas[numeroSonido % 12] + (numeroSonido / 12 + 1).ToString());

                        // 1000000000001000
                    }

                    if (!toqueAlguna)
                    {
                        Reproducir(notas[valoresCuerdas[valorCuerda]], (numeroSonido / 12 + 1).ToString());
                        MessageBox.Show(notas[valoresCuerdas[valorCuerda]] + (numeroSonido / 12 + 1).ToString());
                    }
                }
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
