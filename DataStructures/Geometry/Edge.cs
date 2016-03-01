using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures.Geometry
{
	public class Edge
	{
		public Vertex Source, Destination;

		public Edge(ref Vertex src, ref Vertex dst)
		{
			this.Source = src; this.Destination = dst;
		}

		public override string ToString()
		{
			return String.Format("{0} -> {1}", Source, Destination);
		}
	}
}