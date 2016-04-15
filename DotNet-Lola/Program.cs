using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNet_DesignPattern;
using DotNet_GD;
using DotNet_Thread;

namespace DotNet_Lola
{
    class Program
    {
        static void Main()
        {
            #region 单例模式调用
            //var s1 = Singleton.GetInstance();
            //s1.Name = "Jerry";
            //s1.Age = 25;
            //s1.Say("Hello,EveryOne~");

            //var s2 = Singleton.GetInstance();

            //s2.Say("Hi,We Are Friends~");
            #endregion

            #region 简单工厂模式调用
            //var p = SimpleFactory.CreatePerson("normal");
            //p.Run();
            #endregion

            #region 工厂方法调用
            //IFactory creator = new HybridHumanFactory();
            //IHuman human = creator.CreateHuman();
            //human.Cry();
            //human.Talk();
            //human.Laugh();
            #endregion

            #region 装饰模式调用
            //Girl gl = new SimpleGirl();
            //gl.ICanDo();
            //Console.WriteLine("-----------------------------------------");
            //gl = new ActionDraw(gl);
            //gl.ICanDo();
            //Console.WriteLine("-----------------------------------------");
            //gl = new ActionTalk(gl);
            //gl.ICanDo();
            #endregion

            #region 代理模式调用
            //var babi = new Babi();
            //babi.BuyThings();
            //babi.Eat();
            //Console.WriteLine("-----------------------------------------");
            //babi = new Babi(new Wife());
            //babi.BuyThings();
            //babi.Eat();
            #endregion

            #region 验证码生成
            //var res = ImageVerification.GetNumberVerification();
            //res.Save(@"D:\Verification.jpg");
            //res.Dispose();
            #endregion

            ThreadBuy();

            Console.WriteLine("----------操作完成----------");
            Console.ReadKey();
        }

        static void ThreadBuy()
        {
            var tt = new ThreadPar();
            Parallel.For(0, 100, (t, state) =>
            {
                var uid = "用户" + t;
                var x = tt.Buy(uid);
                if (x.Code == -1)
                {
                    Console.WriteLine(uid + ":" + x.Msg);
                    //state.Break();
                }
                else
                    Console.WriteLine(uid + ":" + x.Msg + "还剩下:" + x.Cnt + "件");
            });

        }
    }
}
