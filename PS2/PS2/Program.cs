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


            // Parse n and k
            line = Console.ReadLine();
            int whitespaceIndex = line.IndexOf(" ");
            string n_Unparsed = line.Substring(0, whitespaceIndex);
            string k_Unparsed = line.Substring(whitespaceIndex + 1, line.Length - whitespaceIndex - 1);
            int n = int.Parse(n_Unparsed);
            int k = int.Parse(k_Unparsed);

            // LOOP Iterate by line for each new binary tree added.
            {
                /// Create a new SBT
                
                // LOOP Iterate across the line, parsing numbers and adding them to the tree
                {

                }

                // Iterate through all non-uunique trees, look for a match
                {
                    // If this tree matches a non-unique tree, add this tree to the non-unique tree list
                    //  Then break
                }

                // Iterate through all unique trees, look for a match
                {
                    // If this tree matches a unique tree, add this tree and the unique tree to the non-unique tree list
                        // Then break
                }
            }

        }
    }
}
