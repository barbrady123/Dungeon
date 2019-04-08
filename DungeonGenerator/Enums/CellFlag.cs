using System;

namespace Whitehouse.Dungeon.Generator.Enums
{
	[Flags]
	public enum CellFlag
	{
		None = 0x00,

		Door = 0x01,

		StairsUp = 0x02,

		StairsDown = 0x04
	}
}
