using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Whitehouse.Dungeon.Generator.Enums;
using Whitehouse.Dungeon.Generator.Util;

namespace Whitehouse.Dungeon.Generator.Util
{
	public class RandomGenerator
	{
		private Random _random;

		public int Seed { get; }

		public RandomGenerator(int? seed = null)
		{
			this.Seed = seed ?? GenerateSeed();
			_random = new Random(this.Seed);
		}

		public int GetInteger(int min = 0, int max = 99)
		{
			return _random.Next(min, max + 1);
		}

		public Direction GetRandomDirectionX() => GetRandomDirection(new[] { Direction.North, Direction.South });

		public Direction GetRandomDirectionY() => GetRandomDirection(new[] { Direction.East, Direction.West });

		public Direction GetRandomDirection(IEnumerable<Direction> except = null) => GetRandomEnum<Direction>(except);

		private T GetRandomEnum<T>(IEnumerable<T> excluded = null)
		{
			excluded = excluded ?? new List<T>();
			var values = GetAllEnum.ValuesOf<T>().Except(excluded).ToList();
			return values[_random.Next(values.Count)];
		}

		private int GenerateSeed()
		{
			return new Random().Next(Int32.MaxValue);
		}
	}
}
