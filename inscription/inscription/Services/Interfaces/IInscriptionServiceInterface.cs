using System.Collections.Generic;
using inscription.Models;

namespace inscription.Services.Interfaces
{
    public interface IInscriptionServiceInterface
    {
        void Inscrire(int etudiantId, int classeId);
        IEnumerable<Inscription> ListerParClasse(int classeId);
    }
}
