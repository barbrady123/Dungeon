using System.Collections.Generic;

namespace Whitehouse.Dungeon.Generator.Models
{
	public class Path
	{
		public List<Cell> Cells { get; set; }

		public Path(List<Cell> cells = null)
		{
			this.Cells = cells ?? new List<Cell>();
		}
	}
}
