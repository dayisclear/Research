using RTFP.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RTFP.Algorithms.MST
{
	public static class Prims
	{
		public static Graph FindMST(ref Object source, Graph graph)
		{
			// Setup our things
			var matrix = graph.AdjacencyMatrix;

			List<Graph.Edge> test = new List<Graph.Edge>();
			List<Object> visited = new List<Object>();
			Graph mst = new Graph();

			// Add our source node to our visited list
			visited.Add(source);

			// While we haven't visited all nodes
			while(visited.Count < graph.Size)
			{
				Object from = null, to = null;
				Graph.Edge min = null;

				// Check all paths leading from our connected nodes
				for(int j = 0; j < visited.Count; j++)
				{
					var node = visited[j];

					// interate across its connections to find a cheapest
					for (int i = 0; i < matrix.GetLength(0); i++)
					{
						var edge = matrix[graph.IndexOf(ref node), i];

						if (edge == null)
							continue;

						// we have found an edge leading from our connected to an unconnected and is cheaper
						if(	min == null || edge.Cost < min.Cost)
						{
							from = node;
							to = edge.Source == node ? edge.Destination : edge.Source;

							// we haven't visited this node yet
							if (!visited.Contains(to))
							{
								min = edge;
								to = null;
							}
						}
					}
				}

				if(min != null)
				{
					if(!visited.Contains(min.Destination))
						visited.Add(min.Destination);

					if (!visited.Contains(min.Source))
						visited.Add(min.Source);

					test.Add(min);
				}
			}

			foreach (var e in test)
				Console.WriteLine(e);

			return null;
		}
	}
}