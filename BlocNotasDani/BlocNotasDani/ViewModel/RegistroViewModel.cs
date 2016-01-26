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
    public class RegistroViewModel : GeneralViewModel
    {
        public ICommand cmdRegistro { get; set; }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private Usuario _usuario = new Usuario();

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio, Session session)
            : base(navigator, servicio, session)
        {
         cmdRegistro = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
          try
                {
                    IsBusy = true;
                    var r = await _servicio.AddUsuario(_usuario);
                    if (r != null)
                    {
                        Session["usuario"] = r;
                        await _navigator.PushModalAsync<PrincipalViewModel>(viewModel =>
                        {
                            
                            viewModel.Titulo = "Pantalla principal";
                            viewModel.Blocs = new ObservableCollection<Bloc>();
                        });
                    //todo 0011. en el resto de viewmodels, hay que incluir el titulo como viewmodel.titulo
                }
                else
                    {
                        var a = "";
                    }
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
