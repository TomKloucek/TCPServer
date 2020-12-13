using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class HelpCommand : ICommand
    {
        private Dictionary<string, ICommand> commands;
        public HelpCommand()
        {
            
        }
        public void Execute(TcpClient client,StreamWriter sWriter, List<string> history, string value)
        {
            commands = CommandSingleton.Instance;
            foreach (var key in commands.Keys)
            {
                sWriter.WriteLine(key);
            }
            history.Add("help");

        }
    }
}
