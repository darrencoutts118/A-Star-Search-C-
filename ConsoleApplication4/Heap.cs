using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Heap
    {

        public Dictionary<int, List<Node>> heap = new Dictionary<int, List<Node>>();

        public Heap()
        {
            this.heap = new Dictionary<int, List<Node>>();
        }

        public void push(int pri, Node node)
        {
            List<Node> thiselm = null;
            if (this.heap.ContainsKey(pri))
            {
                thiselm = this.heap[pri];
            }
            else
            {
                thiselm = new List<Node>();
            }
            thiselm.Add(node);
            this.heap[pri] = thiselm;
        }

        public void pop(int pri)
        {
            List<Node> thiselm = this.heap[pri];
            thiselm.RemoveAt(thiselm.Count-1);
            this.heap[pri] = thiselm;
        }

        public Node getTopItem(int pri)
        {
            List<Node> thiselm = this.heap[pri];
            return thiselm[thiselm.Count - 1];
        }

    }
}
