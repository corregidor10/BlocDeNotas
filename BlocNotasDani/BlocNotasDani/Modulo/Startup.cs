using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasDani.Factorias;
using BlocNotasDani.View;
using BlocNotasDani.ViewModel;
using Xamarin.Forms;

namespace BlocNotasDani.Modulo
{
   public class Startup:AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocNotasModulo>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<RegistroViewModel, Registro>();
            viewFactory.Register<PrincipalViewModel, Principal>();
            viewFactory.Register<NuevoBlocViewModel, NuevoBlocView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var np = new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}
