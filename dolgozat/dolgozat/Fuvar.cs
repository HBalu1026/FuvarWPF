using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat
{
    internal class Fuvar
    {
        public int id, idotartam;
        public DateTime indulas;
        public double tavolsag, viletdij, borravalo;
        public string fizetesiMod;

        public Fuvar(int id, DateTime indulas, int idotartam, double tavolsag, double viteldij, double borravalo, string fizetesiMod)
        {
            this.id = id;
            this.indulas = indulas;
            this.idotartam = idotartam;
            this.tavolsag = tavolsag;
            this.viletdij = viteldij;
            this.borravalo = borravalo;
            this.fizetesiMod = fizetesiMod;
        }
    }
}
