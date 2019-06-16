using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Odtwarzacz
{
    /// <summary>
    /// Logika interakcji dla klasy Playlista.xaml
    /// </summary>

    public delegate void Akcja();
    public delegate void AkcjaUtwor(Utwor u);

    public partial class Playlista : UserControl
    {
        private List<Utwor> utwory = new List<Utwor>();
        private Utwor aktualny = null;

        //public event Akcja poDodaniu;
        public event AkcjaUtwor poWybraniuUtworu;

        /** drag&drop **/
        Grid kliknietyWiersz = null;
        Label kliknietaBelka = null;
        Grid wskazanyWiersz = null;
        Rectangle wskaznik = null;

        public Playlista()
        {
            InitializeComponent();

            ZainicjujDragAndDrop();

            //test
            this.dodajDoListy("D:\\Programowanie\\Cpp\\Odtwarzacz\\przykladowe utwory\\coin_roll.wav");
            this.dodajDoListy("D:\\Programowanie\\Cpp\\Odtwarzacz\\przykladowe utwory\\BadGuy.mp3");
        }

        public void GrajNastepny()
        {
            if (aktualny == null)
                return;
            int index = utwory.IndexOf(aktualny);
            if (index < utwory.Count - 1)
            { 
                Utwor u = utwory[index + 1];
                UstawJakoAktualnieOdtwarzany(u);
                this.poWybraniuUtworu(u);
            }
            else
                UstawJakoAktualnieOdtwarzany(null);
        }

        public void GrajPoprzedni()
        {
            if (aktualny == null)
                return;
            int index = utwory.IndexOf(aktualny);
            if(index > 0)
            {
                Utwor u = utwory[index - 1];
                UstawJakoAktualnieOdtwarzany(u);
                this.poWybraniuUtworu(u);
            }
            else
                UstawJakoAktualnieOdtwarzany(null);
        }

        private void UstawJakoAktualnieOdtwarzany(Utwor u)
        {
            aktualny = u;
            uint aktualny_id = u != null ? u.id : uint.MaxValue;

            foreach (UIElement child in this.lista_piosenek.Children)
            {
                if (child.GetType() == typeof(Grid))
                {
                    bool jest_aktualny = aktualny_id == (uint)(child as Grid).DataContext;

                    Grid row = child as Grid;
                    row.Background = new SolidColorBrush(jest_aktualny ? 
                        Color.FromRgb(139, 195, 74) : 
                        Colors.Transparent);
                }
            }
            this.poWybraniuUtworu(u);
        }

        private void RozpocznijDragAndDrop(Label l, Grid row)
        {
            l.BorderThickness = new Thickness(1);
            l.Padding = new Thickness(4);
            kliknietyWiersz = wskazanyWiersz = row;
            kliknietaBelka = l;

            wskaznik = new Rectangle();
            wskaznik.Height = 2;
            wskaznik.HorizontalAlignment = HorizontalAlignment.Stretch;
            wskaznik.Fill = new SolidColorBrush(Color.FromRgb(255, 128, 128));
            
            int index = this.lista_piosenek.Children.IndexOf(row);
            this.lista_piosenek.Children.Insert(index, wskaznik);
        }
        private void PrzerwijDragAndDrop()
        {
            kliknietaBelka.BorderThickness = new Thickness(0);
            kliknietaBelka.Padding = new Thickness(5);
            kliknietaBelka = null;
            kliknietyWiersz = wskazanyWiersz = null;
            if(wskaznik != null)
            {
                this.lista_piosenek.Children.Remove(wskaznik);
            }
            wskaznik = null;
        }
        private void ZainicjujDragAndDrop()
        {
            this.MouseUp += (o, i) =>
            {
                if (kliknietaBelka == null || kliknietyWiersz == null)
                    return;

                if (wskazanyWiersz != kliknietyWiersz)
                {
                    //ustawienie wskazanej belki na odpowiednim miejscu
                    int target_index = this.lista_piosenek.Children.IndexOf(wskaznik);
                    int current_index = this.lista_piosenek.Children.IndexOf(kliknietyWiersz);
                    this.lista_piosenek.Children.Remove(kliknietyWiersz);
                    this.lista_piosenek.Children.Remove(wskaznik);
                    this.lista_piosenek.Children.Insert(target_index, kliknietyWiersz);

                    if (current_index > target_index)
                        current_index--;//poprawka na obiekt wskaznika

                    //zamiana utworow na liscie obiektow Utwor
                    Utwor current_utwor = utwory[current_index];
                    utwory.Remove(current_utwor);
                    utwory.Insert(target_index, current_utwor);

                    //test poprawnosci indeksow
                    /*Console.WriteLine(target_index + " " + current_index);
                    foreach (Utwor u in utwory)
                        Console.WriteLine("u id: " + u.id);
                    foreach (UIElement child in this.lista_piosenek.Children)
                    {
                        if (child.GetType() == typeof(Grid))
                            Console.WriteLine("grid id: " + (child as Grid).DataContext);
                    }*/

                    if (NazwaPlaylisty.Content.ToString() != "Nowa playlista" && 
                        !NazwaPlaylisty.Content.ToString().EndsWith("*"))
                    {
                        NazwaPlaylisty.Content += "*";
                    }
                }

                PrzerwijDragAndDrop();
            };
            this.MouseMove += (o, i) =>
            {
                if (kliknietaBelka == null || kliknietyWiersz == null)
                    return;

                if (i.LeftButton != MouseButtonState.Pressed)
                {
                    PrzerwijDragAndDrop();
                    return;
                }
            };
        }

        private void DragAndDrop(Label l, Grid row)
        {
            l.MouseDown += (o, i) =>
            {
                RozpocznijDragAndDrop(l, row);
            };
            l.MouseMove += (o, i) =>
            {
                if (wskaznik == null || wskazanyWiersz == null)
                    return;
                if (row != wskazanyWiersz)
                {
                    wskazanyWiersz = row;
                    this.lista_piosenek.Children.Remove(wskaznik);
                    int index = this.lista_piosenek.Children.IndexOf(row);
                    this.lista_piosenek.Children.Insert(index, wskaznik);
                }
            };
        }

        private void dodajDoListy(string sciezka)
        {
            for (int i = 0; i < utwory.Count; i++)
            {//zabezpieczenie przed wstawieniem tego samego utworu do listy
                if (utwory[i].Sciezka == sciezka)
                    return;
            }
            Utwor utwor = new Utwor(sciezka);
            utwory.Add(utwor);

            Grid row = new Grid();
            row.DataContext = utwor.id;
            row.Width = 280;//taka sama szerokosc jak listy piosenek
            //row.Background = new SolidColorBrush(Color.FromRgb(128, 255, 128));
            row.HorizontalAlignment = HorizontalAlignment.Center;

            Label l = new Label();
            l.Content = utwor.Nazwa;
            l.HorizontalAlignment = HorizontalAlignment.Stretch;
            l.BorderBrush = new SolidColorBrush(Colors.SlateGray);
            l.Padding = new Thickness(5);
            row.Children.Add(l);

            DragAndDrop(l, row);

            Button graj = new Button();
            graj.Content = "GRAJ";
            graj.Margin = new System.Windows.Thickness(0, 0, 30, 0);
            graj.HorizontalAlignment = HorizontalAlignment.Right;
            row.Children.Add(graj);

            Button usun = new Button();
            usun.Width = 30;
            usun.Content = "X";
            usun.HorizontalAlignment = HorizontalAlignment.Right;
            row.Children.Add(usun);

            this.lista_piosenek.Children.Add(row);

            graj.Click += (o, i) =>//klikniecie przycisku Graj
            {
                this.UstawJakoAktualnieOdtwarzany(utwor);
            };
            usun.Click += (o, i) =>//klikniecie przycisku usuwania utworu
            {
                this.usunZListy(utwor);
            };

            if (NazwaPlaylisty.Content.ToString() != "Nowa playlista" &&
                !NazwaPlaylisty.Content.ToString().EndsWith("*"))
            {
                NazwaPlaylisty.Content += "*";
            }
        }

        private void usunZListy(Utwor u)
        {
            //int index = this.utwory.IndexOf(u);
            //if (index < 0)
            //    throw new Exception("Argument nie figuruje na liscie utworow");

            if (u == aktualny)//jesli uzytkownik usuwa aktualnie grany utwor
                GrajNastepny();

            //poszukiwanie wiersza w playliscie nalezacego do usuwanego utworu
            foreach(UIElement child in lista_piosenek.Children)
            {
                if(child.GetType() == typeof(Grid) && u.id == (uint)(child as Grid).DataContext)
                {
                    lista_piosenek.Children.Remove(child);
                    break;
                }
            }

            //usuwanie utworu z listy
            if (utwory.Remove(u))
                Console.WriteLine("Utwor usuniety z listy: " + u.Nazwa);

            if (NazwaPlaylisty.Content.ToString() != "Nowa playlista" &&
               !NazwaPlaylisty.Content.ToString().EndsWith("*"))
            {
                NazwaPlaylisty.Content += "*";
            }
            return;
        }

        private void PrzyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog wyborPliku = new OpenFileDialog();
            wyborPliku.Title = "Plik dźwiękowy .mp3 lub .wav";
            wyborPliku.Filter = "Pliki mp3|*.mp3|Pliki wav|*.wav";
            wyborPliku.Multiselect = true;
            wyborPliku.CheckFileExists = true;
            wyborPliku.CheckPathExists = true;
            if(wyborPliku.ShowDialog() == true) {
                foreach (string file in wyborPliku.FileNames)
                    this.dodajDoListy(file);
                //this.dodajDoListy(wyborPliku.FileName);
            }
        }

        private string WyodrebnijNazwePliku(string sciezka)
        {
            string[] parts1 = sciezka.Split('\\');
            string[] parts2 = parts1.Last().Split('.');
            return parts2.First();
        }

        private void PrzyciskWczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oknoOdczytu = new OpenFileDialog();
            oknoOdczytu.Filter = "Pliki xml (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
            oknoOdczytu.RestoreDirectory = true;

            if(oknoOdczytu.ShowDialog() == true)
            {
                
                string nazwa = WyodrebnijNazwePliku(oknoOdczytu.FileName);
                Console.WriteLine("Wczytywanie playlisty: " + nazwa);

                string kontent = File.ReadAllText(oknoOdczytu.FileName);
                Regex regex = new Regex("<utwor>(.+)</utwor>", RegexOptions.Multiline);
                Match match = regex.Match(kontent);

                UstawJakoAktualnieOdtwarzany(null);//przerywanie odtwarzanie po wczytaniu playlisty z pliku
                this.utwory.Clear();
                lista_piosenek.Children.Clear();

                while (match.Success) {
                    //Console.WriteLine();
                    this.dodajDoListy(match.Groups[1].Value);
                    match = match.NextMatch();
                }

                NazwaPlaylisty.Content = nazwa;
            }
        }

        private void PrzyciskZapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "Pliki xml (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
            oknoZapisu.RestoreDirectory = true;

            string xml = "";
            foreach(Utwor u in this.utwory)
                xml += String.Format("<utwor>{0}</utwor>\n", u.Sciezka);

            if (oknoZapisu.ShowDialog() == true)
            {
                File.WriteAllText(oknoZapisu.FileName, xml);
                NazwaPlaylisty.Content = WyodrebnijNazwePliku(oknoZapisu.FileName);
            }
        }
    }
}
