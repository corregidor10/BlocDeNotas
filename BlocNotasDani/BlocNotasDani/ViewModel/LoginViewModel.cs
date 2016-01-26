using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlocNotasDani.Factorias;
using BlocNotasDani.Model;
using BlocNotasDani.Service;
using BlocNotasDani.Utils;
using Xamarin.Forms;

namespace BlocNotasDani.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta { get; set; }
        //todo 0003. Hay que agregar la session en el constructor de todos los viewmodels
        public LoginViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            cmdLogin = new Command(IniciarSesion);
            cmdAlta = new Command(NuevoUsuario);
            Titulo = "Logueate o muere";
            //TODO 0010. PARA QUE HAGA EL BINDING EN LOGIN, SE TIENE QUE CARGAR EN EL CONSTRUCTOR
        }

        public string TituloIniciar { get { return "Iniciar sesión"; } }
        public string TituloRegistro { get { return "Nuevo usuario"; } }
        public string TituloLogin { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario = new Usuario();
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us != null)
                {
                    //TODO 0004 Agregamos las caracteristicas de Session al usuario.
                    // TODO 0007 implementamos el metodo getblocs al inicio de session
                    Session["usuario"] = us;
                    var blocs = await _servicio.GetBlocs(us.Id);

                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Pagina de inicio";
                        viewModel.Blocs= new ObservableCollection<Bloc>(blocs);

                    });
                }
                else
                {
                    var xxx = "";
                }

                //TODO 100: Aqui navegariamos a la pantalla principal o dariamos error
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void NuevoUsuario()
        {
            // await _navigator.PopToRootAsync();
            await _navigator.PushAsync<RegistroViewModel>(viewModel =>
            {
                viewModel.Titulo = "Nuevo Usuario";
                
            });
        }

    }
}
