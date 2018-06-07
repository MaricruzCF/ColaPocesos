using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColaProcesos
{
    public partial class Form1 : Form
    {
        Random random = new Random(DateTime.Now.Millisecond);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Proceso();
        }

        string Proceso()
        {
            Cola cola = new Cola();

            int ciclosVacia = 0;
            int procesosTerminados = 0;
            int procesosFaltantes = 0;
            int ciclosFaltantesProcesos = 0;

            for (int i = 0; i < 300; i++)
            {
                if (random.Next(1,101) <= 35)
                {
                    cola.Encolar(new Proceso());
                }

                if (!cola.EstaVacia())
                {
                    Proceso process = cola.Ver();
                    process.Ciclos--;
                    if (process.Ciclos == 0)
                    {
                        procesosTerminados++;
                        cola.Desencolar();
                    }
                }
                else
                    ciclosVacia++;
            }

            Proceso temp = cola.Desencolar();
            while (temp != null)
            {
                procesosFaltantes++;
                ciclosFaltantesProcesos += temp.Ciclos;
                temp = cola.Desencolar();
            }

            return "Ciclos lista vacia   " + ciclosVacia + Environment.NewLine+
                "Procesos Terminados   "+procesosTerminados+Environment.NewLine+
                "Procesos faltantes  "+procesosFaltantes+Environment.NewLine+
                "Ciclos faltantes   "+ciclosFaltantesProcesos+Environment.NewLine;
        }

        
    }
}
