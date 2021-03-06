﻿using System;
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
            ZSocket socket = new ZSocket(context, ZSocketType.REP);

            socket.Bind("tcp://0.0.0.0:7777");
            while (true)
            {

                ZFrame recv_frame = socket.ReceiveFrame();
                Console.WriteLine(recv_frame.ReadString());
                ZFrame frame = new ZFrame("Hello world");
                socket.SendFrame(frame);
            }
            
        }
    }
}
