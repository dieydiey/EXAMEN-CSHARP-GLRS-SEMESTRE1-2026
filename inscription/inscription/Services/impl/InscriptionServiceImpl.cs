using System;
using System.Collections.Generic;
using System.Linq;
using inscription.Data;
using inscription.Models;
using inscription.Models.Enums;
using inscription.Repository.Interfaces;
using inscription.Services.Interfaces;
namespace inscription.Services.impl
{
    public class InscriptionServiceImpl : IInscriptionServiceInterface
    {
        private readonly IInscriptionRepositoryInterface _repository;
        private readonly AppDbContext _context;

        public InscriptionServiceImpl(
            IInscriptionRepositoryInterface repository,
            AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Inscrire(int etudiantId, int classeId)
        {
            var anneeEnCours = _context.AnneeScolaires
                .First(a => a.Statut == StatutAnneeScolaire.EnCours);

            var inscription = new Inscription
            {
                EtudiantId = etudiantId,
                ClasseId = classeId,
                AnneeScolaireId = anneeEnCours.Id,
                DateInscription = DateTime.Now
            };

            _repository.Add(inscription);
            _repository.Save();
        }

        public IEnumerable<Inscription> ListerParClasse(int classeId)
        {
            return _repository.GetByClasse(classeId);
        }
    }
}
