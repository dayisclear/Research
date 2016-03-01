using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.Generator.FloorPlan
{
	public enum RoomType
	{
		LivingRoom,
		BedRoom,
		Kitchen,
		Bathroom,
		ExtraRoom
	}

	public class RoomNode
	{
		public RoomType Type { get; set; }
		public int Area { get; set; }
		public LinkedList<RoomNode> Children { get; set; }

		public RoomNode(RoomType type)
		{
			this.Type = type;
			this.Children = new LinkedList<RoomNode>();
		}

		public FloorPlan ToFloorPlan()
		{
			return null;
		}
	}
}
