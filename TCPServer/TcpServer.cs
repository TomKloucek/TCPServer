﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPServer
{
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;
        private Dictionary<string, ICommand> commands = CommandSingleton.Instance;


        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();

                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
            List<string> history = new List<string>();
            Boolean bClientConnected = true;
            String sData = null;


            string nick = sReader.ReadLine();
            while (bClientConnected)
            {
                sWriter.WriteLine($"{nick}>");
                sWriter.WriteLine($"{nick}>");
                sData = sReader.ReadLine().Trim().ToLower();
                sWriter.Flush();
                string[] prikaz = new string[2];
                prikaz[0] = sData.Split(" ")[0];
                if (sData.Split(" ").Length == 1)
                {
                    prikaz[1] = " ";
                }
                else
                {
                    prikaz[1] = sData.Split(" ")[1];
                }
                if (commands.ContainsKey(prikaz[0]))
                {
                    commands[prikaz[0]].Execute(client,sWriter,history,prikaz[1]);
                }
                else
                {
                    sWriter.WriteLine("Unknown command:"+sData);
                }               
                sWriter.Flush();
            }
        }

    }
}