using Newtonsoft.Json;

namespace Impiccato
{
    public partial class Form1 : Form
    {
        char[] lettereProvate = new char[26];
        byte nLettereProvate = 0;
        string[] elencoParole;
        string daIndovinare;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNuovaParola_Click(object sender, EventArgs e)
        {
            if (elencoParole == null)
            {
                elencoParole = Deserializza();
            }

            //selezione della parola
            Random x = new Random();
            int posizione = x.Next(elencoParole.Length);
            daIndovinare = elencoParole[posizione];

            listBox1.Items.Add(daIndovinare);
        }

        private void buttonTentativo_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            
            char lettera = Convert.ToChar(textBoxTentativo.Text);
            if (!CercaLettera(lettera))
            {
                lettereProvate[nLettereProvate] = lettera;
                nLettereProvate++;
            }


            bool trovata = false;
            for (int i = 0; i < daIndovinare.Length; i++)
            {
                for (int j = 0; j < lettereProvate.Length; j++)
                {
                    if (daIndovinare[i] == lettereProvate[j])
                    {
                        trovata = true;
                    }
                }

                if (trovata)
                {
                    listBox1.Items.Add(daIndovinare[i]);
                    trovata = false;
                }
                else
                {
                    listBox1.Items.Add("*");
                }
            }
        }

        public string[] Deserializza()
        {
            string[] vettore = JsonConvert.DeserializeObject<string[]>(File.ReadAllText("../../../vocabolario.json"));
            return vettore;
        }

        public bool CercaLettera(char lettera)
        {
            bool isPresente = false;
            for (int i = 0; i < lettereProvate.Length; i++)
            {
                if (lettera == lettereProvate[i])
                {
                    isPresente = true;
                }
            }
            return isPresente;
        }
    }
}