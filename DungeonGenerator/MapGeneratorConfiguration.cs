using System;
using System.Collections.Generic;
using System.Text;

namespace Whitehouse.Dungeon.Generator
{
	public class MapGeneratorConfiguration
	{
		// Map
		public int? MapSeed { get; set; }

		public int MapWidth { get; set; }

		public int MapHeight { get; set; }

		public int MapBorderX { get; set; }

		public int MapBorderY { get; set; }

		// Rooms
		public int RoomsNumberMin { get; set; }

		public int RoomsNumberMax { get; set; }

		public int RoomsWidthMin { get; set; }

		public int RoomsWidthMax { get; set; }

		public int RoomsHeightMin { get; set; }

		public int RoomsHeightMax { get; set; }
	}
}
