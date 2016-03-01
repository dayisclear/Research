/*
Based off of Real-time Procedural Generation of Building Floor Plans paper
by Maysam Mirahmadi and Abdallah Shami of The University of Western Ontario
http://arxiv.org/pdf/1211.5842.pdf
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;

using RTFP.Generator;
using RTFP.Generator.Constraints;
using RTFP.Generator.FloorPlan;

namespace RTFP.Generator.FloorPlan
{
	public class SuburbanGenerator : FloorPlanGenerator
	{
		public ConstraintSet Constraints { get; set; }

		public SuburbanGenerator()
		{
			// using sample constraint set until constraint stuff is finished
			Constraints = new ConstraintSet();

			// Temporary constraints until we add building grammar
			Constraints.Add("LivingRooms", new MinMax(1, 1));
			Constraints.Add("AreaLivingRooms", new MinMax(400, 500));

			Constraints.Add("BedRooms", new MinMax(1, 2));
			Constraints.Add("AreaBedRooms", new MinMax(400, 500));

			Constraints.Add("Bathrooms", new MinMax(0, 1));
			Constraints.Add("AreaBathrooms", new MinMax(200, 200));

			Constraints.Add("Kitchens", new MinMax(0, 1));
			Constraints.Add("AreaKitchens", new MinMax(200, 200));

			Constraints.Add("ExtraRoom", new MinMax(0, 1));
			Constraints.Add("AreaCloset", new MinMax(100, 100));
		}

		public FloorPlan GenerateFloorPlan()
		{
			RoomNode main = GenerateValidRoom(RoomType.LivingRoom);

			int bedrooms = (int) Constraints.GenerateValue("BedRooms");
			int bathrooms = (int) Constraints.GenerateValue("Bathrooms");
			int kitchens = (int) Constraints.GenerateValue("Kitchens");

			// generate bed rooms
			for(int i = 0; i < bedrooms; i++)
				main.Children.AddFirst(GenerateValidRoom(RoomType.BedRoom));

			// genrate bathroom
			for (int i = 0; i < bathrooms; i++)
				main.Children.AddFirst(GenerateValidRoom(RoomType.Bathroom));

			// generate kitchen
			for (int i = 0; i < kitchens; i++)
				main.Children.AddFirst(GenerateValidRoom(RoomType.Kitchen));
			
			return main.ToFloorPlan();
		}

		private RoomNode GenerateValidRoom(RoomType type)
		{
			RoomNode room = new RoomNode(type);
			switch(type)
			{
				case RoomType.LivingRoom:
					room.Area = (int) Constraints.GenerateValue("AreaLivingRooms");
					break;

				case RoomType.BedRoom:
					room.Area = (int) Constraints.GenerateValue("AreaBedRooms");

					// If constraints told us we get an extra room, lets add it (closet
					// is an example of an extra room)
					if ((int) Constraints.GenerateValue("ExtraRoom") > 0)
						room.Children.AddFirst(GenerateValidRoom(RoomType.ExtraRoom));

					break;

				case RoomType.Kitchen:
					room.Area = (int) Constraints.GenerateValue("AreaKitchens");
					break;

				case RoomType.Bathroom:
					room.Area = (int) Constraints.GenerateValue("AreaBathrooms");
					break;

				case RoomType.ExtraRoom:
					room.Area = (int)Constraints.GenerateValue("AreaCloset");
					break;
			}
			return room;
		}
	}
}