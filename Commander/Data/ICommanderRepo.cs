using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        #region Modelo Arvores
        IEnumerable<Arvores> GetAllArvores();
        Arvores GetArvoresById(int Id);
        void CreateArvores(Arvores arvores);
        void UpdateArvores(Arvores arvores);
        void DeleteArvores(Arvores arvores);
        #endregion

        #region Modelo Colheita
        IEnumerable<Colheita> GetAllColheita();
        Colheita GetColheitaById(int Id);
        void CreateColheita(Colheita colheita);
        void UpdateColheita(Colheita colheita);
        void DeleteColheita(Colheita colheita);
        #endregion

        #region Modelo Especies
        IEnumerable<Especies> GetAllEspecies();
        Especies GetEspeciesById(int Id);
        void CreateEspecies(Especies especies);
        void UpdateEspecies(Especies especies);
        void DeleteEspecies(Especies especies);
        #endregion

        #region Modelo GrupoArvores
        IEnumerable<GrupoArvores> GetAllGrupoArvores();
        GrupoArvores GetGrupoArvoresById(int Id);
        void CreateGrupoArvores(GrupoArvores grupoarvores);
        void UpdateGrupoArvores(GrupoArvores grupoarvores);
        void DeleteGrupoArvores(GrupoArvores grupoarvores);
        #endregion
    }
}