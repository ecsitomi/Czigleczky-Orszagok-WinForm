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

        private void textbox_ForrasFajl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                openFileDialog1.FileName = "orszagok.csv";
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
            button_Teruletek.Enabled = true;
            button_Csokkeno.Enabled = true;
            button_Novekvo.Enabled = true;
            button_Helyreallit.Enabled = true;
            button_Megszamolas.Enabled = true;
            button_Kiiras.Enabled = true;
            button_Kereses.Enabled = true;
            comboBox_MinMax.Enabled = true;
            textBox_KeresendoOrszag.Enabled = true;
        }

        //ListBoxban szereplő országok átlag terület kiszámítása
        private void button_Teruletek_Click(object sender, EventArgs e) 
        {
            comboBox_MinMax.Enabled = false; //átlagban nincs min max, itt kikapcsolom ezt a funkciót
            //button_Kereses.Enabled = false; //szintén felesleges
                                              //vagy mégsem, mert a vizsgált lista visszaállítható
            button_Csokkeno.Enabled = false;
            button_Novekvo.Enabled = false;

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
            button_Kereses.Enabled = true; //ezt is
            button_Teruletek.Enabled = true;
            button_Csokkeno.Enabled = true;
            button_Novekvo.Enabled = true;

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
            button_Kereses.Enabled = true;
            button_Teruletek.Enabled = true;
            button_Csokkeno.Enabled = true;
            button_Novekvo.Enabled = true;

            listBox_Orszagok.Items.Clear();
            vizsgaltLista.Clear();
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
                vizsgaltLista.AddRange(nagyobbMintSzaz.ToArray());
            }
            else 
            {
                listBox_Orszagok.Items.AddRange(kisebbMintSzaz.ToArray());
                vizsgaltLista.AddRange(kisebbMintSzaz.ToArray());
            }
        }

        //Legkisebb-legnagyobb ország kiválasztása a listából
        private void comboBox_MinMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Teruletek.Enabled = false; //felesleges funkció itt
            button_Kereses.Enabled = true; //ez viszont kellhet mert betölti az előző listát a kereséshez
            button_Csokkeno.Enabled = false;
            button_Novekvo.Enabled = false;

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
                //vizsgaltLista.Add(orszag); //foreachben is hozzáadhatnám, de duplán adná hozzá
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
            } 
        }

        //Keresés
        private void button_Kereses_Click(object sender, EventArgs e)
        {
            string beirtSzoveg = textBox_KeresendoOrszag.Text.Trim().ToLower(); //levágja a spacet és kisbetűssé teszi
            
            button_Teruletek.Enabled = true;
            button_Csokkeno.Enabled = true;
            button_Novekvo.Enabled = true;

            Orszag eredmeny = null;
            List<Orszag> talalatLista = new List<Orszag>();

            if (listBox_Orszagok.Items.Count < 2 || listBox_Orszagok.Items[0] is string) //ha még min-maxban lenne
            {
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(vizsgaltLista.ToArray());
            }

            if (beirtSzoveg == null) //ha nem ír be semmit
            {
                MessageBox.Show("Szöveg megadása kötelező");
            }

            if (!checkBox_PontosTalalat.Checked) //nem pontos keresés esetén
            {

                foreach (Orszag orszag in listBox_Orszagok.Items)
                {
                    if (orszag.Orszagnev.Trim().ToLower().Contains(beirtSzoveg))
                    {
                        eredmeny = orszag;
                        talalatLista.Add(orszag);
                    }
                }
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(talalatLista.ToArray());
            }
            else //pontos keresés esetén
            {
                foreach (Orszag orszag in listBox_Orszagok.Items)
                {
                    if (orszag.Orszagnev.Trim().ToLower()==beirtSzoveg.Trim().ToLower())
                    {
                        eredmeny = orszag;
                        talalatLista.Add(orszag);
                    }
                }
                if (eredmeny == null)
                {
                    MessageBox.Show("Nincs találat!");
                }
                else 
                {
                    listBox_Orszagok.Items.Clear();
                    listBox_Orszagok.Items.AddRange(talalatLista.ToArray());
                }
            }
            textBox_KeresendoOrszag.Clear();
        }
        //Keresés indítása enter leütéssel
        private void textBox_KeresendoOrszag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button_Kereses_Click(sender, e);
            }
        }

        //Fájlba mentés - segített a chatGPT kicsit
        private void button_Kiiras_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Szövegfájl (*.txt)|*.txt|Vesszővel elválasztott dokumentum (*.csv)|*.csv|Minden fájl|*.*";
            saveFileDialog1.Title = "Mentés mint";
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.FileName = "eredmeny.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        foreach (var item in listBox_Orszagok.Items)
                        {
                            if (item is Orszag orszag)
                            {
                                string sor = $"{orszag.Orszagnev};{orszag.Terulet}";
                                sw.WriteLine(sor);
                            }
                            if (item is string stringValue) //átlag terület miatt
                            { 
                                sw.WriteLine (stringValue);
                            }
                        }
                    }

                    MessageBox.Show("Mentés sikeres!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");
                }
            }
        }

        //Csökkenő - Növekvő sorrend
        private void button_Csokkeno_Click(object sender, EventArgs e)
        {
            if (listBox_Orszagok.Items.Count > 1 && listBox_Orszagok.Items[0] is Orszag)
            {
                vizsgaltLista = listBox_Orszagok.Items.Cast<Orszag>().ToList(); //listBoxbol Ország lista lesz
                vizsgaltLista = vizsgaltLista.OrderByDescending(o => o.Terulet).ToList(); //csökkenő sorrend
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(vizsgaltLista.ToArray()); //kiíratás
            }
            else
            {
                MessageBox.Show("Az elemek típusa nem megfelelő");
            }
        }

        private void button_Novekvo_Click(object sender, EventArgs e)
        {
            if (listBox_Orszagok.Items.Count > 1 && listBox_Orszagok.Items[0] is Orszag)
            {
                vizsgaltLista = listBox_Orszagok.Items.Cast<Orszag>().ToList();
                vizsgaltLista = vizsgaltLista.OrderBy(o => o.Terulet).ToList(); //növekvő
                listBox_Orszagok.Items.Clear();
                listBox_Orszagok.Items.AddRange(vizsgaltLista.ToArray());
            }
            else
            {
                MessageBox.Show("Az elemek típusa nem megfelelő");
            }
        }
    }
}
