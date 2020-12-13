using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class TimeCommand : ICommand
    {
        private DateTime localDate = DateTime.Now;
        public TimeCommand()
        {
        }

        public void Execute(TcpClient client,StreamWriter sWriter, List<string> history, string value)
        {
            sWriter.WriteLine(localDate);
            history.Add("time");
        }
    }
}
