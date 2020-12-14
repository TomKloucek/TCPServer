using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class GameCommand : ICommand
    {
        private Dictionary<string, string> training = new Dictionary<string, string>();
        private string[] cz = { "kocka", "pes", "koruna", "stul", "zidle", "mys", "kun", "lev", "slon", "hroch", "moucha", "tygr" };
        private string[] en = { "cat", "dog", "crown", "table", "chair", "mouse", "horse", "lion", "elephant", "hippo", "fly", "tiger" };

        private void Fill()
        {        
            for(int i = 1; i < cz.Length; i++)
            {
                training.Add(cz[i], en[i]);
            }
        }
        public GameCommand()
        {
            Fill();
        }
        public void Execute(TcpClient client, StreamWriter sWriter, StreamReader sReader, List<string> history, string value)
        {
            int spravne = 0;
            string[] kontrola = new string[2];
            Random rnd = new Random();
            for(int i = 0; i <= 2; i++)
            {
                kontrola[0] = cz[rnd.Next(0, 11)];
                sWriter.Flush();
                sWriter.Write(kontrola[0]+" ");
                sWriter.Flush();
                kontrola[1] = sReader.ReadLine();               
                if(training[kontrola[0]] == kontrola[1])
                {
                    spravne++;
                }               
            }
            sWriter.WriteLine($"Spravnych odpovedi: {spravne}");
        }
    }
}
