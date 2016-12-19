using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace SocketChat
{
    public class SocketConnection
    {
        #region 连接服务器端

        //可以有重载

        /// <summary>
        ///  连接服务器端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Socket ConnectServer(string ip, int port)
        {
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ip, port);
            }
            catch (System.Exception ex)
            {
            }

            return socket;
        }

        #endregion 连接服务器端

        #region 给端 发送消息的一个封装

        /// <summary>
        /// 给端 发送消息的一个封装
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool SendData(Socket socket, byte[] data)
        {
            socket.Send(data, 0, data.Length, 0);
            return true;
        }

        #endregion 给端 发送消息的一个封装

        /// <summary>
        /// 发送普通的字符串
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool SendTxt(Socket socket, string txt)
        {
            byte[] data = Encoding.Default.GetBytes(txt);
            byte[] addSingleData = new byte[data.Length + 1];

            //0:  1: 3:.
            //设置发送字符串的标识
            addSingleData[0] = (byte)SendDataTypeEnum.String;
            //字节数组块拷贝
            Buffer.BlockCopy(data, 0, addSingleData, 1, data.Length);

            SendData(socket, addSingleData);

            return true;
        }

        /// <summary>
        /// 发送闪屏
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool SendShake(Socket socket)
        {
            byte[] data = new byte[1];
            data[0] = (byte)SendDataTypeEnum.Shake;
            SendData(socket, data);
            return true;
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="sokcet"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SendFile(Socket sokcet, string fileName)
        {
            byte[] data = File.ReadAllBytes(fileName);
            //如果是大文件的话，先把文件读取到内存流里面，然后一块一块的读，读一块就send一块
            byte[] addSingleData = new byte[data.Length + 1];
            //魔鬼数字
            addSingleData[0] = (byte)SendDataTypeEnum.File;

            Buffer.BlockCopy(data, 0, addSingleData, 1, data.Length);

            SendData(sokcet, addSingleData);

            return true;
        }
    }
}