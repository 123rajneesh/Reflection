using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassConstructor
{
    public class Program
    {

        static void Main(string[] args)
        {


            var someType = Assembly.GetExecutingAssembly().GetTypes().Single(n => n.Name == "MyClass");
            var instance = MyFactory.MyCreateInstance(someType);
            var values = someType.GetFields().Select(f => f.GetValue(instance)).ToArray();
            foreach (var val in values)
            {
                Console.WriteLine(val);
            }

        }

        public class MyBase
        {
            public MyBase(string name)
            {
            }
        }

        public class MyClass : MyBase
        {

            public MyClass() : base("base class parameter")
            {

            }
        }
        public static class MyFactory
        {
            public static T MyCreateInstance<T>() where T : class
            {
                return (T)MyCreateInstance(typeof(T));
            }

            public static object MyCreateInstance(Type type)
            {
                var ctor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Length > 0);
                var ctor2 = (type.GetConstructors().Length > 0);
                if (ctor == null)
                {
                    return Activator.CreateInstance(type);
                }

                var result = ctor.Invoke(ctor.GetParameters().Select(p => p.HasDefaultValue ? p.DefaultValue : p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null ? Activator.CreateInstance(p.ParameterType) : null).ToArray());
                return result;
            }

            public static object MyCreateInstance2(Type type)
            {
                //var ctor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Length > 0);
                var ctors = type.GetConstructor(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance, null, new Type[0], null);
                dynamic result = null;
                //foreach (var ctr in ctors)
                //{
                //    var ctor = ctr;
                //    if (ctor == null)
                //    {
                //        result = Activator.CreateInstance(type);
                //        return result;
                //    }

                //    result = ctor.Invoke(ctor.GetParameters().Select(p => p.HasDefaultValue ? p.DefaultValue : p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null ? Activator.CreateInstance(p.ParameterType) : null).ToArray());
                //    return result;
                //}
                return result;
            }
        }
    }
}
