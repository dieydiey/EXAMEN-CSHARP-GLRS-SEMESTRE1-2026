using System.Collections.Generic;
using inscription.Models.Enums;

namespace inscription.Models
{
    public class AnneeScolaire
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public StatutAnneeScolaire Statut { get; set; }

        public ICollection<Inscription> Inscriptions { get; set; }
    }
}
