using Newtonsoft.Json;

namespace Impiccato
{
    public partial class Form1 : Form
    {
        char[] lettereProvate;
        byte nLettereProvate = 0;
        string[] elencoParole;
        string daIndovinare;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNuovaParola_Click(object sender, EventArgs e)
        {
            //controllo se il vettore che contiene le parole è gia stato caricato,
            //se il vettore è vuoto deserializzo "vocabolario.json"
            if (elencoParole == null)
            {
                elencoParole = Deserializza();
            }

            lettereProvate = new char[26]; //reinizializzo il vettore delle lettere provate

            //selezione della parola
            Random x = new Random();
            int posizione = x.Next(elencoParole.Length);
            daIndovinare = elencoParole[posizione];

            listBox1.Items.Add(daIndovinare);//temp
        }

        private void buttonTentativo_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //la lettera inserita dall'utente nella textbox viene inserita nel vettore delle lettere provate
            //se non è presente una lettera uguale
            char lettera = Convert.ToChar(textBoxTentativo.Text);
            if (!CercaLettera(lettereProvate, lettera))
            {
                lettereProvate[nLettereProvate] = lettera;
                nLettereProvate++;
            }


            bool trovata = false;
            //controllo per ogni lettera della parola da indovinare se l'utente ha inserito una lettera corrispondente
            for (int i = 0; i < daIndovinare.Length; i++)
            {
                for (int j = 0; j < lettereProvate.Length; j++)
                {
                    if (daIndovinare[i] == lettereProvate[j])
                    {
                        trovata = true;
                    }
                }

                //se nel vettore delle lettere provate è presente l'iesima lettera della parola da indovnare
                //aggiungo nella listbox la lettera, in caso contrario aggiungo un asterisco
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

        /// <summary>
        /// cerca se una lettera è gia presente in un vettore di char
        /// </summary>
        /// <param name="lettera">lettera da cercare</param>
        /// <param name="vettore">vettore in cui cercare "lettera"</param>
        /// <returns>true se la lettera è presente, false se la lettera non è presente</returns>
        public bool CercaLettera(char[] vettore, char lettera)
        {
            bool isPresente = false;
            for (int i = 0; i < vettore.Length; i++)
            {
                if (lettera == vettore[i])
                {
                    isPresente = true;
                }
            }
            return isPresente;
        }
    }
}