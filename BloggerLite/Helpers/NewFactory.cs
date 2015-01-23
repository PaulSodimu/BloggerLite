using System;
using BloggerLite.Helpers.Interfaces;

namespace BloggerLite.Helpers
{
    public class NewFactory<T> : INewFactory<T>
    {
        public T Get()
        {
            return Activator.CreateInstance<T>();
        }

        public T Get(string param1, string param2)
        {
            return (T)Activator.CreateInstance(typeof(T), param1, param2);
        }

        public T Get(string param1)
        {
            return (T)Activator.CreateInstance(typeof(T), param1);
        }
    }
}
