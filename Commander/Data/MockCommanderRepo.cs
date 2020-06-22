using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        #region Arvores
        public IEnumerable<Arvores> GetAllArvores()
        {
            var arvores = new List<Arvores>
            {
                new Arvores { IdArvore = 0, IdEspecie = 0, Idade = 10, Descricao = "Açai" },
                new Arvores { IdArvore = 1, IdEspecie = 0, Idade = 15, Descricao = "Cerejeira" },
                new Arvores { IdArvore = 2, IdEspecie = 1, Idade = 50, Descricao = "Eucalipto" },
            };

            return arvores;
        }

        public Arvores GetArvoresById(int Id)
        {
            return new Arvores { IdArvore = 3, IdEspecie = 2, Idade = 25, Descricao = "Pau Brasil" };
        }
        #endregion
        #region Colheita
        public IEnumerable<Colheita> GetAllColheita()
        {
            var colheitas = new List<Colheita>
            {
                new Colheita { IdArvore = 0, Info = "Coheita 1 trimestre", DataColheita = DateTime.Now.AddDays(-30), PesoBruto = Convert.ToDecimal("500.8")},
                new Colheita { IdArvore = 1, Info = "Colheita 3 trimestre", DataColheita = DateTime.Now.AddDays(30), PesoBruto = Convert.ToDecimal("300.98") },
                new Colheita { IdArvore = 2, Info = "Colheita 2 trimestre", DataColheita = DateTime.Now, PesoBruto = Convert.ToDecimal("200.55") },
            };

            return colheitas;
        }

        public Colheita GetColheitaById(int Id)
        {
            return new Colheita { IdArvore = 3, Info = "Colheita 4 trimestre", DataColheita = DateTime.Now.AddMonths(4), PesoBruto = Convert.ToDecimal("775.55") };
        }
        #endregion
        #region Especies
        public IEnumerable<Especies> GetAllEspecies()
        {
            var especies = new List<Especies>
            {
                new Especies { IdEspecie = 0, Descricao = "Frutifera"},
                new Especies { IdEspecie = 1, Descricao = "Plantio"},
                new Especies { IdEspecie = 2, Descricao = "Extinção"},
            };

            return especies;
        }

        public Especies GetEspeciesById(int Id)
        {
            return new Especies { IdEspecie = 2, Descricao = "Especial" };
        }
        #endregion
        #region GrupoArvores
        public IEnumerable<GrupoArvores> GetAllGrupoArvores()
        {
            var grupoarvores = new List<GrupoArvores>
            {
                new GrupoArvores { IdGrupoArvore = 0, IdArvore = 1, Nome = "Grupo Arvore A", Descricao = "Descrição Grupo Arvore A" },
                new GrupoArvores { IdGrupoArvore = 1, IdArvore = 0, Nome = "Grupo Arvore B", Descricao = "Descrição Grupo Arvore B" },
                new GrupoArvores { IdGrupoArvore = 2, IdArvore = 1, Nome = "Grupo Arvore C", Descricao = "Descrição Grupo Arvore C" },
            };

            return grupoarvores;
        }

        public GrupoArvores GetGrupoArvoresById(int Id)
        {
            return new GrupoArvores { IdGrupoArvore = 2, IdArvore = 2, Nome = "Grupo Arvore D", Descricao = "Descrição Grupo Arvore D" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateArvores(Arvores arvores)
        {
            throw new NotImplementedException();
        }

        public void CreateColheita(Colheita colheita)
        {
            throw new NotImplementedException();
        }

        public void CreateEspecies(Especies especies)
        {
            throw new NotImplementedException();
        }

        public void CreateGrupoArvores(GrupoArvores grupoarvores)
        {
            throw new NotImplementedException();
        }

        public void UpdateArvores(Arvores arvores)
        {
            throw new NotImplementedException();
        }

        public void DeleteArvores(Arvores arvores)
        {
            throw new NotImplementedException();
        }

        public void UpdateColheita(Colheita colheita)
        {
            throw new NotImplementedException();
        }

        public void DeleteColheita(Colheita colheita)
        {
            throw new NotImplementedException();
        }

        public void UpdateEspecies(Especies especies)
        {
            throw new NotImplementedException();
        }

        public void DeleteEspecies(Especies especies)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrupoArvores(GrupoArvores grupoarvores)
        {
            throw new NotImplementedException();
        }

        public void DeleteGrupoArvores(GrupoArvores grupoarvores)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
