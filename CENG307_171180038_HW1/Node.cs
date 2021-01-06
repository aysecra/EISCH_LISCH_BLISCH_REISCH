using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENG307_171180038_HW1
{
    class Node
    {
        private int data;
        private int link;
        public Node()
        {
            data = -1;
            link = -1;
        }
        public Node(int data, int link  = -1)
        {
            this.data = data;
            this.link = link;
        }

        public int Data { get => data; set => data = value; }
        public int Link { get => link; set => link = value; }
    }
}
