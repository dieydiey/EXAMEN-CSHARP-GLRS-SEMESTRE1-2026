using System.Collections.Generic;

namespace inscription.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public ICollection<Inscription> Inscriptions { get; set; }
    }
}
