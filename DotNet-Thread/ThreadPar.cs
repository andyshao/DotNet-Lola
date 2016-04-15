using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Thread
{
    public class ThreadPar
    {
        // ReSharper disable once InconsistentNaming
        private static int cnt = 90;
        private static Queue<string> queueAll = new Queue<string>();
        private static Queue<string> queueCur = new Queue<string>();
        private static  object ol = new object();

        static ThreadPar()
        {
            HandleQueue();
        }

        public RetData Buy(string uid)
        {
            queueAll.Enqueue(uid);

            if (queueAll.Count >= cnt){
                return new RetData {Code = -1, Msg = "商品已经被抢购一空了哦~~", Cnt = 0};
            }
            queueCur.Enqueue(uid);
            return new RetData { Code = 1, Msg = "恭喜已经抢到啦！", Cnt = cnt - queueAll.Count };
        }

        public static void HandleQueue()
        {
            Task.Factory.StartNew(() =>
            {
                while (true) if (queueCur.Count > 0) HandleOrder();
                // ReSharper disable once FunctionNeverReturns
            });
        }

        public static void HandleOrder()
        {
            while (queueCur.Count != 0)
            {
                Console.WriteLine("处理用户订单中:" + queueCur.Dequeue());
            }
        }

    }

    public class RetData
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public int Cnt { get; set; }
    }
}
