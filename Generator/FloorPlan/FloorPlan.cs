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
		public FloorPlan(Room data) : base(data) { }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			Traverse(this, new DataStructures.TreeVisitor<Room>(delegate(Room room)
			{
				sb.AppendLine(String.Format("node: {0}, area: {1}", room.Type.ToString(), room.Area));
			}));

			return sb.ToString();
		}

		public int[] GetAreaArray()
		{
			List<int> list = new List<int>();

			Traverse(this, new DataStructures.TreeVisitor<Room>(delegate(Room r)
			{
				list.Add(r.Area);
			}));

			return list.ToArray();
		}
	}
}
