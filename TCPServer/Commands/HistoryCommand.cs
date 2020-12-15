using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class HistoryCommand : ICommand
    {
        private string popis = "history : vypise vasi historii prikazu";
        private List<string> history = new List<string>();
        public HistoryCommand()
        {

        }
        public void Execute(TcpClient client, StreamWriter sWriter, StreamReader sReader, List<string> history, string value)
        {
            foreach(var zaznam in history)
            {
                sWriter.Write($"{zaznam} ");
            }
            history.Add("history");
            sWriter.WriteLine();
        }

        public string getPopis()
        {
            return popis;
        }
    }
}
