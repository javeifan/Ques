using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques.Collections
{
    class Vertex//图的顶点 用邻接矩阵表示顶点关系
    {
        public string Data { get; set; }
        public int Id { get; set; }

        public Vertex(string data, int id)
        {
            Data = data;
            this.Id = id;
        }
    }
}
