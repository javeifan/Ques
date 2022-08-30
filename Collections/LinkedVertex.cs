using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class LinkedVertex<T>//define adjacent vertices
    {
        public int ID { get;private set; }
        public T Data{ get; set; }

        public List<LinkedVertex<T>> AdjaVertices;
        //Vertices next to this in directed graph. Adjacent vertices in undirected graph.
        //CRUD all are fast.

        public LinkedVertex()
        {
        }

        public LinkedVertex(int iD, T data)
        {
            ID = iD;
            Data = data;
            AdjaVertices = new List<LinkedVertex<T>>();
        }

        public void AddAdjaVertice(LinkedVertex<T> vertex)
        {
            AdjaVertices.Add(vertex);
        }

        public void RemoveAdjaVertice(LinkedVertex<T> vertex)
        {
            AdjaVertices.Remove(vertex);
        }
    }
}
