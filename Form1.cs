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

        private List<Orszag> eredetiLista = new List<Orszag>();

        private void button_Betoltes_Click(object sender, EventArgs e)
        {
            listBox_Orszagok.Items.Clear();
            openFileDialog1.Filter = "Vesszővel elválasztott szövegfájl (*.csv)|*.csv|Text fájlok (*.txt)|*.txt|Minden fájl|*.*";
            openFileDialog1.Title = "Országok betöltése";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.FileName = "orszagok.csv";
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
            //Készítek egy biztonsági mentést, ha helyre kell állítani a listát
            eredetiLista.Clear();
            eredetiLista.AddRange(listBox_Orszagok.Items.Cast<Orszag>());
            button_Helyreallit.Enabled = true;
            button_Betoltes.Enabled = false;
            button_Betoltes.Text = "Betöltve";
        }

        private void button_Teruletek_Click(object sender, EventArgs e)
        {
            if (listBox_Orszagok.Items.Count != 0)
            {
                //Kiszámolja az átlag területet
                double osszesTerulet = 0;
                int orszagokSzama = 0;
                foreach (Orszag orszag in listBox_Orszagok.Items)
                {
                    osszesTerulet += orszag.Terulet;
                    orszagokSzama++;
                }
                double teruletEredmeny = osszesTerulet / orszagokSzama;

                //kiírja az átlag területet
                string kiirtEredmeny = teruletEredmeny.ToString("N2");
                string osszTerulet = osszesTerulet.ToString("N2");
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.Add($"Országok száma: {orszagokSzama}");
                listBox_Orszagok.Items.Add($"Összes terület: {osszTerulet}");
                listBox_Orszagok.Items.Add($"Átlagos terület: {kiirtEredmeny}");
            }
            else
            {
                MessageBox.Show("Először töltse be a forrásfájlt!");
            }
            
        }

        private void button_Helyreallit_Click(object sender, EventArgs e)
        {
            if (eredetiLista.Count !=0 )
            {
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(eredetiLista.ToArray());
            }
            else 
            {
                MessageBox.Show("Először töltse be az eredeti forrásfájlt!");
            }
        }
    }
}
