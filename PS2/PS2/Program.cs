using System;
using System.Collections.Generic;

namespace PS2
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            LinkedList<SimpleBinaryTree> uniqueTrees = new LinkedList<SimpleBinaryTree>();
            LinkedList<SimpleBinaryTree> nonUniqueTrees = new LinkedList<SimpleBinaryTree>();
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
                SimpleBinaryTree currentTree = new SimpleBinaryTree();

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
                foreach (SimpleBinaryTree tree in nonUniqueTrees)
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
                    foreach (SimpleBinaryTree tree in uniqueTrees)
                    {
                        // If this tree matches a unique tree, add this tree and the unique tree to the non-unique tree list// If this tree matches a non-unique tree, add this tree to the non-unique tree list
                        if (currentTree.Equals(tree))
                        {
                            nonUniqueTrees.AddLast(currentTree);
                            isUnique = false;
                            break;
                        }
                    }
                }

                // If reached, the tree is unique.  Increment the unique counter
                if (isUnique)
                {
                    uniqueTreeCount++;
                }

                
            }

            Console.WriteLine(uniqueTreeCount);

        }
    }
}
