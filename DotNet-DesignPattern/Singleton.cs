using System;

namespace DotNet_DesignPattern
{
    public class Singleton
    {
        //设置公共的单个对象
        private static Singleton _instance;
        public string Name { get; set; }
        public int Age { get; set; }

        //设置私有的构造方法，此类将无法被实例化
        private Singleton()
        {

        }

        //如果当然实例存在就反回当前实例，不存在就新建这个对象
        public static Singleton GetInstance()
        {
            _instance = _instance ?? new Singleton();
            return _instance;
        }

        public void Say(string words)
        {
            Console.WriteLine("{0}({1}岁):{2}", Name, Age, words);
        }

    }
}
