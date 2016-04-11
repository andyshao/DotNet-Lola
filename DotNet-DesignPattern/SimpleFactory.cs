using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_DesignPattern
{
    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public class SimpleFactory
    {
        public static Person CreatePerson(string kind)
        {
            switch (kind)
            {
                case "normal":
                    {
                        return new NormalPerson();
                    }
                case "athlete":
                    {
                        return new Athlete();
                    }
                case "child":
                    {
                        return new Child();
                    }
                default:
                    {
                        throw new Exception("Invalid param...");
                    }
            }
        }
    }

    public abstract class Person
    {
        public string Name { set; get; }

        public abstract void Run();
    }

    public class NormalPerson : Person
    {
        public override void Run()
        {
            Console.WriteLine("NormalPerson Running....");
        }
    }

    public class Athlete : Person
    {
        public override void Run()
        {
            Console.WriteLine("Athlete Running....");
        }
    }

    public class Child : Person
    {
        public override void Run()
        {
            Console.WriteLine("Child Running....");
        }
    }
}
