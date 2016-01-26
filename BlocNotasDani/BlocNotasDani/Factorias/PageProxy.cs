using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlocNotasDani.Factorias
{
    public class PageProxy : IPage
    {
        readonly Func<Page> _page;

        public PageProxy(Func<Page> page)
        {
            _page = page;
        }


        public INavigation Navigation { get { return _page().Navigation; } }
    }
}
