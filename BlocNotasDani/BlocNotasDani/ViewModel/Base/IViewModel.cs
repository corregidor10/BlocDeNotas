using System;
using System.ComponentModel;

namespace BlocNotasDani.ViewModel.Base
{
    //implementamos la herencia para que nos notifique los cambios de una propiedad
    public interface IViewModel:INotifyPropertyChanged
    {
        string Titulo { get; set; }
        
        //lo utilizamos para cambiar el estado del ViewModel
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}