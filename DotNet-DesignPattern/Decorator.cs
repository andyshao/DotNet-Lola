using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_DesignPattern
{
    /// <summary>
    /// 装饰模式
    /// </summary>
    public abstract class Decorator : Girl
    {
        private Girl girl;

        protected Decorator(Girl girl)
        {
            this.girl = girl;
        }

        public override void Dance()
        {
            Console.WriteLine("I am Dancing....");
        }

        public override void Sing()
        {
            Console.WriteLine("I am singing....");
        }

        public override void Play()
        {
            Console.WriteLine("I am Playing....");
        }

        public override void ICanDo()
        {
            Dance();
            Sing();
            Play();
        }
    }

    //正常创建妹子
    public class SimpleGirl : Girl
    {
        public override void Dance()
        {
            Console.WriteLine("I am Dancing....");
        }

        public override void Sing()
        {
            Console.WriteLine("I am singing....");
        }

        public override void Play()
        {
            Console.WriteLine("I am Playing....");
        }

        public override void ICanDo()
        {
            Dance();
            Sing();
            Play();
        }
    }

    //一个妹子
    public abstract class Girl
    {
        public abstract void Dance();
        public abstract void Sing();
        public abstract void Play();
        public abstract void ICanDo();
    }

    //装饰人谈话的行为
    public class ActionTalk : Decorator
    {
        public ActionTalk(Girl girl)
            : base(girl)
        {
        }

        public void Talk()
        {
            Console.WriteLine("I am Talking....");
        }

        public override void ICanDo()
        {
            base.Dance();
            base.Sing();
            base.Play();
            Talk();
        }
    }

    //装饰人画画的行为
    public class ActionDraw : Decorator
    {
        public ActionDraw(Girl girl)
            : base(girl)
        {
        }

        public void Draw()
        {
            Console.WriteLine("I am Drawing....");
        }

        public override void ICanDo()
        {
            base.Dance();
            base.Sing();
            base.Play();
            Draw();
        }

    }
}
