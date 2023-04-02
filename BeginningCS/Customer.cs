using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ques.BeginningCS
{
    class Customer : IEnumerable
    {
        public string Name { get; set; }

        public List<Order> OrderList { get; set; }

        public Orders orders;
        public class Order
        {
            public string ID { get; set; }
            
            public Order(string iD)
            {
                ID = iD;
            }

            public Order()
            {
            }
        }

        public class Orders
        {
            public List<Order> orderList;
            public Order this[string ID]//should have a least one accessor
            {
                get { return orderList.Where(s => s.ID == ID).First(); }
            }
        }

        

        public virtual void testVirtual()
        {

        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < orders?.orderList.Count; i++)
            {
                yield return orders.orderList[i];
            }
        }
    }

    class Animals: CollectionBase
    {

    }

    abstract class AbstractCustomer
    {
        public string name;
        public void testMethod()
        {
            Console.WriteLine("Good");
        }

        protected AbstractCustomer(string name)
        {
            this.name = name;
        }

        protected AbstractCustomer()
        {
        }

        protected abstract void testAbstract();//virtual or abstract method cannot be private
    }

    class GoodCustomer : AbstractCustomer
    {
        public GoodCustomer()
        {
        }

        public GoodCustomer(string name) : base(name)
        {
            this.name = name;
        }

        protected override void testAbstract()
        {
            Console.WriteLine("Override testAbstract()");
        }
        
        //define implicit conversion operator
        //if a implicit conversion operator defined, we can do both implicit and explicit
        //don't need to specify the return value type because this is defined like constructor
        public static implicit operator BadCustomer(GoodCustomer gc)
        {
            BadCustomer bc = new BadCustomer();
            bc.name = gc.name;
            return bc;
        }

        public static void test()
        {
            BadCustomer bc = new GoodCustomer();
            GoodCustomer gc = (GoodCustomer)bc;
        }
    }

    class BadCustomer : AbstractCustomer
    {
        protected override void testAbstract()
        {
            throw new NotImplementedException();
        }

        public static implicit operator GoodCustomer(BadCustomer bc)
        {
            GoodCustomer gc = new GoodCustomer();
            gc.name = bc.name;
            return gc;
        }
    }

    class SmallGoodCustomer : GoodCustomer
    {
        public SmallGoodCustomer()
        {
        }

        public SmallGoodCustomer(string name) : base(name)
        {
        }


        public void test()
        {
            SmallGoodCustomer sgc = new SmallGoodCustomer();
            GoodCustomer gc = new GoodCustomer();
            sgc = gc as SmallGoodCustomer;//this doesn't throw exceptions when it can't process.
            Console.WriteLine(sgc);//write null
            sgc = (SmallGoodCustomer)gc;
            Console.WriteLine(sgc);
        }


    }
}
