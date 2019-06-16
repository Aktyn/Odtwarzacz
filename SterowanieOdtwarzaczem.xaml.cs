using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy SterowanieOdtwarzaczem.xaml
    /// </summary>

    public delegate void Sterowanie();
    public partial class SterowanieOdtwarzaczem : UserControl
    {
        OdtwarzaczMain odtwarzacz = new OdtwarzaczMain();
        private Thread watek_aktualizacji = null;

        public event Sterowanie grajPoprzedni;//wybor poprzedniego utworu z listy
        public event Sterowanie grajNastepny;//adekwatnie

        public SterowanieOdtwarzaczem()
        {
            InitializeComponent();
            this.PasekGlosnosci.Value = 100;
            this.odtwarzacz.poZakonczeniu += this.PoZakonczeniu;

            this.UstawUtwor(null);
        }

        private void UstawUtwor(Utwor u)
        {
            if(u == null)
            {
                PrzyciskPauzy.IsEnabled = false;
                GrajPoprzednia.IsEnabled = false;
                GrajNastepna.IsEnabled = false;
                ObecnyUtworInfo.Content = "";
                PasekPostepu.Value = 0;
            }
            else
            {
                PrzyciskPauzy.IsEnabled = true;
                GrajPoprzednia.IsEnabled = true;
                GrajNastepna.IsEnabled = true;
                ObecnyUtworInfo.Content = "Odtwarzany plik: " + u.Nazwa;

                if (u.Rozszerzenie == "mp3")//pokazywanie znacznikow mp3
                {
                    TagLib.File plik = TagLib.File.Create(u.Sciezka);

                    ObecnyUtworInfo.Content += "\nTytuł: " + plik.Tag.Title +
                        "\nAlbum: " + plik.Tag.Album;
                    foreach(string artysta in plik.Tag.Performers)
                        ObecnyUtworInfo.Content += "\nArtysta: " + artysta;
                }
                
                //this.ObecnyUtworInfo.
            }
        }

        public void Graj(Utwor u)
        {
            if (this.odtwarzacz.CzyOdtwarza)
                this.odtwarzacz.Przerwij();
            else if (u == null)
                return;
            
            this.PrzyciskPauzy.Content = "PAUZA";
            this.UstawUtwor(u);
            PasekPostepu.Value = 0;

            this.odtwarzacz.OdtworzPlik(u);
            this.odtwarzacz.UstawGlosnosc((float)this.PasekGlosnosci.Value / 100.0f);

            if (this.watek_aktualizacji == null)
            {
                watek_aktualizacji = new Thread(new ThreadStart(this.AktualizujPostep));
                watek_aktualizacji.IsBackground = true;
                watek_aktualizacji.Start();
            }
        }

        private void PoZakonczeniu(Utwor u)
        {
            Console.WriteLine("Zakonczono utwor: " + u.Nazwa);
            UstawUtwor(null);
            if(grajNastepny != null)
                grajNastepny();//automatycznie wyslij event o nastepny utwor
        }

        private void AktualizujPostep()
        {
            while (odtwarzacz.CzyOdtwarza)
            {
                try
                {
                    //dzieki temu dispatcherowi mozna uzyskac dostep do PasekPostepu z obecnego wątku
                    Application.Current.Dispatcher.Invoke(
                        new Action(() => PasekPostepu.Value = odtwarzacz.PostepOdtwarzania() * 100)
                    );
                }
                catch
                {
                    Console.WriteLine("Główny wątek został zakończony");
                }
                Thread.Sleep(1000/60);
            }
            watek_aktualizacji = null;
        }

        private void PrzyciskPauzy_Click(object sender, RoutedEventArgs e)
        {
            if (!odtwarzacz.CzyZapauzowany)
            {
                odtwarzacz.Pauzuj();
                this.PrzyciskPauzy.Content = "WZNÓW";
            }
            else
            {
                odtwarzacz.Wznow();
                this.PrzyciskPauzy.Content = "PAUZA";
            }
        }

        private void PasekGlosnosci_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            odtwarzacz.UstawGlosnosc((float)PasekGlosnosci.Value / 100.0f);
        }

        private void GrajPoprzednia_Click(object sender, RoutedEventArgs e)
        {
            if (grajNastepny != null)
                grajPoprzedni();
        }

        private void GrajNastepna_Click(object sender, RoutedEventArgs e)
        {
            if (grajNastepny != null)
                grajNastepny();
        }
    }
}
