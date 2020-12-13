using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    interface ICommand
    {
        void Execute(TcpClient client, StreamWriter sWriter,List<string> history, string value);
    }
}
