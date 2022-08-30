using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class SGraph<T>//Simple Graph, based on Linked Vertex
    {
        Dictionary<int, LinkedVertex<T>> Vertices;
        public int VertexNum{ get; private set; }
        public SGraph()
        {
            Vertices = new Dictionary<int, LinkedVertex<T>>();
            VertexNum = 0;
        }

        public void AddVertex(LinkedVertex<T> vertex)
        {
            Vertices.Add(vertex.ID,vertex);
            VertexNum++;
        }

        public bool BFS(LinkedVertex<T> start,T target)
        {
            List<LinkedVertex<T>> pendingQueue = new List<LinkedVertex<T>>();
            Dictionary<int, bool> overQueue = new Dictionary<int, bool>();
            pendingQueue.Add(start);
            while (pendingQueue.Count != 0)
            {
                LinkedVertex<T> curVertex = pendingQueue[0];
                if (overQueue.ContainsKey(curVertex.ID))
                {
                    continue;
                }
                if (pendingQueue[0].Data.Equals(target))
                {
                    return true;
                }
                overQueue.Add(pendingQueue[0].ID,true);
                pendingQueue.RemoveAt(0);
                foreach (LinkedVertex<T> adjaVertex in curVertex.AdjaVertices)
                {
                    
                }
            }
            return false;
        }
    }
}
