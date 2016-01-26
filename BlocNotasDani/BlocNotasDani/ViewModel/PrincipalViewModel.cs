using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
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
   public class PrincipalViewModel:GeneralViewModel
    {
        //todo 0006. EnMVVM Las listas las creamos del tipo ObservableCollection para que refresque al instante(internamente implementa el INotifyPropertyChanged)
        private ObservableCollection<Bloc> _blocs;

        public ICommand CmdNuevo { get; set; }

        public ObservableCollection<Bloc> Blocs
       {
           get { return _blocs; }
           set { SetProperty(ref _blocs,value); }
       }

       

        //TODO 0005. Para esta pantalla necesitaremos mostrar una coleccion de blocs y un boton de Nuevo
       public PrincipalViewModel(INavigator navigator, IServicioDatos servicio, Session session)
           : base(navigator, servicio, session)
       {
           var a = "";
            CmdNuevo =new Command(NuevoBloc);
       }

       private async void NuevoBloc()
       {
           await _navigator.PushAsync<NuevoBlocViewModel>(viewModel =>
           {
               viewModel.Titulo = "Nuevo bloc";
               viewModel.Blocs = Blocs;
           });
       }


    }
}
