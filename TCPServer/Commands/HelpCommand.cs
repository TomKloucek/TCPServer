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
        private string popis = "help : ukaze vsechny commandy i s popisy";
        public HelpCommand()
        {
            
        }
        public void Execute(TcpClient client,StreamWriter sWriter, StreamReader sReader ,List<string> history, string value)
        {
            commands = CommandSingleton.Instance;
            foreach (var key in commands.Keys)
            {
                sWriter.WriteLine($"{key} - {commands[key].getPopis()}");
            }
            history.Add("help");
            sWriter.WriteLine();
        }

        public string getPopis()
        {
           return popis;
        }
    }
}
