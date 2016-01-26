using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using BlocNotasDani.Factorias;
using BlocNotasDani.Model;
using BlocNotasDani.Service;
using BlocNotasDani.Utils;
using Xamarin.Forms;

namespace BlocNotasDani.ViewModel
{
    public class NuevoBlocViewModel : GeneralViewModel
    {
        //todo 0008. Despues de crear el listview en el xaml, creamos un nuevo VM para crear blocs nuevos

        public ObservableCollection<Bloc> Blocs { get; set; }

        public ICommand CmdGuardar { get; set; }

        public Bloc Bloc
        {
            get { return _bloc; }
            set { SetProperty(ref _bloc, value); }
        }

        private Bloc _bloc;
        
        public NuevoBlocViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            _bloc = new Bloc();
            CmdGuardar= new Command(Guardar);
        }

        //TODO 009. El metodo guardar le faltaría saber el id.
        private async void Guardar()
        {
            Bloc.Fecha= DateTime.Now;
            Bloc.IdUsuario = (Session["usuario"] as Usuario).Id;
            Bloc.Icono = ""; 
            // TODO 101. FALTA POR DEFINIR COMO RECUPERAR EL ICONO

           await _servicio.AddBloc(Bloc);

            Blocs.Add(Bloc);
            
            //await _navigator.PushModalAsync
            //    <PrincipalViewModel>(viewModel =>
            //    {
            //        viewModel.Titulo = "Principal";
            //        viewModel.Blocs = new ObservableCollection<Bloc>();
            //    });
        }
    }
}
