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

        public int BFS(LinkedVertex<T> start,T target)//返回最短距离 -1表示
        {
            List<KeyValuePair<LinkedVertex<T>, int>> pendingQueue = new List<KeyValuePair<LinkedVertex<T>, int>>();
            Dictionary<int, int> overQueue = new Dictionary<int, int>();//key : ID Value : Hierarchy
            pendingQueue.Add(new KeyValuePair<LinkedVertex<T>, int>(start,0));
            while (pendingQueue.Count != 0)
            {
                LinkedVertex<T> curVertex = pendingQueue[0].Key;
                int hierarchy = pendingQueue[0].Value;
                if (curVertex.Data.Equals(target))
                {
                    return hierarchy;
                }
                overQueue.Add(curVertex.ID,hierarchy);
                pendingQueue.RemoveAt(0);
                foreach (LinkedVertex<T> adjaVertex in curVertex.AdjaVertices)
                {
                    if (overQueue.ContainsKey(adjaVertex.ID)) continue;
                    pendingQueue.Add(new KeyValuePair<LinkedVertex<T>, int>(adjaVertex,hierarchy+1));
                }
            }
            return -1;
        }

        public SGraph<int> getGraphSample()
        {
            return null;
        }
    }
}
