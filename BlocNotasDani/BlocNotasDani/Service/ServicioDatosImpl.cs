using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlocNotasDani.Model;
using BlocNotasDani.Utils;
using Microsoft.WindowsAzure.MobileServices;

namespace BlocNotasDani.Service
{
    public class ServicioDatosImpl:IServicioDatos
    {
        private MobileServiceClient client;

        public ServicioDatosImpl()
        {
            client= new MobileServiceClient(Cadenas.UrlServicio, Cadenas.TokenServicio);
        }

        #region Usuario

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            //nos prepara la url para llamar a una tabla en concreto
            var tabla = client.GetTable<Usuario>();
            try
            {
                var data =await tabla.CreateQuery().Where(o => o.Login == us.Login && o.Password == us.Password).ToListAsync();
                if (data.Count == 0)
                    return null;

                return data[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = client.GetTable<Usuario>();
            try
            {
                var data = await tabla.CreateQuery().Where(o => o.Login == us.Login).ToListAsync();
                if (data.Count > 0)
                    return null;
            }
            catch (Exception)
            {
              throw new Exception("Algo va mal artista");
            }


            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                return null;
            }
             
            return us;
        }

        public Task<Usuario> UpdateUsuario(Usuario us)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUsuario(Usuario us)
        {
            throw new NotImplementedException();
        }

        #endregion

        //todo 003. implementamos las modificaciones que acabamos de hacer en el interfaz

        #region Bloc

        public async Task AddBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.InsertAsync(bloc);

            //todo 004. Ojo, azure mobile service devuelve un void
            //todo 005. AzureMobileService implementa OData

        }

        public async Task<List<Bloc>> GetBlocs(string usuario)
        {
            var table = client.GetTable<Bloc>();
            var data = await table.CreateQuery().Where(o => o.IdUsuario == usuario).ToListAsync();
            return data;
        }

        //TODO 006. El borrado lo hacemos como objeto(bloc) porque Azure MS espera un objeto

        public async Task DeleteBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.DeleteAsync(bloc);
        }

        public async Task UpdateBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.UpdateAsync(bloc);
        }

        #endregion

    }
}
