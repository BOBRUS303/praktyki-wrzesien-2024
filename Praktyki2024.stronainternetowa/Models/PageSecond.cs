using System.Drawing;
namespace Praktyki2024.stronainternetowa.Models
{
    public class PageSecond
    {
        public int Rok_produkcji { get; set; }
        public int Przebieg { get; set; }
        public string Marka { get; set; }
        public int Ilosc_miejsc { get; set; }
        public string Rodzaj_samochodu { get; set; }

        public PageSecond() { }

        public PageSecond(int rok_produkcji, int przebieg, string marka, int ilosc_miejsc, string rodzaj_samochodu)
        {
            this.Rok_produkcji = rok_produkcji;
            this.Przebieg = przebieg;
            this.Marka = marka;
            this.Ilosc_miejsc = ilosc_miejsc;
            this.Rodzaj_samochodu = rodzaj_samochodu;
        }
    }
}
