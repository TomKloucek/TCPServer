using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    interface ICommand
    {
        void Execute(TcpClient client, StreamWriter sWriter, StreamReader sReader,List<string> history, string value);
        string getPopis();
    }
}
