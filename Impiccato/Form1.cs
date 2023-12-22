using Newtonsoft.Json;

namespace Impiccato
{
    public partial class Form1 : Form
    {
        char[] lettereProvate; //raccolta delle singole lettere inserite dall'utente
        byte nLettereProvate = 0; //numero delle lettere provate, punta alla prima posizione libera di "lettereProvate"
        string[] elencoParole; //vocabolario delle parole
        string daIndovinare; //parola da indovinare
        byte erroriRimasti; //numero di errori rimasti
        byte nAsterischi; //numero di asterischi stampati nella listBox, necessario per la condizione di vittoria


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

            //selezione della parola
            Random x = new Random();
            int posizione = x.Next(elencoParole.Length);
            daIndovinare = elencoParole[posizione];

            //reinizializzo il vettore delle lettere provate e il numero di errori rimasti
            lettereProvate = new char[26];
            erroriRimasti = 7;
            labelErroriRimasti.Text = $"Errori rimasti: {erroriRimasti}";

            listBox1.Items.Add(daIndovinare);//temp
        }

        private void buttonTentativo_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            char lettera = '\0';
            string parola = "";

            if (textBoxTentativo.Text.Length == 1)
            {
                lettera = Convert.ToChar(textBoxTentativo.Text);
                //la lettera inserita dall'utente nella textbox viene inserita nel vettore delle lettere provate
                //se non è presente una lettera uguale
                if (!CercaLettera(lettereProvate, lettera))
                {
                    lettereProvate[nLettereProvate] = lettera;
                    nLettereProvate++;
                }
            }
            else
            {
                parola = textBoxTentativo.Text;
            }


            if (erroriRimasti != 0 && lettera != '\0')
            {
                AggiornaListBox();
                //se l'utente ha indovinato tutte le lettere della parola mostro nell'interfaccia il messaggio di vittoria
                if (nAsterischi == 0)
                {
                    labelRisultato.Text = "Hai vinto!";
                }

                //controllo se la lettera inserita dall'utente è presente nella parola da indovinare,
                //se non è presente diminuisco gli errori rimasti.
                if (!CercaLettera(daIndovinare.ToCharArray(), lettera))
                {
                    erroriRimasti--;
                }
            }
            else if(parola != "")
            {
                if (parola == daIndovinare)
                {
                    labelRisultato.Text = "Hai vinto!";
                    listBox1.Items.Add(daIndovinare);
                }
                else
                {
                    erroriRimasti--;
                    AggiornaListBox();
                }
            }
            else if (erroriRimasti == 0)
            {
                labelRisultato.Text = "Hai perso!";
            }

            labelErroriRimasti.Text = erroriRimasti.ToString();
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

        /// <summary>
        /// Aggiorna il contenuto della listbox in base alle lettere provate
        /// </summary>
        public void AggiornaListBox()
        {
            bool trovata = false;
            nAsterischi = Convert.ToByte(daIndovinare.Length);
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
                    nAsterischi--;
                    trovata = false;
                }
                else
                {
                    listBox1.Items.Add("*");
                }
            }
        }
    }
}