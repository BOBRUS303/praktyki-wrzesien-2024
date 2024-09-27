// zadania domowe:
// 1. Zdefiniować po trzy zmienne typu int, float, string, char i char[]
// 2a(*). zrobić tak by char[] wyświetlił się w konsoli poprawnie
// 2b. Wyświetlić w każdą zdefiniowaną zmienną w pojedynczej linii(każdą osobno)
// 3 i 4. Pobrać od użytkownika imie, wiek, rok urodzenia, plec
// wyświetlić komunikaty o błędzie:
// jeśli wiek błędny
// jesli rok urodzenia wiekszy niż 2010
// jeśli plec bledna(płec to może być M lub K małe)
// jesli nie ma błędów wyświetlić dane użytkownika
// 5. Zrobić po jednej pętli z każdego rodzaju
// 5b(*). Zrobić pętlę do/while tak by nie wyszedł z niej użytkownik dopóki nie wpisze pasującego 4 cyfrowego kodu 1234
// na wyjście z pętli wyświetlić komunikat
// 5c. Przykład różnicy gdzie można użyć while a gdzie do while
// 5d. podwójna choinke forem (zdjecie na chacie)
// 6. każde zadanie w osobnej funkcji
using System.Runtime.InteropServices;

namespace praktyki2024.zad1
{
    internal class Program
    {
        static void Zadanie1i2()
        {
            int zmiennaint1 = 3, zmiennaint2 = 4, zmiennaint3 = 5;
            float zmiennafloat1 = 2.3f, zmiennafloat2 = 3.4f, zmiennafloat3 = 6.54f;
            string zmiennastring1 = "Siema", zmiennastring2 = "Czesc", zmiennastring3 = "Elo";
            char zmiennachar1 = 'A', zmiennachar2 = 'B', zmiennachar3 = 'C';
            char[] zmiennahar1 = { 'H', 'e', 'l', 'l', 'o', ' ' };
            char[] zmiennahar2 = { 'm', 'y', ' ', 'b', 'e', 'l', 'o', 'v', 'e', 'd' };
            char[] zmiennahar3 = { 'f', 'r', 'i', 'e', 'n', 'd' };
            Console.WriteLine($"Int: {zmiennaint1}, {zmiennaint2}, {zmiennaint3}");
            Console.WriteLine($"Float: {zmiennafloat1}, {zmiennafloat2}, {zmiennafloat3}");
            Console.WriteLine($"String: {zmiennastring1}, {zmiennastring2}, {zmiennastring3}");
            Console.WriteLine($"Char: {zmiennachar1}, {zmiennachar2}, {zmiennachar3}");
            Console.WriteLine($"Char: {new string(zmiennahar1)}");
            Console.WriteLine($"Char: {new string(zmiennahar2)}");
            Console.WriteLine($"Char: {new string(zmiennahar3)}");

        }
        static void Zadanie3i4()
        {
            string imie, plec;
            int wiek, rokUrodzenia;

            Console.Write("Podaj swoje imię: ");
            imie = Console.ReadLine();

            Console.Write("Podaj swój wiek: ");
            wiek = int.Parse(Console.ReadLine());

            Console.Write("Podaj rok urodzenia: ");
            rokUrodzenia = int.Parse(Console.ReadLine());

            Console.Write("Podaj swoją płeć (m/k): ");
            plec = Console.ReadLine();

            bool blad = false;

            if (wiek <= 14 || wiek > 120)
            {
                Console.WriteLine("Błąd: niepoprawny wiek.");
                blad = true;
            }
            if (rokUrodzenia > 2010)
            {
                Console.WriteLine("Błąd: niepoprawny rok urodzenia.");
                blad = true;
            }
            if (plec != "m" && plec != "k")
            {
                Console.WriteLine("Błąd: niepoprawna płeć.");
                blad = true;
            }

            if (!blad)
            {
                Console.WriteLine($"Imię: {imie}");
                Console.WriteLine($"Wiek: {wiek}");
                Console.WriteLine($"Rok urodzenia: {rokUrodzenia}");
                Console.WriteLine($"Płeć: {plec}");
            }
        }
        static void Zadanie5()
        {
            Console.WriteLine("Pętla for:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"i = {i}");
            }
            Console.WriteLine("Pętla foreach:");
            string[] tablica = { "Element1", "Element2", "Element3", "Element4", "Element5" };
            foreach (var element in tablica)
            {
                Console.WriteLine($"Element: {element}");
            }
            Console.WriteLine("Pętla while:");
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine($"j = {j}");
                j++;
            }
            Console.WriteLine("Pętla do-while:");
            int k = 0;
            do
            {
                Console.WriteLine($"k = {k}");
                k++;
            } while (k < 5);
        }
        static void Zadanie5b()
        {
            int kod;
            do
            {
                Console.Write("Podaj czterocyfrowy kod: ");
                kod = int.Parse(Console.ReadLine());
            } while (kod != 1234);

            Console.WriteLine("Poprawny kod! Wyszedłeś z pętli.");
        }
        static void Zadanie5c()
        {
            Console.WriteLine("Pętla while:");
            int licznik1 = 5;
            while (licznik1 < 5)
            {
                Console.WriteLine($"Licznik1 = {licznik1}");
            }

            Console.WriteLine("Pętla do-while:");
            int licznik2 = 5;
            do
            {
                Console.WriteLine($"Licznik2 = {licznik2}");
            } while (licznik2 < 5);
        }
        static void Zadanie5d()
        {
            Console.Write("Podaj wysokość choinki: ");
            int wysokosc = int.Parse(Console.ReadLine());

            for (int i = 1; i <= wysokosc; i++)
            {
                for (int j = 1; j <= wysokosc - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for (int i = wysokosc - 1; i >= 1; i--)
            {
                for (int j = 1; j <= wysokosc - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= (2 * i - 1); j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {

            Zadanie1i2();
            Zadanie3i4();
            Zadanie5();
            Zadanie5b();
            Zadanie5c();
            Zadanie5d();
        }

    }
}