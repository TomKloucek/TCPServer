using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace TCPServer
{
    class ExitCommand : ICommand
    {

         public ExitCommand()
        {
        }
        public void Execute(TcpClient client, StreamWriter sWriter, List<string> history, string value)
        {
            client.Close();
            history.Add("exit");

        }

    }
}
