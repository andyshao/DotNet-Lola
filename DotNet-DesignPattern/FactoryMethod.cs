using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_DesignPattern
{
    /// <summary>
    /// 工厂模式
    /// </summary>
    public class FactoryMethod
    {

    }

    //工厂接口
    public interface IFactory
    {
        IHuman CreateHuman();
    }
    //黄种人工厂
    public class YellowHumanFactory : IFactory
    {
        public IHuman CreateHuman()
        {
            return new YellowHuman();
        }
    }
    //白种人工厂
    public class WhiteHumanFactory : IFactory
    {
        public IHuman CreateHuman()
        {
            return new WhiteHuman();
        }
    }
    //黑种人工厂
    public class BlackHumanFactory : IFactory
    {
        public IHuman CreateHuman()
        {
            return new BlackHuman();
        }
    }
    //混血儿工厂
    public class HybridHumanFactory : IFactory
    {
        public IHuman CreateHuman()
        {
            return new HybridHuman();
        }
    }

    //人的接口
    public interface IHuman
    {
        void Laugh();
        void Cry();
        void Talk();
    }
    //黄种人
    public class YellowHuman : IHuman
    {
        public void Laugh()
        {
            Console.WriteLine("YellowHuman Laughing....");
        }

        public void Cry()
        {
            Console.WriteLine("YellowHuman Crying....");
        }

        public void Talk()
        {
            Console.WriteLine("YellowHuman Talking....");
        }
    }
    //白种人
    public class WhiteHuman : IHuman
    {
        public void Laugh()
        {
            Console.WriteLine("WhiteHuman Laughing....");
        }

        public void Cry()
        {
            Console.WriteLine("WhiteHuman Crying....");
        }

        public void Talk()
        {
            Console.WriteLine("WhiteHuman Talking....");
        }
    }
    //黑种人
    public class BlackHuman : IHuman
    {
        public void Laugh()
        {
            Console.WriteLine("BlackHuman Laughing....");
        }

        public void Cry()
        {
            Console.WriteLine("BlackHuman Crying....");
        }

        public void Talk()
        {
            Console.WriteLine("BlackHuman Talking....");
        }
    }
    //混血儿
    public class HybridHuman : IHuman
    {
        public void Laugh()
        {
            Console.WriteLine("HybridHuman Laughing....");
        }

        public void Cry()
        {
            Console.WriteLine("HybridHuman Crying....");
        }

        public void Talk()
        {
            Console.WriteLine("HybridHuman Talking....");
        }
    }

}
