using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KemiNETClient.Managers
{
    public class SocketConnectionManager
    {
        private static Socket ConnectSocket()
        {
            const string server = Constants.DefaultHostname;
            const int port = Constants.DefaultPort; 
            Socket s = null;
            IPHostEntry hostEntry = null;
        
            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach(IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = 
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if(tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
            }
            return s;
        }

        // This method requests the home page content for the specified server.
        public static string SendToServer(Model model) 
        {
            /*string request = "GET / HTTP/1.1\r\nHost: " + server + 
                             "\r\nConnection: Close\r\n\r\n {\"key\": \"value\"}";*/
        
            Byte[] bytesSent = Encoding.ASCII.GetBytes(model.ToString());
            Byte[] bytesReceived = new Byte[256];
            string serverResponse = string.Empty;
        
            // Create a socket connection with the specified server and port.
            using(Socket s = ConnectSocket()) {

                if (s == null)
                    return ("Connection failed");
            
            
                // Send request to the server.
                s.Send(bytesSent, bytesSent.Length, 0);  

                do {
                    int receivedBytesCount = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    serverResponse += Encoding.ASCII.GetString(bytesReceived, 0, receivedBytesCount);
                }
                while (s.Available > 0);
            }
        
            return serverResponse;
        }
    }
}