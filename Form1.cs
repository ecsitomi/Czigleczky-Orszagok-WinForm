﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Objektum listák amiket később használunk majd
        private List<Orszag> eredetiLista = new List<Orszag>(); //helyreállításhoz
        private List<Orszag> nagyobbMintSzaz = new List<Orszag>(); //nagy területű országok listája
        private List<Orszag> kisebbMintSzaz = new List<Orszag>(); //kisterületű országok listája
        private List<Orszag> vizsgaltLista = new List<Orszag>(); //min-maxnál kell, hogy ne kelljen mindig helyreállítani ha mind a két értéket keresem

        private void button_Betoltes_Click(object sender, EventArgs e) //fájl betöltés
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

        private void OrszagokBeolvasasa(string forrasFajl) //betöltött fájl beolvasása a listaBoxba
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
            //Bekapcsolom a kikapcsolt gombokat
            button_Betoltes.Enabled = false;
            button_Betoltes.Text = "Betöltve";
            button_Helyreallit.Enabled = true;
            button_Megszamolas.Enabled = true;
            button_Kereses.Enabled = true;
            comboBox_MinMax.Enabled = true;
        }

        //ListBoxban szereplő országok átlag terület kiszámítása
        private void button_Teruletek_Click(object sender, EventArgs e) 
        {
            comboBox_MinMax.Enabled = false; //átlagban nincs min max, itt kikapcsolom ezt a funkciót

            double osszesTerulet = 0;
            int orszagokSzama = 0;
            double teruletEredmeny = 0;
            if (listBox_Orszagok.Items.Count != 0)
            {
                //Kiszámolja az átlag területet
                foreach (Orszag orszag in listBox_Orszagok.Items)
                {
                    osszesTerulet += orszag.Terulet;
                    orszagokSzama++;
                }
                teruletEredmeny = osszesTerulet / orszagokSzama;

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
                MessageBox.Show("Először töltse be a forrásfájlt!"); //Ha nincs mit kiszámolni
            }
            
        }
        //Helyreállítja a listBox-ot az eredeti listára
        private void button_Helyreallit_Click(object sender, EventArgs e)
        {
            comboBox_MinMax.Enabled = true; //ezt sajnos mindenhol be kell kapcsolnom külön-külön

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

        //Szétválogatja az országokat nagyság szerint
        private void button_Megszamolas_Click(object sender, EventArgs e)
        {
            comboBox_MinMax.Enabled = true;

            listBox_Orszagok.Items.Clear(); 
            nagyobbMintSzaz.Clear();
            kisebbMintSzaz.Clear();
            //Azért kell törölni mert több listázás összadná őket a terület listákban és hibás
            //eredményt adna ha területet számolnék
            foreach (Orszag orszag in eredetiLista)
            {
                if (orszag.Terulet > 100000)
                {
                    nagyobbMintSzaz.Add(orszag);
                }
                else 
                {
                    kisebbMintSzaz.Add(orszag);  
                }
            }
            //Itt meg kiíratja a kiválasztott nagyság szerint
            if (radioButton_100_Nagyobb.Checked)
            {
                listBox_Orszagok.Items.AddRange(nagyobbMintSzaz.ToArray());
            }
            else 
            {
                listBox_Orszagok.Items.AddRange(kisebbMintSzaz.ToArray());
            }
        }

        //Legkisebb-legnagyobb ország kiválasztása a listából
        private void comboBox_MinMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Teruletek.Enabled = false; //felesleges funkció itt
            
            double legkisebb = double.MaxValue;
            double legnagyobb = 0;
            Orszag legkisebbOrszag = null;
            Orszag legnagyobbOrszag = null;

            //Itt azt próbálom hogy mind a két értéket megkapjuk helyreállítás gomb nélkül
            if (listBox_Orszagok.Items.Count < 2)
            {
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(vizsgaltLista.ToArray());
            }
            else
            { 
                vizsgaltLista.Clear();
                vizsgaltLista.AddRange(listBox_Orszagok.Items.Cast<Orszag>());
            }
            foreach (Orszag orszag in listBox_Orszagok.Items)
            {
                //vizsgaltLista.Add(orszag);
                if (orszag.Terulet < legkisebb) 
                {
                    legkisebb = orszag.Terulet;
                    legkisebbOrszag = orszag;
                }
                if (orszag.Terulet > legnagyobb)
                {
                    legnagyobb = orszag.Terulet;
                    legnagyobbOrszag = orszag;
                }
            }
            listBox_Orszagok.Items.Clear();
            if (comboBox_MinMax.SelectedIndex == 0)
            {
                listBox_Orszagok.Items.Add(legkisebbOrszag);
            }
            else 
            {
                listBox_Orszagok.Items.Add(legnagyobbOrszag);
            } //Sikerült :)
        }
    }
}
