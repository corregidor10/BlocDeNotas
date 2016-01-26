using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasDani.Service;
using BlocNotasDani.Utils;
using BlocNotasDani.View;
using BlocNotasDani.ViewModel;
using Xamarin.Forms;

namespace BlocNotasDani.Modulo
{
   public class BlocNotasModulo:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();
            //TODO 0001. Despues de crear la clase session lo registro antes de las vistas para prevenir errores. lo registramos como single instance para que sea un singlenton y solo genere un registro en memoria
            builder.RegisterType<Session>().SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<Principal>();
            builder.RegisterType<Registro>();
            builder.RegisterType<NuevoBlocView>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PrincipalViewModel>();
            builder.RegisterType<RegistroViewModel>();
            builder.RegisterType<NuevoBlocViewModel>();


            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            })
            ;

        }
    }
}
