using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures.Geometry
{
	public class Edge
	{
		Vertex Source, Destination;
		public Edge(Vertex src, Vertex dst)
		{
			this.Source = src; this.Destination = dst;
		}
	}
}