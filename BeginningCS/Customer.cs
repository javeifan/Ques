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
        public static implicit operator BadCustomer(GoodCustomer gc)
        {
            BadCustomer bc = new BadCustomer();
            bc.name = gc.name;
            return bc;
        }
        
    }

    class BadCustomer : AbstractCustomer
    {
        protected override void testAbstract()
        {
            throw new NotImplementedException();
        }
    }
}
