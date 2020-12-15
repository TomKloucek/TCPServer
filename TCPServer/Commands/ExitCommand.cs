using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TCPServer
{
    class ExitCommand : ICommand
    {
        private string popis = "exit : odpoji uzivatele od serveru";
         public ExitCommand()
        {
        }
        public void Execute(TcpClient client, StreamWriter sWriter, StreamReader sReader, List<string> history, string value)
        {
            client.Close();
            history.Add("exit");
        }

        public string getPopis()
        {
            return popis;
        }
    }
}
