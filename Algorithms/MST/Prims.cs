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
		public static bool FindMST(int source, int[,] matrix)
		{
			List<int> mst = new List<int>();
			mst.Add(source);

			// While we haven't added all our nodes to the mst
			while(mst.Count < matrix.Length)
			{
				int from = Int32.MinValue;
				int min = Int32.MaxValue;

				// Iterate across current mst nodes and find cheapest edge
				for(int i = 0; i < mst.Count; i++)
				{
					// Iterate across mst node's connections looking for a better min
					for (int j = 0; j < matrix.Length; j++)
					{
						int current = mst[i];

						// Make sure edge is better than min and connected
						if (matrix[current, j] < min && matrix[current, j] > 0)
						{
							// Make sure we haven't already visited the node
							if (!mst.Contains(matrix[current, j]))
							{
								min = i;
								from = mst[i];
							}
						}
					}
				}

				// If we successfully found a cheap path lets add it to the mst
				if(min != Int32.MaxValue && from != Int32.MinValue)
				{
					mst.Add(min);
				}
				else return false;
			}

			return true;
		}
	}
}