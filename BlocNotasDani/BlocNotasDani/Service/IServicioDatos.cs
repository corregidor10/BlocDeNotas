using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlocNotasDani.Model;

namespace BlocNotasDani.Service
{
    public interface IServicioDatos
    {
        #region Usuario

        Task<Usuario> ValidarUsuario(Usuario us);

        Task<Usuario> AddUsuario(Usuario us);

        Task<Usuario> UpdateUsuario(Usuario us);

        Task DeleteUsuario (Usuario us);

        #endregion

        //TODO 002 Creamos en el interfaz las tareas para la clase del Bloc

        #region Bloc

        Task AddBloc(Bloc bloc);

        Task<List<Bloc>> GetBlocs(String usuario);

        Task DeleteBloc(Bloc bloc);

        Task UpdateBloc(Bloc bloc);

        #endregion






    }
}