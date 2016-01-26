using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasDani.Factorias;
using Xamarin.Forms;

namespace BlocNotasDani.Modulo
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            builder.Register<INavigation>(ctx => App.Current.MainPage.Navigation).SingleInstance();

            }
    }

}

