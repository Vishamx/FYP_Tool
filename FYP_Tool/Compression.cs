using System;
using System.Collections.Generic;
using System.Text;

namespace FYP_Tool
{
    public class Compression
    {
        // Inner class to represent a node in the Huffman tree
        public class HuffmanNode
        {
            public char Symbol { get; set; }
            public int Frequency { get; set; }
            public HuffmanNode Left { get; set; }
            public HuffmanNode Right { get; set; }
        }

        private static HuffmanNode root; 

        // Method to compress data using Huffman coding
        public static string Compress(string data)
        {
            // Step 1: Perform frequency analysis
            Dictionary<char, int> frequencies = CalculateFrequencies(data);

            // Step 2: Build Huffman tree
            root = BuildHuffmanTree(frequencies); 

            // Step 3: Generate Huffman codes
            Dictionary<char, string> codes = GenerateHuffmanCodes(root);

            // Step 4: Encode the data using Huffman codes
            string encodedData = EncodeData(data, codes);

            return encodedData;
        }

        // Method to perform frequency analysis
        private static Dictionary<char, int> CalculateFrequencies(string data)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            foreach (char c in data)
            {
                if (frequencies.ContainsKey(c))
                    frequencies[c]++;
                else
                    frequencies[c] = 1;
            }

            return frequencies;
        }

        // Method to build Huffman tree
        private static HuffmanNode BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            PriorityQueue<HuffmanNode> priorityQueue = new PriorityQueue<HuffmanNode>();

            // Create a leaf node for each character and add it to the priority queue
            foreach (KeyValuePair<char, int> kvp in frequencies)
            {
                HuffmanNode node = new HuffmanNode { Symbol = kvp.Key, Frequency = kvp.Value };
                priorityQueue.Enqueue(node, node.Frequency);
            }

            // Build the Huffman tree
            while (priorityQueue.Count > 1)
            {
                HuffmanNode left = priorityQueue.Dequeue();
                HuffmanNode right = priorityQueue.Dequeue();

                HuffmanNode parent = new HuffmanNode { Frequency = left.Frequency + right.Frequency, Left = left, Right = right };
                priorityQueue.Enqueue(parent, parent.Frequency);
            }

            // Return the root of the Huffman tree
            return priorityQueue.Dequeue();
        }

        // Method to generate Huffman codes
        private static Dictionary<char, string> GenerateHuffmanCodes(HuffmanNode root)
        {
            Dictionary<char, string> codes = new Dictionary<char, string>();
            GenerateHuffmanCodesRecursive(root, "", codes);
            return codes;
        }

        private static void GenerateHuffmanCodesRecursive(HuffmanNode node, string code, Dictionary<char, string> codes)
        {
            if (node == null)
                return;

            if (node.Left == null && node.Right == null)
            {
                codes[node.Symbol] = code;
                return;
            }

            GenerateHuffmanCodesRecursive(node.Left, code + "0", codes);
            GenerateHuffmanCodesRecursive(node.Right, code + "1", codes);
        }

        // Method to encode data using Huffman codes
        private static string EncodeData(string data, Dictionary<char, string> codes)
        {
            StringBuilder encodedData = new StringBuilder();

            foreach (char c in data)
            {
                encodedData.Append(codes[c]);
            }

            return encodedData.ToString();
        }

        // Method to decompress data using Huffman coding
        public static string Decompress(string compressedData, HuffmanNode root)
        {
            StringBuilder decompressedData = new StringBuilder();
            HuffmanNode current = root;

            foreach (char bit in compressedData)
            {
                if (bit == '0')
                    current = current?.Left; // Use null-conditional operator to handle null current node
                else if (bit == '1')
                    current = current?.Right; // Use null-conditional operator to handle null current node

                if (current.Left == null && current.Right == null)
                {
                    decompressedData.Append(current.Symbol);
                    current = root;
                }
            }

            return decompressedData.ToString();
        }

        // Method to get the root node of the Huffman tree
        public static HuffmanNode GetRootNode()
        {
            return root;
        }

        // Priority queue implementation for Huffman tree construction
        private class PriorityQueue<T>
        {
            private SortedDictionary<int, Queue<T>> dictionary = new SortedDictionary<int, Queue<T>>();

            public int Count { get; private set; }

            public void Enqueue(T item, int priority)
            {
                if (!dictionary.ContainsKey(priority))
                {
                    dictionary[priority] = new Queue<T>();
                }
                dictionary[priority].Enqueue(item);
                Count++;
            }

            public T Dequeue()
            {
                if (Count == 0)
                    throw new InvalidOperationException("Queue is empty.");

                int priority = dictionary.Keys.First();
                T item = dictionary[priority].Dequeue();
                if (dictionary[priority].Count == 0)
                    dictionary.Remove(priority);
                Count--;
                return item;
            }
        }
    }
}
