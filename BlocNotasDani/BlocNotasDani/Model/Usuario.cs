using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasDani.Model
{
    public class Usuario
    {
        //en mobile services los id son GUID que son strings y se tienen que llamar id
        public String Id { get; set; }

        public String Login { get; set; }

        public String Password { get; set; }

        public String Nombre { get; set; }

        public String Apellidos { get; set; }

    //    public String Foto { get; set; }
    }
}
