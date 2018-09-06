using System;
using System.Collections.Generic;
using System.Text;

namespace PS2
{
    class SimpleBinaryTree
    {
        private Dictionary<int, int> nodes;
        private HashSet<int> leafNodes;
        private int size;
        
        /// <summary>
        /// Creates a simple binary tree.
        /// </summary>
        public SimpleBinaryTree()
        {
            nodes = new Dictionary<int, int>();
            leafNodes = new HashSet<int>();
        }

        /// <summary>
        /// Adds an integer to the tree.
        /// </summary>
        /// <param name="n"></param>
        public void Add(int value)
        {
            int loc = 0;
            bool spaceFound = false;

            while (spaceFound == false)
            {
                int locValue;

                if (! nodes.TryGetValue(loc, out locValue))
                {                    
                    nodes.Add(loc, value);  // If there is not already a node at this location, create one with this value
                    leafNodes.Add(loc);     // Any new node is a leaf node, until a leaf node is added below it
                    spaceFound = true;
                }
                else
                {                    
                    leafNodes.Remove(loc); // Remove loc from leafNodes, since it is no longer a leaf

                    // Do a comparison, decide whethere to advance left or right from the current node
                    if (value < locValue)
                    {                        
                        loc = (loc * 2) + 1;  // Make loc the left child of loc
                    }
                    else
                    {
                        loc = (loc * 2) + 2;  // Make loc the right child of loc
                    }
                }                
            }

            size++;
        }
        

        /// <summary>
        /// Compares two simple binary trees for tree shape.  Node values are not considered when comparing for tree shape.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Equals(SimpleBinaryTree t)
        {
            if (this.size != t.size)
            {
                throw new Exception("Trying to compare trees of different size.  Something is wrong");
            }

            foreach (int leafLocation in this.leafNodes)
            {
                if (! t.leafNodes.Contains(leafLocation))
                {
                    return false;   // If one SBT contains a leaf that another does not, they are not equal
                }
            }
            return true;    // If reached, both contain all the same leafs
        }






    }
}
