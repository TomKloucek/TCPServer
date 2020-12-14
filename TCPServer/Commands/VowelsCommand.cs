using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class VowelsCommand : ICommand
    {
        public VowelsCommand()
        {

        }
        public void Execute(TcpClient client, StreamWriter sWriter, StreamReader sReader, List<string> history, string value)
        {
            int len;
            string myStr = value;
            int vowel_count = 0;
            int cons_count = 0;
            len = myStr.Length;
            for (int i = 0; i < len; i++)
            {
                if (myStr[i] == 'a' || myStr[i] == 'e' || myStr[i] == 'i' || myStr[i] == 'o' || myStr[i] == 'u' || myStr[i] == 'A' || myStr[i] == 'E' || myStr[i] == 'I' || myStr[i] == 'O' || myStr[i] == 'U')
                {
                    vowel_count++;
                }
                else
                {
                    cons_count++;
                }
            }
            sWriter.WriteLine($"Pocet samohlasek: {vowel_count}, Pocet souhlasek: {cons_count}");

        }
    }
}
