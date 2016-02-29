using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.Generator.FloorPlan;

namespace RTFP.Generator.FloorPlan
{
	public class FloorPlan : DataStructures.GenericTree<Room>
	{
		public FloorPlan(Room data) : base(data)
		{

		}
	}
}
