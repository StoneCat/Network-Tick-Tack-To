/*
 * Created by SharpDevelop.
 * User: luis_nikolai
 * Date: 19.02.2018
 * Time: 19:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace Network_Tick_Tack_To
{
	public class TClient
    {
        public static int ServerPort = 12345;

        // GUI, in der die empfangenen Nachrichten angezeigt werden
        MainForm mainForm;

        // Thread, der die Kommunikation verwaltet
        Thread mainThread;

        // Socket zum Server
        TcpClient server;

        // Netzwerk-Streams
        StreamWriter writer;
        StreamReader reader;

        // so lange läuft der Client
        bool running;

        // Konstruktor
        public TClient(MainForm aClientForm, string serverIP)
        {
            mainForm = aClientForm;

            // Thread mit der übergebenen IP starten
            mainThread = new Thread(run);
            mainThread.Start(serverIP);
        }

        // Client-Prozess beenden
        public void stop()
        {
            running = false;
        }

        // msg an den Server schicken
        public void sendMessage (string msg)
        {
            try
            {
                // an den Server schicken
                writer.WriteLine(msg);
                writer.Flush();
            }
            catch (Exception e)
            {
                mainForm.showClientMessage(e.Message);
                stop();
            }
        }

        // dies führt der Client-Thread aus
        void run (Object serverIP)
        {
            connectToServer(serverIP);

            // Kommunikationsschleife
            while (running)
            {
                // vom Server empfangen
                string msg = reader.ReadLine();

                // wenn der Server nicht beendet (<q>)
                if (msg != null && msg != "<q>")
                    mainForm.showClientMessage(msg);
                else
                {
                    // sonst Ende der Verbindung
                    sendMessage("<q>");
                    stop();
                }
            }

            mainForm.showClientMessage("Ended connection with server.");
            Thread.Sleep(100);

            if (server != null)
                server.Close();
        }

        private void connectToServer(Object serverIP)
        {
            // Verbindung zum Server herstellen
            try
            {
                server = new TcpClient((string)serverIP, ServerPort);

                writer = new StreamWriter(server.GetStream());
                reader = new StreamReader(server.GetStream());
                running = true;
            }
            catch (SocketException se)
            {
                mainForm.showClientMessage("Connection error: " + se.Message);
                stop();
            }
        }
    }
}
