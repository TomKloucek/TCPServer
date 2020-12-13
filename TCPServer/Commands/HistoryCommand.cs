using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class HistoryCommand : ICommand
    {
        private List<string> history = new List<string>();
        public HistoryCommand()
        {

        }
        public void Execute(TcpClient client, StreamWriter sWriter, List<string> history, string value)
        {
            foreach(var zaznam in history)
            {
                sWriter.Write($"{zaznam} ");
            }
            history.Add("history");

        }
    }
}
