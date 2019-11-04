using System;
using System.Collections.Generic;
using System.Text;

namespace self_balancing_tree
{
    class Node
    {

        public int Value { get; set; }
        public int Height { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
