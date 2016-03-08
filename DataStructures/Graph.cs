using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures
{
	public class Graph
	{
		public class Edge
		{
			public Object Source, Destination;
			public int Cost;
			public Edge(ref Object src, ref Object dst, int cost)
			{
				this.Source = src;
				this.Destination = dst;
				this.Cost = cost;
			}
			public override string ToString()
			{
				return String.Format("{0} -> {1}", Source, Destination);
			}
		}

		List<Object> Nodes = new List<Object>();
		List<Edge> Edges = new List<Edge>();

		public Edge[,] AdjacencyMatrix
		{
			get
			{
				Edge[,] matrix = new Edge[Nodes.Count, Nodes.Count];

				foreach (Edge e in Edges)
				{
					int x = Nodes.IndexOf(e.Source);
					int y = Nodes.IndexOf(e.Destination);
					matrix[Nodes.IndexOf(e.Source), Nodes.IndexOf(e.Destination)] = e;
					matrix[Nodes.IndexOf(e.Destination), Nodes.IndexOf(e.Source)] = e;
				}

				return matrix;
			}
		}

		public int Size
		{
			get { return Nodes.Count; }
		}

		public int IndexOf(ref Object Object)
		{
			return Nodes.IndexOf(Object);
		}

		public void AddNode(ref Object Object)
		{
			Nodes.Add(Object);
		}

		public void AddEdge(ref Object from, ref Object to, int cost)
		{
			if (!Nodes.Contains(from))
				AddNode(ref from);

			if (!Nodes.Contains(to))
				AddNode(ref to);

			Edges.Add(new Edge(ref from, ref to, cost));
		}
	}
}