using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotasDani.Factorias;
using BlocNotasDani.Service;
using BlocNotasDani.Utils;
using BlocNotasDani.ViewModel.Base;

namespace BlocNotasDani.ViewModel
{
    public class GeneralViewModel : ViewModelBase
    {
        //todo 0002. Implementamos la session en el GeneralViewModel para que lo hereden sus hijos

        protected INavigator _navigator;
        protected IServicioDatos _servicio;
        protected Session Session { get; set; }


        public GeneralViewModel(INavigator navigator, IServicioDatos servicio, Session session)
        {
            _navigator = navigator;
            _servicio = servicio;
            Session = session;
        }
    }
}
