using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace ZeroMQ_Test
{

    class Program
    {
        static void Main(string[] args)
        {

            ZContext context = new ZContext();
            ZSocket socket = new ZSocket(context, ZSocketType.REQ);

            socket.Connect("tcp://127.0.0.1:7777");
            while (true)
            {
                ZFrame frame = new ZFrame(Console.ReadLine());
                socket.SendFrame(frame);
                ZFrame recv_frame = socket.ReceiveFrame();
                Console.WriteLine(recv_frame.ReadString());
            }

        }
    }
}
