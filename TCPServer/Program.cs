using System;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer server = new TcpServer(8655);
        }
    }
}
