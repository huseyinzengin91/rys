using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RehberYS.Models
{
    public interface IRehberRepository
    {
        IEnumerable<Rehber> MusterileriGetir();
        Rehber MusteriGetir (int id);
        void MusteriEkle(Rehber rehber);
        void MusteriSil(int id);
        void MusteriDuzenle(Rehber rehber);
        void AlanEkle(string alan);
        void AlanSil(string alan);
    }
}
