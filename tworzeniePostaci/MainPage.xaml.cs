namespace tworzeniePostaci
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void onGenerateClicked(object sender, EventArgs e)
        {
            string ERROR = "";
            string name = "";
            string klasa = "";
            string rasa;
            bool dorosly = checkAdult.IsChecked;
            float wzrost = 0;
            int sila = 0;

            if (entName.Text != null && entName.Text.ToString().Length > 3 && entName.Text.ToString().Length < 20)
                name = entName.Text;
            else
                ERROR += "-Imię postaci powinno mieć pomiędzy 3, a 20 znaki\n";
            
            if (radioElf.IsChecked)
                rasa = "Elf";
            else if (radioHuman.IsChecked)
                rasa = "Człowiek";
            else
                rasa = "Goblin";

            if (pickerClass.SelectedItem != null)
                klasa = pickerClass.SelectedItem.ToString();
            else
                ERROR += "-Nie wybrano klasy z listy\n";

            if (entWzrost.Text == null || !float.TryParse(entWzrost.Text.ToString(), out wzrost))
                ERROR += "-Nie prawidłowy wzrost wpisany\n";
            if (entStrength.Text == null || !int.TryParse(entStrength.Text.ToString(), out sila))
                ERROR += "-Nie Prawidłowa siła wpisana\n";
            int moc = 100 - sila;
            entPower.Text = moc.ToString();

        }
    }

}
