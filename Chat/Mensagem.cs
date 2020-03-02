using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public partial class Mensagem

    {
        public DateTime Data;
        public String Msg;
        public String Username;
       

        public Mensagem()
        {
           
        }

        public Mensagem(DateTime data, String mensagem, String username)
        {
            Data = data;
            Msg = mensagem;
            Username = username;

        }

        public override string ToString()
        {
            return "( " +Data+" ): "+ Username + ": " + Msg;
        }
    }
}
