using System;
using System.Collections.Generic;

namespace PS2
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            LinkedList<BinaryTreeShape> uniqueTrees = new LinkedList<BinaryTreeShape>();
            LinkedList<BinaryTreeShape> nonUniqueTrees = new LinkedList<BinaryTreeShape>();
            int uniqueTreeCount = 0;


            // Parse n and k
            line = Console.ReadLine();
            int whitespaceIndex = line.IndexOf(" ");
            string n_Unparsed = line.Substring(0, whitespaceIndex);
            string k_Unparsed = line.Substring(whitespaceIndex + 1, line.Length - whitespaceIndex - 1);
            int n = int.Parse(n_Unparsed);
            int k = int.Parse(k_Unparsed);

            // LOOP Iterate by line for each new binary tree added.
            for (int current = 1; current <= n; current++)
            {
                // Get the next line so we can begin parsing it
                line = Console.ReadLine();
                
                // Create a new SBT
                BinaryTreeShape currentTree = new BinaryTreeShape();

                // LOOP Iterate across the line, parsing numbers and adding them to the tree
                string unparsedCRV;
                int collapseResistanceValue;

                // For layers 1 through k-1, parse CRVs and add them to tree
                for (int layer = 1; layer < k; layer ++)
                {
                    whitespaceIndex = line.IndexOf(" ");        // Find the next space separating unparsed values
                    unparsedCRV = line.Substring(0, whitespaceIndex);   // Get the unparsed integer from the line
                    line = line.Substring(whitespaceIndex + 1, line.Length - whitespaceIndex - 1);  // Save the rest of the line for later extractions
                    collapseResistanceValue = int.Parse(unparsedCRV);   // Parse the CRV into an int
                    currentTree.Add(collapseResistanceValue);   // Add the CRV to the tree
                }
                // Special case: layer k.  Parse CRV and add to the tree
                collapseResistanceValue = int.Parse(line);
                currentTree.Add(collapseResistanceValue);

                // Tells whether this tree is unique.  Innocent until proven guilty.
                bool isUnique = true;
                
                // Iterate through all non-uunique trees, look for a match
                foreach (BinaryTreeShape tree in nonUniqueTrees)
                {
                    // If this tree matches a non-unique tree, add this tree to the non-unique tree list
                    if (currentTree.Equals(tree))
                    {
                        nonUniqueTrees.AddLast(currentTree);
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    // Iterate through all unique trees, look for a match
                    foreach (BinaryTreeShape tree in uniqueTrees)
                    {
                        // If this tree matches a unique tree, add this tree and the unique tree to the non-unique tree list// If this tree matches a non-unique tree, add this tree to the non-unique tree list
                        if (currentTree.Equals(tree))
                        {
                            nonUniqueTrees.AddLast(currentTree);
                            // We don't need to add tree to non-Unique trees, since its shape is already represented by currentTree
                            uniqueTrees.Remove(tree);
                            isUnique = false;
                            uniqueTreeCount--;
                            break;
                        }
                    }
                }

                // If reached, the tree is unique.  Increment the unique counter
                if (isUnique)
                {
                    uniqueTrees.AddLast(currentTree);
                    uniqueTreeCount++;
                }

                
            }

            int nonUniqueTreeShapeCount = nonUniqueTrees.Count;

            Console.WriteLine(uniqueTreeCount + nonUniqueTreeShapeCount);
        }
    }










    class BinaryTreeShape
    {
        private Dictionary<int, int> nodes;
        private HashSet<int> leafNodes;
        private int size;

        /// <summary>
        /// Creates a simple binary tree.
        /// </summary>
        public BinaryTreeShape()
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

                if (!nodes.TryGetValue(loc, out locValue))
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
        public bool Equals(BinaryTreeShape t)
        {
            if (this.size != t.size)
            {
                throw new Exception("Trying to compare trees of different size.  Something is wrong");
            }

            foreach (int leafLocation in this.leafNodes)
            {
                if (!t.leafNodes.Contains(leafLocation))
                {
                    return false;   // If one SBT contains a leaf that another does not, they are not equal
                }
            }
            return true;    // If reached, both contain all the same leafs
        }
    }
}
