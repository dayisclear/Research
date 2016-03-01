using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.DataStructures.Geometry
{
	public class Vertex
	{
		public int X, Y;

		public Vertex(int x, int y)
		{
			this.X = x; this.Y = y;
		}

		public void Add(Vertex v2)
		{
			this.X += v2.X;
			this.Y += v2.Y;
		}

		public static Vertex operator +(Vertex v1, Vertex v2)
		{
			v1.X += v2.X;
			v1.Y += v2.Y;

			return v1;
		}
	}
}