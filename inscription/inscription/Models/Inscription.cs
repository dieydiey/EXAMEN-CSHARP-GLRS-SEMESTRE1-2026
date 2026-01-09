using System;

namespace inscription.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public DateTime DateInscription { get; set; }

        public int EtudiantId { get; set; }
        public Etudiant Etudiant { get; set; }

        public int ClasseId { get; set; }
        public Classe Classe { get; set; }

        public int AnneeScolaireId { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
    }
}
