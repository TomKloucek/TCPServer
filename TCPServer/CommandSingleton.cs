using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class CommandSingleton
    {
        private Dictionary<string, ICommand> commands;

        private CommandSingleton()
        {
            commands = new Dictionary<string, ICommand>();
            commands.Add("exit", new ExitCommand());
            commands.Add("help", new HelpCommand());
            commands.Add("time", new TimeCommand());
            commands.Add("history", new HistoryCommand());
            commands.Add("vowel", new VowelsCommand());
        }

        private static CommandSingleton instance = null;
        public static Dictionary<string, ICommand> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandSingleton();
                }
                return instance.commands;
            }
        }
    }
}
