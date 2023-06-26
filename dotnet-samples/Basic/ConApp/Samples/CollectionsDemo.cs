using ConApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConApp
{
    public class Int16Collection : CollectionBase
    {
        public Int16 this[int index]
        {
            get
            {
                return ((Int16)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(Int16 value)
        {
            return (List.Add(value));
        }

        public int IndexOf(Int16 value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, Int16 value)
        {
            List.Insert(index, value);
        }

        public void Remove(Int16 value)
        {
            List.Remove(value);
        }

        public bool Contains(Int16 value)
        {
            // If value is not of type Int16, this will return false.
            return (List.Contains(value));
        }

        protected override void OnInsert(int index, Object value)
        {
            // Insert additional code to be run only when inserting values.
        }

        protected override void OnRemove(int index, Object value)
        {
            // Insert additional code to be run only when removing values.
        }

        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            // Insert additional code to be run only when setting values.
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Int16))
                throw new ArgumentException("value must be of type Int16.", "value");
        }
    }

    public class MyCollection1 : IEnumerable
    {
        public int[] Items = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public IEnumerator GetEnumerator()
        {
            foreach (int item in Items)
            {
                yield return item;
            }
        }
    }

    public class MyCollection2 : IEnumerable
    {
        public int[] Arr1 = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

        public IEnumerator GetEnumerator()
        {
            return new CusEnumerator(Arr1);
        }
    }

    public class CusEnumerator : IEnumerator
    {
        public int[] Arr;
        public int index = -1;

        public CusEnumerator(int[] arr)
        {
            Arr = arr;
        }

        public object Current => Arr[index];

        public bool MoveNext()
        {
            index++;
            if (Arr.Length > index)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class PersonClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }

    public class IndexClass
    {
        public List<PersonClass> ListPerson { get; set; }

        public PersonClass this[int id]
        {
            get { return ListPerson.First(m => m.Id == id); }
        }
    }

    public class CollectionsDemo
    {
        public static void PrintValues1(Int16Collection myCol)
        {
            foreach (Int16 i16 in myCol)
            {
                Console.WriteLine("   {0}", i16);
            }
            Console.WriteLine();
        }

        public static void PrintValues2(Int16Collection myCol)
        {
            IEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine("   {0}", myEnumerator.Current);
            }
            Console.WriteLine();
        }

        public static void PrintIndexAndValues(Int16Collection myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
            {
                Console.WriteLine("   [{0}]:   {1}", i, myCol[i]);
            }
            Console.WriteLine();
        }

        public static void CollectionDemo()
        {
            Int16Collection myI16 = new Int16Collection { 1, 2, 3, 5, 7 };

            Console.WriteLine("Contents of the collection (using foreach):");
            PrintValues1(myI16);

            Console.WriteLine("Contents of the collection (using enumerator):");
            PrintValues2(myI16);

            Console.WriteLine("Initial contents of the collection (using Count and Item):");
            PrintIndexAndValues(myI16);

            Console.WriteLine("Contains 3: {0}", myI16.Contains(3));
            Console.WriteLine("2 is at index {0}.", myI16.IndexOf(2));
            Console.WriteLine();

            myI16.Insert(3, 13);
            Console.WriteLine("Contents of the collection after inserting at index 3:");
            PrintIndexAndValues(myI16);

            myI16[4] = 123;
            Console.WriteLine("Contents of the collection after setting the element at index 4 to 123:");
            PrintIndexAndValues(myI16);

            myI16.Remove(2);

            Console.WriteLine("Contents of the collection after removing the element 2:");
            PrintIndexAndValues(myI16);
        }

        public static void PrintIntList(IEnumerable<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item.ToString().PadLeft(2, '0') + "\t");
            }
            Console.WriteLine();
        }

        public static void PrintIntList(List<int> list1, List<int> list2)
        {
            Console.Write("list1:");
            PrintIntList(list1);

            Console.WriteLine();
            PrintIntList(list1);
            Console.WriteLine();
        }

        /// <summary>
        /// 交集并集差集
        /// </summary>
        public static void ExceptIntersectUnion()
        {
            List<int> list1 = new List<int>
            {
                10, 1, 4, 5, 8
            };
            list1.Sort();

            List<int> list2 = new List<int>
            {
                1, 28, 4, 8, 18
            };
            list2.Sort();

            PrintIntList(list1, list2);
            Console.WriteLine("+++++++++++++++++++差集+++++++++++++++++++");
            IEnumerable<int> nList1 = list1.Except(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Except(list2)");
            PrintIntList(nList1);

            IEnumerable<int> nList2 = list2.Except(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Except(list1)");
            PrintIntList(nList2);

            Console.WriteLine("+++++++++++++++++++交集+++++++++++++++++++");
            IEnumerable<int> nList3 = list1.Intersect(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Intersect(list2)");
            PrintIntList(nList3);

            IEnumerable<int> nList4 = list2.Intersect(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Intersect(list1)");
            PrintIntList(nList4);

            Console.WriteLine("+++++++++++++++++++并集+++++++++++++++++++");
            IEnumerable<int> nList5 = list2.Union(list1);
            Console.WriteLine();
            Console.WriteLine("list2.Union(list1)");
            PrintIntList(nList5);

            IEnumerable<int> nList6 = list1.Union(list2);
            Console.WriteLine();
            Console.WriteLine("list1.Union(list2)");
            PrintIntList(nList6);
        }

        public static void Cus_foreach()
        {
            MyCollection1 myCol = new MyCollection1();
            foreach (var a in myCol)
            {
                Console.WriteLine(a);
            }

            MyCollection2 myCol2 = new MyCollection2();
            foreach (var m in myCol2)
            {
                Console.WriteLine(m);
            }
        }

        /*
             foreach (int i in YieldPower(2, 8))
             {
                 Console.Write("{0} ", i);
             }
         */

        public static IEnumerable YieldPower(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        public static object CreateGeneric(Type generic, Type innerType, params object[] args)
        {
            Type specificType = generic.MakeGenericType(innerType);
            return Activator.CreateInstance(specificType, args);
        }

        public static void CreateGenericDemo()
        {
            object genericList = CreateGeneric(typeof(List<>), typeof(Person));
            var orderList = genericList as List<Person>;
        }

        public static void StackDemo()
        {
            Stack stack = new Stack();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.Push("d");
            stack.Push("e");
            stack.Push("f");
            stack.Push("g");
            stack.Push("h");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);
        }

        private static void Index()
        {
            IndexClass ic = new IndexClass
            {
                ListPerson = new List<PersonClass>
                {
                    new PersonClass {Id = 1, Name = "User1"},
                    new PersonClass {Id = 2, Name = "User2"},
                    new PersonClass {Id = 3, Name = "User3"}
                }
            };
            Console.WriteLine(ic[2].Name);
        }

        public static void SortedListDemo()
        {
            SortedList sortedList = new SortedList
            {
                {3, 1},
                {15, 5},
                {5, 55},
                {9, 55}
            };
            ParallelQuery pq = sortedList.AsParallel();
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }

        #region HashtableDemo

        public static void HashtableDemo()
        {
            Hashtable hashtable1 = new Hashtable();
            hashtable1.Add("zd", "600719");
            hashtable1.Add("name", "denylau");
            hashtable1.Add("sex", "男");
            Console.WriteLine("Count：\t" + hashtable1.Count);

            ArrayList haskKeys = new ArrayList(hashtable1.Keys);
            ArrayList haskVals = new ArrayList(hashtable1.Values);

            foreach (string key in haskKeys)
            {
                Console.WriteLine("{0}:\t{1}", key, hashtable1[key]);
            }

            foreach (DictionaryEntry item in hashtable1)
            {
                Console.WriteLine("{0}:\t{1}", item.Key, item.Value);
            }

            IDictionaryEnumerator en = hashtable1.GetEnumerator();
            while (en.MoveNext())
            {
                Console.WriteLine("{0}:\t{1}", en.Key, en.Value);
            }

            foreach (var item in hashtable1.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in hashtable1.Values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("**********************************************************");
            Hashtable hashtableItem = new Hashtable();
            hashtableItem.Add("Name", "小红");
            hashtableItem.Add("Sex", "女");
            hashtableItem.Add("Age", 20);

            Hashtable hashtableItem1 = new Hashtable();
            hashtableItem1.Add("Name", "小王");
            hashtableItem1.Add("Sex", "男");
            hashtableItem1.Add("Age", 21);

            Hashtable hashtableItem2 = new Hashtable();
            hashtableItem2.Add("Name", "小李");
            hashtableItem2.Add("Sex", "男");
            hashtableItem2.Add("Age", 22);

            ArrayList list = new ArrayList(hashtableItem.Keys);
            list.Add(hashtableItem);
            list.Add(hashtableItem1);
            list.Add(hashtableItem2);
        }

        #endregion HashtableDemo

        #region TupleDemo

        public static List<Tuple<int, List<string>>> CreateTule()
        {
            List<Tuple<int, List<string>>> tuplerList = new List<Tuple<int, List<string>>>();
            Tuple<int, List<string>> tuples1 = Tuple.Create(1, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples2 = Tuple.Create(2, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples3 = Tuple.Create(3, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples4 = Tuple.Create(4, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples5 = Tuple.Create(5, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples6 = Tuple.Create(6, new List<string> { "xxxxxxx", "ccccccccc" });
            Tuple<int, List<string>> tuples7 = Tuple.Create(7, new List<string> { "xxxxxxx", "ccccccccc" });
            tuplerList.AddRange(new[] { tuples1, tuples2, tuples3, tuples4, tuples5, tuples6, tuples7 });
            return tuplerList;
        }

        public static void TupleDemo()
        {
            List<Tuple<int, List<string>>> vs = CreateTule();
            foreach (Tuple<int, List<string>> tuple in vs)
            {
                if (tuple.Item1 == 5)
                {
                    foreach (string s in tuple.Item2)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }

        #endregion TupleDemo
    }
}