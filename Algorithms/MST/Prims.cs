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
	}
}