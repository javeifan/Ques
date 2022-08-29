using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class SGraph<T>//Simple Graph, based on Linked Vertex
    {
        Dictionary<string, LinkedVertex<T>> Vertices;
        public int VertexNum{ get; private set; }
        public SGraph()
        {
            Vertices = new Dictionary<string, LinkedVertex<T>>();
            VertexNum = 0;
        }

        public void AddVertex(LinkedVertex<T> vertex)
        {
            VertexNum++;
        }
    }
}
