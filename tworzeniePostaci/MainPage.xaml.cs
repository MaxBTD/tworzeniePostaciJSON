using System.Text.Json;

namespace tworzeniePostaci
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public class Postac
        {
            public string? imie { get; set; }
            public string? rasa { get; set; }
            public string? klasa { get; set; }
            public int dorosly {  get; set; }
            public float wzrost { get; set; }
            public int sila { get; set; }
            public int moc {  get; set; }
        }

        private void onGenerateClicked(object sender, EventArgs e)
        {
            string ERROR = "";
            string name = "";
            string klasa = "";
            string rasa;
            int dorosly = checkAdult.IsChecked ? 1 : 0;
            float wzrost = 0;
            int sila = 0;
            float maxWzrost = 200;
            float minWzrost = 160;
            Postac nowaPostac;
            string postacJSON;

            if (entName.Text != null && entName.Text.ToString().Length >= 3 && entName.Text.ToString().Length < 20)
                name = entName.Text;
            else
                ERROR += "-Imię postaci powinno mieć pomiędzy 3, a 20 znaki\n";

            if (radioElf.IsChecked)
            {
                rasa = "Elf";
                maxWzrost = 230;
                minWzrost = 190;
            }
            else if (radioHuman.IsChecked)
            {
                rasa = "Człowiek";
                maxWzrost = 200;
                minWzrost = 160;
            }
            else
            {
                rasa = "Goblin";
                maxWzrost = 160;
                minWzrost = 120;
            }

            if (pickerClass.SelectedItem != null)
                klasa = pickerClass.SelectedItem.ToString();
            else
                ERROR += "-Nie wybrano klasy z listy\n";

            if (entWzrost.Text == null || !float.TryParse(entWzrost.Text.ToString(), out wzrost))
                ERROR += "-Nie prawidłowy wzrost wpisany (oczekuje liczbę)\n";
            else if (wzrost > maxWzrost || wzrost < minWzrost)
                ERROR += $"-Nie prawidłowy wzrost wpisany (liczba w przedziale {minWzrost} - {maxWzrost})\n";


            if (entStrength.Text == null || !int.TryParse(entStrength.Text.ToString(), out sila))
                ERROR += "-Nie Prawidłowa siła wpisana (oczekuje liczbę całkowitą)\n";
            else if (sila > 100)
                ERROR += "-Nie Prawidłowa siła wpisana (siła nie może być większa od 100)\n";
            int moc = 100 - sila;
            entPower.Text = moc.ToString();

            if (ERROR != "")
                lblError.Text = ERROR;
            else {
                nowaPostac = new Postac {
                    imie = name,
                    rasa = rasa,
                    klasa = klasa,
                    dorosly = dorosly,
                    wzrost = wzrost,
                    sila = sila,
                    moc = moc
                };
                postacJSON = JsonSerializer.Serialize(nowaPostac); 
            }
        }
    }

}
