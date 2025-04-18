using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace InterviewPrep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stacks();
            //Queues();
            //PriorityQueues();
            //LinkedLists();
            /*string subStr = "";
            int k = 0;

            if (!subStr.Contains($"{subStr[k]}{subStr[k]}{subStr[k]}")) return i;

            List<string> list = new List<string> { "Cat", "Dog", "Unicorn", "Cow", "Hamster" };

            int index = LinearSearch(list, "Cat");

            if (index > -1) Console.WriteLine(list[index] + "\n");

            GenericMergeSort(list);

            foreach (string s in list) Console.WriteLine(s);*/

            /*Console.WriteLine($"\n{1}");
            PrintFibonacci(1000000000);*/

            //Graphs();

            /*HashTable<int> table = new HashTable<int>(9);

            table.Add(new HashValue<int>("John", 1));
            table.Add(new HashValue<int>("Mike", 3));
            table.Add(new HashValue<int>("Geoff", 8));
            table.Add(new HashValue<int>("Dick", 5));

            Console.WriteLine(table.Get("John").value);
            Console.WriteLine(table.Get("Mike").value);
            Console.WriteLine(table.Get("Geoff").value);
            Console.WriteLine(table.Get("Dick").value);*/

            int[] numbers = { 42, 7, 15, 88, 23, 3, 99, 56, 1, 67 };

            //QuickSort(numbers, 0, numbers.Length - 1);
            //BubbleSort(numbers);

            BucketSort(numbers, numbers.Length);

            foreach (int i in numbers)
            {
                Console.Write($"{i} ");
            }
        }

        public static void Graphs()
        {
            Graph<string> graph = new Graph<string>();

            graph.AddNode(1, "Nick");
            graph.AddNode(2, "Zoe");
            graph.AddNode(3, "Tristan");
            graph.AddNode(4, "Dave");
            graph.AddNode(5, "Glynn");

            graph.AddEdges(1, 2);
            graph.AddEdges(2, 3);
            graph.AddEdges(1, 4);
            graph.AddEdges(4, 5);

            bool yes = graph.HasPathDFS(1, 4);

            if (yes)
            {
                Console.WriteLine("DFS Found");
            } else
            {
                Console.WriteLine("Noooooo");
            }

            bool bfs = graph.HasPathBFS(1, 2);

            if (bfs)
            {
                Console.WriteLine("BFS path found");
            } else
            {
                Console.WriteLine("No");
            }
        }

        public static void PrintFibonacci(int num, int fibNum = 1, int prevNum = 0)
        {
            if (fibNum > num)
            {
                return;
            }

            int temp = fibNum;
            fibNum = fibNum + prevNum;

            prevNum = temp;
            Console.WriteLine($"{fibNum}");
            PrintFibonacci(num, fibNum, prevNum);
        }

        //Sliding Window Algorithm
        public int MaxLengthSubstring(string s) //variable size sliding window
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            int left = 0, maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                if (!frequency.ContainsKey(c))
                {
                    frequency[c] = 0;
                }

                frequency[c]++;

                while (frequency[c] > 2)
                {
                    frequency[s[left]]--;
                    if (frequency[s[left]] == 0)
                    {
                        frequency.Remove(s[left]);
                    }

                    left++;
                }

                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        //------------------------

        //Searching Algorithms

        public static int LinearSearch(IList collection, object searchObj) // O(n) time complexity
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] == searchObj)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int SimpleBinarySearch(IList<int> collection, int target)// Needs to be sorted 
        {
            int min = 0;
            int max = collection.Count - 1;

            while (min <= max)
            {
                int mid = min + (max - min) / 2;

                int value = collection[mid];

                if (value == target) return mid;
                else if (value < target) min = mid + 1;
                else max = mid - 1;
            }

            return -1;
        }

        public static int GenericBinarySearch<T>(IList<T> collection, T searchObj) where T : IComparable<T> // Needs to be sorted 
        {
            int min = 0;
            int max = collection.Count - 1;

            while (min <= max)
            {
                int middle = min + (max - min) / 2;
                int comparison = collection[middle].CompareTo(searchObj);

                if (comparison == 0) return middle;
                else if (comparison < 0) min = middle + 1;
                else max = middle - 1;
            }

            return -1;
        }
        //---------------------

        //Sorting Algorithms
        public static void GenericMergeSort<T>(IList<T> collection) where T : IComparable<T> //O(n log n) tim complexity
        {
            int length = collection.Count;
            int mid = length / 2;//Find the middle

            if (length <= 1) return;//Handle empty/single element list

            T[] left = new T[mid];//Split list in 2 down the middle
            T[] right = new T[length - mid];

            
            int j = 0;//Initialise pointer

            for (int i = 0; i < length; i++)
            {
                if (i < mid)
                {//Populate left subarray with elements left of mid
                    left[i] = collection[i];
                } else
                {//Populate right subarray with elements right of mid
                    right[j] = collection[i];
                    j++;
                }
            }

            GenericMergeSort(left);//Recursively call the method on both subarrays
            GenericMergeSort(right);

            GenericMerge(left, right, collection);//Use helper method to merge subarrays back into original list
        }
        private static void GenericMerge<T>(IList<T> left, IList<T> right, IList<T> collection) where T : IComparable<T>
        {
            int leftSize = collection.Count / 2;//calculate the size of both arrays
            int rightSize = collection.Count - leftSize;

            int i = 0, l = 0, r = 0; //initialise 3 pointers

            while (l < leftSize && r < rightSize) //run loop while pointers are smaller than the size of the respective array
            {
                int compare = left[l].CompareTo(right[r]);//CompareTo function returns -1 if the first value is less
                if (compare < 0)
                {
                    collection[i] = left[l]; //Add left value back into original array
                    i++;//increment the current position of i in the original array
                    l++;//increment the position of l in the left array
                } else
                {
                    collection[i] = right[r];//Add right value back into original array
                    i++;//increment the current position of i in the original array
                    r++;//increment the position of r in the right array
                }
            }

            while (l < leftSize)//if left was longer than right, add the remainder
            {
                collection[i] = left[l];
                i++;
                l++;
            }

            while (r < rightSize)//if right was longer than left, add the remainder
            {
                collection[i] = right[r];
                i++;
                r++;
            }
        }

        public static void QuickSort(IList<int> integers, int start, int end)//O(n log n) best/average case, O(n^2) worst case
        {
            if (end <= start) return;//handle invalid arguments
            
            int pivot = Partition(integers, start, end);//Call Partition helper method, to get pivot value

            QuickSort(integers, start, pivot - 1);//recursively call QuickSort on both sides of 
            QuickSort(integers, pivot + 1, end);
        }
        public static int Partition(IList<int> integers, int start, int end)
        {
            int temp = 0, i = start - 1, pivot = integers[end];//initialise temp, i to start minus 1, and pivot to the last value (see main method body)

            for (int j = start; j <= end - 1; j++)//for loop up to but not including the pivot
            {
                if (integers[j] < pivot)
                {//if the current value is lover than pivot, send it to the beginning of the list
                    i++;//increment the pointer
                    temp = integers[i];//simple swap with the pointer value
                    integers[i] = integers[j];
                    integers[j] = temp;
                }
            }

            i++;//increment i and do one final swap before returning i

            temp = integers[i];
            integers[i] = integers[end];
            integers[end] = temp;

            return i;
        }


        public static void BubbleSort(IList<int> integers) //O(n^2)
        {
            for (int i = 0; i < integers.Count - 1; i++)
            {
                for (int j = 0; j < integers.Count - i - 1; j++)
                {
                    if (integers[j] > integers[j + 1])
                    {
                        int temp = integers[j];
                        integers[j] = integers[j + 1];
                        integers[j + 1] = temp;
                    }
                }
            }
        }

        public static void RadixSort()
        {

        }

        public static void BucketSort(int[] nums, int bucketSize) //O(n + k) best case, O(n^2) worst case 
        {
            if(nums == null || nums.Length == 0 || bucketSize < 0) return;

            int minVal = nums[0], maxVal = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minVal) minVal = nums[i];
                else if (nums[i] > maxVal) maxVal = nums[i];
            }

            double range = Math.Ceiling((double)(maxVal - minVal) + 1) / bucketSize;

            LinkedList<int>[] buckets = new LinkedList<int>[bucketSize];

            for(int i  = 0; i < bucketSize; i++)
            {
                buckets[i] = new LinkedList<int>();
            }

            foreach(int num in nums)
            {
                int index = (int) ((num - minVal)/range);
                buckets[index].AddLast(num);
            }
            
            int j = 0;

            for(int i = 0; i < buckets.Length; i++)
            {
                var sorted = buckets[i].Order();
                foreach(int num in sorted)
                {
                    nums[j++] = num;    
                }
            }
        }

        //---------------------
        private static void LinkedLists()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddFirst("A");
            linkedList.AddLast("B");
            linkedList.AddLast("C");
            linkedList.AddLast("D");
            linkedList.AddLast("F");

            //PrintLinkedList(linkedList.First);

            string[] items = ReturnLinkedList(linkedList.First).ToArray();

            PrintLinkedList(linkedList.First);
            Console.WriteLine("\n-----------------------------\n");

            try
            {
                linkedList.AddAfter(FindNode(linkedList.First, "D"), "E");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            PrintLinkedList(linkedList.First);
            Console.WriteLine("\n-----------------------------\n");

            linkedList.Remove("E");

            PrintLinkedList(linkedList.First);
        }

        public static LinkedListNode<string>? FindNode(LinkedListNode<string> head, string value)
        {
            LinkedListNode<string> node = head;

            while (node != null)
            {
                if (node.Value == value) return node;
                node = node.Next;
            }

            return null;
        }

        public static List<string> ReturnLinkedList(LinkedListNode<string> node, List<string>? output = null) //Recursion 
        {
            if (node == null)
            {
                return output ?? new List<string>();
            }

            if (output == null)
            {
                output = new List<string>();
            }

            output.Add(node.Value);
            ReturnLinkedList(node.Next, output);

            return output;
        }

        public static void PrintLinkedList(LinkedListNode<string>? node) //Recursion 
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);
            PrintLinkedList(node.Next);
        }

        private static void PriorityQueues()
        {
            PriorityQueue<string, float> pQueue = new PriorityQueue<string, float>();
            Random random = new Random();

            Console.WriteLine("Priority Queues are LPFO (Lowest Priority First Out)");
            Console.WriteLine("Enqueue adds items to the pQueue\n");

            for (int i = 1; i < 6; i++)
            {
                float mark = (float)Math.Round(random.NextDouble() * 100, 2);
                pQueue.Enqueue($"Student {i}'s mark (Priority): {mark}", mark);
                Console.WriteLine($"Stored Item {i}");
            }

            Console.WriteLine("\nPeek accesses the first item on the pQueue without removing it");
            Console.WriteLine("Dequeue accesses the first item and removes it\n");

            while (pQueue.Count > 0)
            {
                Console.WriteLine($"Peek: {pQueue.Peek()}");
                Console.WriteLine($"Dequeue: {pQueue.Dequeue()}");
                Console.WriteLine($"{pQueue.Count} Items left in the queue\n");
            }
        }

        private static void Queues()
        {
            Queue<string> queue = new Queue<string>();

            Console.WriteLine("Queues are FIFO");
            Console.WriteLine("Enqueue adds items to the pQueue\n");

            for (int i = 1; i < 6; i++)
            {
                queue.Enqueue($"Item {i}");
                Console.WriteLine($"Stored Item {i}");
            }

            Console.WriteLine("\nPeek accesses the first item on the pQueue without removing it");
            Console.WriteLine("Dequeue accesses the first item and removes it\n");

            while (queue.Count > 0)
            {
                Console.WriteLine($"Peek: {queue.Peek()}");
                Console.WriteLine($"Dequeue: {queue.Dequeue()}");
                Console.WriteLine($"{queue.Count} Items left in the stack\n");
            }
        }

        public static void Stacks()
        {
            Stack<string> stack = new Stack<string>();

            Console.WriteLine("Stacks are LIFO");
            Console.WriteLine("Push adds items to the stack\n");
            for (int i = 1; i < 6; i++)
            {
                stack.Push($"Item {i}");
                Console.WriteLine($"Stored Item {i}");
            }

            Console.WriteLine("\nPeek accesses the last item on the stack without removing it");
            Console.WriteLine("Pop accesses the last item and removes it\n");

            while (stack.Count > 0)
            {
                Console.WriteLine($"Peek: {stack.Peek()}");
                Console.WriteLine($"Pop: {stack.Pop()}");
                Console.WriteLine($"{stack.Count} Items left in the stack\n");
            }
        }
    }
}
