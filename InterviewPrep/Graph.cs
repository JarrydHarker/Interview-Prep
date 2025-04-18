using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class Graph<T>
    {
        private Dictionary<int, GraphNode<T>> nodeLookup = new Dictionary<int, GraphNode<T>>();

        public void AddNode(int id, T data)
        {
            nodeLookup.Add(id, new GraphNode<T>(id, data));
        }

        public GraphNode<T> GetNode(int id)
        {
            return nodeLookup[id];
        }

        public void AddEdges(int source, int destination)
        {
            GraphNode<T> s = GetNode(source);
            GraphNode<T> d = GetNode(destination);
            s.adjacents.AddFirst(d);
        }

        public bool HasPathDFS(int source, int destination)
        {
            GraphNode<T> s = GetNode(source);
            GraphNode<T> d = GetNode(destination);

            HashSet<int> visited = new HashSet<int>();

            return HasPathDFS(s, d, visited);
        }

        private bool HasPathDFS(GraphNode<T> source, GraphNode<T> destination, HashSet<int> visited)
        {
            if (visited.Contains(source.ID))
            {
                return false;
            }

            visited.Add(source.ID);

            if (source == destination)
            {
                return true;
            }

            foreach (GraphNode<T> child in source.adjacents)
            {
                if (HasPathDFS(child, destination, visited))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasPathBFS(int source, int destination)
        {
            return HasPathBFS(GetNode(source), GetNode(destination));
        }

        private bool HasPathBFS(GraphNode<T> source, GraphNode<T> destination)
        {
            Queue<GraphNode<T>> nextToVisit = new Queue<GraphNode<T>>();
            HashSet<int> visited = new HashSet<int>();

            nextToVisit.Enqueue(source);

            while (nextToVisit.Count > 0)
            {
                GraphNode<T> node = nextToVisit.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                if (visited.Contains(node.ID))
                {
                    continue;
                }

                visited.Add(node.ID);

                foreach (GraphNode<T> child in node.adjacents)
                {
                    nextToVisit.Enqueue(child);
                }
            }

            return false;
        }
    }

    public class GraphNode<T>
    {
        public int ID;
        T Data;

        public LinkedList<GraphNode<T>> adjacents = new LinkedList<GraphNode<T>>();

        public GraphNode(int ID, T Data)
        {
            this.ID = ID;
            this.Data = Data;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nData: {Data}";
        }
    }
}
