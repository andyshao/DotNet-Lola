using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_DesignPattern
{
    /// <summary>
    /// 代理模式
    /// </summary>
    public class Proxy
    {

    }

    //一类人的接口
    public interface IKindMan
    {
        void BuyThings();
        void Eat();
    }

    //定义宝贝
    public class Baby : IKindMan
    {
        public void BuyThings()
        {
            Console.WriteLine("我是宝贝,我正在买东西哦...");
        }

        public void Eat()
        {
            Console.WriteLine("我是宝贝，我正在吃饭哦...");
        }
    }

    //定义娘子
    public class Wife : IKindMan
    {
        public void BuyThings()
        {
            Console.WriteLine("我是娘子，我正在买东西哦...");
        }

        public void Eat()
        {
            Console.WriteLine("我是娘子，我正在吃饭哦...");
        }
    }

    //定义爸比
    public class Babi : IKindMan
    {
        private IKindMan kindMan;

        public Babi()
        {
            kindMan=new Baby();
        }

        public Babi(IKindMan kindMan)
        {
            this.kindMan = kindMan;
        }

        public void BuyThings()
        {
            kindMan.BuyThings();
        }

        public void Eat()
        {
            kindMan.Eat();
        }
    }


}
