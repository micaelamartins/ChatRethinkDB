using System;

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

        public Mensagem( DateTime data, String username, String mensagem)
        {
           
            Data = data;
            Msg = mensagem;
            Username = username;
        }

        public override string ToString()
        {
            return "( " +Data+" ) "+ Username + ": " + Msg;
        }
    }
}
