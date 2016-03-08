using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;

namespace RTFP.Algorithms.MST
{
	public static class Prims
	{
		public static List<Graph.Edge> FindMST(Object source, Graph graph)
		{
			var matrix = graph.AdjacencyMatrix;

			List<Graph.Edge> mst = new List<Graph.Edge>();
			List<Object> visited = new List<Object>();

			// Add our source node to our visited list
			visited.Add(source);

			// While we haven't visited all nodes
			while(visited.Count < graph.Size)
			{
				Graph.Edge min = null;

				// Check all paths leading from our connected nodes
				foreach(var node in visited)
				{
					// Iterate across its connections to find a cheaper
					// edge
					for (int i = 0; i < matrix.GetLength(0); i++)
					{
						var edge = matrix[graph.IndexOf(node), i];

						// We have found an edge leading from our connected to 
						// an unconnected and is cheaper
						if(edge != null)
						{
							if (min == null || edge.Cost < min.Cost)
							{
								var to = edge.Source == node ? edge.Destination : edge.Source;

								// we haven't visited this node yet
								if (!visited.Contains(to))
									min = edge;
							}
						}
					}
				}

				// If we have found a new minimum edge, lets add it to our mst
				if(min != null)
				{
					if(!visited.Contains(min.Destination))
						visited.Add(min.Destination);

					if (!visited.Contains(min.Source))
						visited.Add(min.Source);

					mst.Add(min);
				}
			}

			return mst;
		}

		// TODO: Change this to a unit test
		public static void TestPrim()
		{
			Graph tree = new Graph();

			Object a = "a";
			Object b = "b";
			Object c = "c";
			Object d = "d";
			Object e = "e";
			Object f = "f";
			Object g = "g";

			tree.AddEdge(a, b, 2);
			tree.AddEdge(a, c, 3);
			tree.AddEdge(a, d, 3);

			tree.AddEdge(b, a, 2);
			tree.AddEdge(b, c, 4);
			tree.AddEdge(b, e, 3);

			tree.AddEdge(c, a, 3);
			tree.AddEdge(c, b, 4);
			tree.AddEdge(c, e, 1);
			tree.AddEdge(c, d, 5);
			tree.AddEdge(c, f, 6);

			tree.AddEdge(d, a, 3);
			tree.AddEdge(d, c, 5);
			tree.AddEdge(d, f, 7);

			tree.AddEdge(f, d, 7);
			tree.AddEdge(f, c, 6);
			tree.AddEdge(f, e, 8);

			tree.AddEdge(f, g, 9);

			var mst = Algorithms.MST.Prims.FindMST(a, tree);

			foreach (var n in mst) Console.WriteLine(n);

			/*

			Expected output:
				b -> a
				c -> a
				c -> e
				d -> a
				f -> c
				f -> g

			*/
		}
	}
}