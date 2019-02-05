using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace TryInterfaces
{
    interface IMyComparable
    {
        int Compare(object obj);
    }

    class MyComparableClass : IMyComparable, IComparable, IFormattable
    {
        public int n { get; set; }

        public MyComparableClass(int nIN)
        {
            n = nIN;
        }

        int IMyComparable.Compare(object obj)
        {
            int m = ((MyComparableClass) obj).n;
            int mMinusn = m - n;
            if (mMinusn < 0) { return -1; }
            if (mMinusn == 0) return  0;
            if (mMinusn > 0) return  1;
            return 0;
        }

        int IComparable.CompareTo(object obj)
        {
            int m = ((MyComparableClass)obj).n;
            int mMinusn = m - n;
            if (mMinusn > 0) { return -1; }
            if (mMinusn == 0) return 0;
            if (mMinusn < 0) return 1;
            return 0;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return n.ToString();
        }
    }

    static class myFs
    {
        public static void ListInputF(List<int> list)
        {
            Debug.WriteLine(list.ToString());
        }

        public static void ICollectionInputF(ICollection<int> coll)
        {
            Debug.WriteLine(coll.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //MyComparableClass obj1 = new MyComparableClass(1);
            //MyComparableClass obj2 = new MyComparableClass(2);

            //Debug.WriteLine("obj1.Compare(obj1): " + obj1.Compare(obj2));
            //Debug.WriteLine("obj1.Compare(obj1): " + obj1.Compare(obj1));
            //Debug.WriteLine("obj2.Compare(obj1): " + obj2.Compare(obj1));


            List<IComparable> list = new List<IComparable>();
            list.Add(new MyComparableClass(1));
            list.Add(new MyComparableClass(3));
            list.Add(new MyComparableClass(0));
            list.Add(new MyComparableClass(-1));

            //Debug.WriteLine(list.ToString());


            for (int i = 0; i < list.Count; i++)
            {
                MyComparableClass obj = list[i] as MyComparableClass;
                Debug.WriteLine(obj.ToString("G", CultureInfo.CurrentCulture));
            }

            Debug.WriteLine("Sorting");

            list.Sort();


            for (int i = 0; i < 4; i++)
            {
                MyComparableClass obj = list[i] as MyComparableClass;
                Debug.WriteLine(obj.ToString("G", CultureInfo.CurrentCulture));
            }

            //ICollection<int> coll = (ICollection<int>)new LinkedList<int>();
            ICollection<int> coll = (ICollection<int>)new List<int>();
            coll.Add(1);
            coll.Add(7);
            coll.Add(-12);
            coll.Add(-1);

            Debug.WriteLine($"coll.Count = {coll.Count}");

            myFs.ListInputF(coll as List<int>);
            myFs.ICollectionInputF(coll);
        }


    }
}
