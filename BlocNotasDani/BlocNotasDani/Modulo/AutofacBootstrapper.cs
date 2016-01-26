using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasDani.Factorias;

namespace BlocNotasDani.Modulo
{
   public abstract class AutofacBootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            var cont = builder.Build();
            var viewFactory = cont.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(cont);

        }
        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IContainer container);
    }
}
