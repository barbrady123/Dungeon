using System;
using System.Collections.Generic;
using System.Text;
using Whitehouse.Dungeon.Generator.Enums;
using Whitehouse.Dungeon.Generator.Models;
using Whitehouse.Dungeon.Generator.Util;

namespace Whitehouse.Dungeon.Generator
{
	public class MapGenerator
	{
		private const int MAX_ROOM_ATTEMPTS = 5000;

		private readonly MapGeneratorConfiguration _config;
		private readonly RandomGenerator _random;

		public MapGenerator(MapGeneratorConfiguration config)
		{
			_config = config;
			_random = new RandomGenerator(_config.MapSeed);
		}

		public Map GenerateMap()
		{			
			var map = new Map(_random.Seed, _config.MapWidth, _config.MapHeight, _config.MapBorderX, _config.MapBorderY);

			GenerateRooms(map);

			return map;
		}

		private void GenerateRooms(Map map)
		{
			var maxRooms = _random.GetInteger(_config.RoomsNumberMin, _config.RoomsNumberMax);
			int numRooms = 0;
			int roomAttempts = 0;

			while (numRooms < maxRooms)
			{
				if (roomAttempts >= MAX_ROOM_ATTEMPTS)
					break;

				roomAttempts++;
				var room = CreateRoom(map);
				if (room == null)
					continue;

				numRooms++;
				roomAttempts = 0;
			}
		}

		private Room CreateRoom(Map map)
		{
			int roomXStart = _random.GetInteger(_config.MapBorderX, _config.MapWidth - _config.MapBorderX);
			int roomYStart = _random.GetInteger(_config.MapBorderY, _config.MapHeight - _config.MapBorderY);

			var startCell = map.GetCell(roomXStart, roomYStart);
			if (startCell.Type != CellType.Solid)
				return null;

			Direction dirX = _random.GetRandomDirectionX();
			int roomSizeX = _random.GetInteger(_config.RoomsWidthMin, _config.RoomsWidthMax);
			int roomXEnd = roomXStart + (dirX == Direction.East ? roomSizeX : -roomSizeX);

			Direction dirY = _random.GetRandomDirectionY();
			int roomSizeY = _random.GetInteger(_config.RoomsHeightMin, _config.RoomsHeightMax);
			int roomYEnd = roomYStart + (dirY == Direction.South ? roomSizeY : -roomSizeY);

			var possibleRoom = new Room(roomXStart, roomYStart, roomXEnd, roomYEnd);

			if (!map.RoomValid(possibleRoom))
				return null;

			map.AddRoom(possibleRoom);

			return possibleRoom;
		}
	}
}
