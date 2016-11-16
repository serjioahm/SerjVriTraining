using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtensions
{
    public static class MyIEnumerableExtensions
    {
        public static T Min2<T>(this IEnumerable<T> data)
            where T : IComparable<T>
        {
            using (IEnumerator<T> enumerator = data.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    T min = enumerator.Current;

                    foreach (var item in data)
                    {
                        if (min.CompareTo(item) >= 1)
                        {
                            min = item;
                        }
                    }

                    return min;
                }
            }

            throw new Exception("Enumeration must not be empty!");
        }

        public static T Max2<T>(this IEnumerable<T> data)
            where T : IComparable<T>
        {
            using (IEnumerator<T> enumerator = data.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    T min = enumerator.Current;

                    foreach (var item in data)
                    {
                        if (min.CompareTo(item) <= -1)
                        {
                            min = item;
                        }
                    }

                    return min;
                }
            }

            throw new Exception("Enumeration must not be empty!");
        }
        public static T Sum2<T>(this IEnumerable<T> data)
           where T : IComparable<T>
        {
            dynamic sum = 0;
            foreach (var element in data)
            {
                sum += element;
            }

            return sum;
        }
        public static T Avg2<T>(this IEnumerable<T> data)
          where T : IComparable<T>
        {
            dynamic sum = 0;
            int count = 0;
            foreach (var element in data)
            {
                sum += element;
                count++;
            }

           

            sum = sum / count;

            return sum;
        }
        public static int Sum(this List<int> data)
        {
            int sum = 0;
            foreach (var item in data)
            {
                sum += item;
            }
            return sum;
        }

        public static double Avg(this int[] data)
        {
            double sum = 0;
            foreach (var item in data)
            {
                sum += item;
            }
            sum = sum / data.Length;
            return sum;
        }
        public static T Product2<T>(this IEnumerable<T> collection)
           where T :  IComparable
        {
            dynamic product = 1;
            foreach (var element in collection)
            {
                product *= element;
            }

            return product;
        }


        //        public int Sum<T>(this IEnumerable<T> data)
        //            where T : IAddable<T>, ISubstractable<T>
        //        {

        //        }
        //    }
        //}

        //public interface IAddable<T>
        //{
        //    T Add(T item);
        //}

        //public interface ISubstractable<T>
        //{
        //    T Substract(T item);
        //}

        //public class Serj : IAddable<Serj>, ISubstractable<Serj>
        //{
        //    public Serj Add(Serj item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Serj Substract(Serj item)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    //...
    }
}
