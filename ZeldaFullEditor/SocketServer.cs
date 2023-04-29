using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	internal class SocketServer
	{
		private static TcpListener serverSocket;
		public static void StartServer()
		{
			IPHostEntry ipHostEntry = Dns.Resolve(Dns.GetHostName());
			IPAddress ipAddress = ipHostEntry.AddressList[0];
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 7888);
			serverSocket = new TcpListener(ipEndPoint);
			serverSocket.Start();
			Console.WriteLine("Asynchonous server socket is listening at: " + ipEndPoint.Address.ToString());
			WaitForClients();
		}

		private static void WaitForClients()
		{
			serverSocket.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnected), null);
		}

		private static void HandleClientRequest(TcpClient clientSocket)
		{
			//Write your code here to process the data
			
		}

		private static void OnClientConnected(IAsyncResult asyncResult)
		{
			try
			{
				TcpClient clientSocket = serverSocket.EndAcceptTcpClient(asyncResult);
				if (clientSocket != null)
					Console.WriteLine("Received connection request from: " + clientSocket.Client.RemoteEndPoint.ToString());
				HandleClientRequest(clientSocket);
			}
			catch
			{
				throw;
			}
			WaitForClients();
		}
	}
}
