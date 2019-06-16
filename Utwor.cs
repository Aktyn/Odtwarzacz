using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odtwarzacz
{
    public class Utwor
    {
        private static uint licznik = 0;//zwieksza sie po kazdym utworzeniu obiektu Utwor

        public readonly uint id;//zawiera unikalne id będące numerem danej instancji
        private readonly string _sciezka;

        public Utwor(string sciezka)
        {
            this._sciezka = sciezka;
            this.id = Utwor.licznik++;
        }

        public string Nazwa
        {
            get
            {
                string[] parts = this.Sciezka.Split('\\');
                return parts.Last();
            }
        }

        public string Sciezka
        {
            get
            {
                return this._sciezka;
            }
        }

        public string Rozszerzenie
        {
            get
            {
                string[] parts = this.Sciezka.Split('.');
                return parts.Last();
            }
        }
    }
}
