using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class Graph//图
    {
        private const int Number = 10;//图所能包含的顶点的数量
        private int VertNo;//顶点数量
        private Vertex[] Vertexes;
        public int[,] AdjaMatrix;//邻接矩阵

        public Graph()
        {
            Vertexes = new Vertex[Number];
            AdjaMatrix = new int[Number,Number];
        }
    }
}
