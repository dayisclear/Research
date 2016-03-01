using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;
using RTFP.DataStructures.Geometry;
using RTFP.Generator.FloorPlan;

namespace RTFP.Generator.FloorPlan
{
	public class FloorPlan
	{
		List<Edge> Edges { get; set; }
		List<Vertex> Vertices { get; set; }
	}
}
