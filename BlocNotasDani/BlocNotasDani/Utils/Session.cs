using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasDani.Utils
{
   public class Session
    {
        private Dictionary<String, Object>_session= new Dictionary<string, object>();

        //todo 000 Creamos la clase session con un indexer

        public Object this [String index]
       {
            get { return _session[index]; }

            set { _session[index] = value; }
       }
    }
}
