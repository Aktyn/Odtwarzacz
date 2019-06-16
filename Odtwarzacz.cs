using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odtwarzacz
{
    public delegate void AkcjaOdtwarzacza(Utwor u);
    class OdtwarzaczMain
    {
        private WaveStream waveStream = null;
        private WaveOut waveOut = null;
        private Utwor aktualny_utwor = null;

        public event AkcjaOdtwarzacza poZakonczeniu;//gdy utwor sie skonczy

        public OdtwarzaczMain()
        {
            Console.WriteLine("OdtwarzaczMain stworzony");
        }

        public void OdtworzPlik(Utwor u)
        {
            if (u == null)
            {
                this.Przerwij();
                return;
            }

            waveStream = new AudioFileReader(u.Sciezka);
            //Console.WriteLine(waveStream.TotalTime);
            waveOut = new WaveOut();
            waveOut.Volume = 1;
            waveOut.Init(waveStream);
            waveOut.Play();
            waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(this.KoniecUtworu);
            aktualny_utwor = u;
        }

        public void Przerwij()//przerywa odtwarzanie aktualnego utworu
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (waveStream != null)
            {
                waveStream.Dispose();
                waveStream = null;
            }
            
            aktualny_utwor = null;
        }

        public void Pauzuj()
        {
            this.waveOut.Pause();
        }

        public void Wznow()
        {
            this.waveOut.Resume();
        }

        public void UstawGlosnosc(float glosnosc)//wartosc miedzy 0 a 1
        {
            if(this.waveOut != null)
                this.waveOut.Volume = glosnosc;
        }

        public bool CzyZapauzowany
        {
            get
            {
                return this.waveOut.PlaybackState == PlaybackState.Paused;
            }
        }

        private void KoniecUtworu(object a, object b)
        {
            this.waveStream = null;
            this.waveOut = null;
            this.poZakonczeniu(this.aktualny_utwor);
            this.aktualny_utwor = null;
        }

        public bool CzyOdtwarza
        {
            get
            {
                return this.waveStream != null && this.waveOut != null;
            }
        }

        public float PostepOdtwarzania()
        {
            //this.waveStream.TotalTime;
            if (this.waveStream == null)
                return 0.0f;
            return this.waveStream.CurrentTime.Ticks / (float)this.waveStream.TotalTime.Ticks;
        }
    }
}
