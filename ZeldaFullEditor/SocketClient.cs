using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;



	public class ObjectState
	{
		public const int BufferSize = 256;
		public Socket wSocket = null;
		public byte[] Buffer = new byte[BufferSize];
		public StringBuilder sb = new StringBuilder();
	}

	public class AsyncSocketClient
	{
		private const int Port = 7888;
		private static ManualResetEvent connectCompleted = new ManualResetEvent(false);
		private static ManualResetEvent sendCompleted = new ManualResetEvent(false);
		private static ManualResetEvent receiveCompleted = new ManualResetEvent(false);

		private static string response = string.Empty;

		public static void StartClient()
		{
			try
			{
				IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress ip = new IPAddress(new byte[] {127,0,0,1});//ipHost.AddressList[0];
				IPEndPoint remoteEndPoint = new IPEndPoint(ip, Port);
				Socket client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				client.BeginConnect(remoteEndPoint, new AsyncCallback(ConnectionCallback), client);
				Send(client, "This is test message <EOF>");
				sendCompleted.WaitOne();

				Receive(client);
				receiveCompleted.WaitOne();
				Console.WriteLine($"Response Received {response}");
				client.Shutdown(SocketShutdown.Both);
				client.Close();
			}
			catch (Exception e)
			{ 
				Console.WriteLine(e.ToString());
			}
		}

		private static void Receive(Socket client)
		{
			try
			{
				ObjectState state = new ObjectState();
				state.wSocket = client;
				client.BeginReceive(state.Buffer, 0, ObjectState.BufferSize,0, new AsyncCallback(ReceiveCallback), state);
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static void ReceiveCallback(IAsyncResult ar)
		{
			try
			{
				ObjectState state = (ObjectState) ar.AsyncState;
				var client = state.wSocket;
				int byteRead = client.EndReceive(ar);
				if(byteRead > 0) 
				{ 
					state.sb.Append(Encoding.ASCII.GetString(state.Buffer,0,byteRead));
					client.BeginReceive(state.Buffer, 0, ObjectState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
				}
				else
				{
					if (state.sb.Length>1)
					{
						response = state.sb.ToString();
					}
					receiveCompleted.Set();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private static void Send(Socket client, string data)
		{
			byte[] byteData = Encoding.ASCII.GetBytes(data);
			client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
		}

		private static void SendCallback(IAsyncResult ar)
		{
			try
			{
				Socket client = (Socket) ar.AsyncState;
				int byteSent = client.EndSend(ar);
				Console.WriteLine($"Sent:{byteSent} bytes to server");
				sendCompleted.Set();
			}
			catch (Exception e)
			{

				Console.WriteLine(e);
			}
		}

		private static void ConnectionCallback(IAsyncResult ar)
		{
			try
			{
				Socket client = (Socket)ar.AsyncState;
				client.EndConnect(ar);
				Console.WriteLine($"Socket connection : { client.RemoteEndPoint.ToString()}");
				connectCompleted.Set();
			}
			catch (Exception e)
			{

				Console.WriteLine(e);

			}
		}
	}

