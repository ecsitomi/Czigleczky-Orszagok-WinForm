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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Betoltes_Click(object sender, EventArgs e)
        {
            listBox_Orszagok.Items.Clear();
            openFileDialog1.Filter = "Vesszővel elválasztott szövegfájl (*.csv)|*.csv|Text fájlok (*.txt)|*.txt|Minden fájl|*.*";
            openFileDialog1.Title = "Országok betöltése";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            //openFileDialog1.FileName = "orszagok.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OrszagokBeolvasasa(openFileDialog1.FileName);

            }
        }

        private void OrszagokBeolvasasa(string forrasFajl)
        {
            using (StreamReader sr = new StreamReader(forrasFajl))
            {
                sr.ReadLine();
                while (!sr.EndOfStream) 
                {
                    string[] sor = sr.ReadLine().Split(';');
                    listBox_Orszagok.Items.Add(new Orszag(sor[0], Convert.ToDouble(sor[1].Replace(".",","))));
                }
            }
        }
    }
}
