// using System;
// using System.IO;
// using System.Net.Sockets;
// using System.Threading;
// using Database_SEP3.DAO.ComponentsDAO;
// using Database_SEP3.Networking.Util;
//
// namespace Database_SEP3.Networking
// {
//     public class SocketHandler
//     {
//         private TcpClient _tcpClient;
//         private NetworkStream _networkStream;
//         private ComponentsDAO _componentsDao;
//       
//         public SocketHandler(TcpClient tcpClient)
//         {
//             _componentsDao = ComponentsDAOImpl.GetInstance();
//             _tcpClient = tcpClient;
//
//             try
//             {
//                 _networkStream = tcpClient.GetStream();
//                 Thread thread = new Thread(new ThreadStart(Run));
//                 thread.Start();
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e);
//                 throw;
//             }
//
//         }
//
//         public void Run()
//         {
//             try
//             {
//                 Request request = (Request) _networkStream.Read()
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e);
//                 throw;
//             }
//         }
//     }
// }