using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures
{
	public class Graph
	{
		private class Edge
		{
			public Object Source, Destination;
			public int Cost;
			public Edge(ref Object src, ref Object dst, int cost)
			{
				this.Source = src;
				this.Destination = dst;
				this.Cost = cost;
			}
		}

		List<Object> Nodes = new List<Object>();
		List<Edge> Edges = new List<Edge>();

		public int[,] AdjacencyMatrix
		{
			get
			{
				int[,] matrix = new int[Nodes.Count, Nodes.Count];

				foreach (Edge e in Edges)
				{
					matrix[Nodes.IndexOf(e.Source), Nodes.IndexOf(e.Destination)] = e.Cost;
					matrix[Nodes.IndexOf(e.Destination), Nodes.IndexOf(e.Source)] = e.Cost;
				}

				return matrix;
			}
		}

		public void AddNode(ref Object Object)
		{
			Nodes.Add(Object);
		}

		public void AddEdge(ref Object from, ref Object to, int cost)
		{
			Edges.Add(new Edge(ref from, ref to, cost));
		}
	}
}