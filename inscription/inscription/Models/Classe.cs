using System.Collections.Generic;
using inscription.Models;

namespace inscription.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }

        public ICollection<Inscription> Inscriptions { get; set; }
    }
}
