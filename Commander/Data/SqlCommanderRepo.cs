using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        #region Create
        public void CreateArvores(Arvores arvores)
        {
            if (arvores == null)
            {
                throw new ArgumentNullException(nameof(arvores));
            }

            _context.Arvores.Add(arvores);
        }

        public void CreateColheita(Colheita colheita)
        {
            if (colheita == null)
            {
                throw new ArgumentNullException(nameof(colheita));
            }

            _context.Colheita.Add(colheita);
        }

        public void CreateEspecies(Especies especies)
        {
            if (especies == null)
            {
                throw new ArgumentNullException(nameof(especies));
            }

            _context.Especies.Add(especies);
        }

        public void CreateGrupoArvores(GrupoArvores grupoarvores)
        {
            if (grupoarvores == null)
            {
                throw new ArgumentNullException(nameof(grupoarvores));
            }

            _context.GrupoArvores.Add(grupoarvores);
        }

        #endregion

        #region Update
        public void UpdateArvores(Arvores arvores)
        {
        }

        public void UpdateColheita(Colheita colheita)
        {
        }

        public void UpdateEspecies(Especies especies)
        {
        }

        public void UpdateGrupoArvores(GrupoArvores grupoarvores)
        {
        }

        #endregion

        #region Delete

        public void DeleteArvores(Arvores arvores)
        {
            if (arvores == null)
            {
                throw new ArgumentNullException(nameof(arvores));
            }
            _context.Arvores.Remove(arvores);
        }

        public void DeleteColheita(Colheita colheita)
        {
            if (colheita == null)
            {
                throw new ArgumentNullException(nameof(colheita));
            }
            _context.Colheita.Remove(colheita);
        }

        public void DeleteEspecies(Especies especies)
        {
            if (especies == null)
            {
                throw new ArgumentNullException(nameof(especies));
            }
            _context.Especies.Remove(especies);
        }

        public void DeleteGrupoArvores(GrupoArvores grupoarvores)
        {
            if (grupoarvores == null)
            {
                throw new ArgumentNullException(nameof(grupoarvores));
            }
            _context.GrupoArvores.Remove(grupoarvores);
        }

        #endregion

        #region GetAll
        public IEnumerable<Arvores> GetAllArvores()
        {
            return _context.Arvores.ToList();
        }

        public IEnumerable<Colheita> GetAllColheita()
        {
            return _context.Colheita.ToList();
        }

        public IEnumerable<Especies> GetAllEspecies()
        {
            return _context.Especies.ToList();
        }

        public IEnumerable<GrupoArvores> GetAllGrupoArvores()
        {
            return _context.GrupoArvores.ToList();
        }
        #endregion

        #region GetByID
        public Arvores GetArvoresById(int Id)
        {
            return _context.Arvores.FirstOrDefault(p => p.IdArvore == Id);
        }

        public Colheita GetColheitaById(int Id)
        {
            return _context.Colheita.FirstOrDefault(p => p.IdColheita == Id);
        }

        public Especies GetEspeciesById(int Id)
        {
            return _context.Especies.FirstOrDefault(p => p.IdEspecie == Id);
        }

        public GrupoArvores GetGrupoArvoresById(int Id)
        {
            return _context.GrupoArvores.FirstOrDefault(p => p.IdGrupoArvore == Id);
        }

        #endregion
    }
}