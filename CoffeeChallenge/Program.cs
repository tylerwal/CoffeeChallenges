using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
	static void Main(string[] args)
	{
	}

	static void FirstChallenge()
	{
		// game loop
		while (true)
		{
			List<KeyValuePair<string, int>> enemies = new List<KeyValuePair<string, int>>();

			int count = int.Parse(Console.ReadLine()); // The number of current enemy ships within range
			for (int i = 0; i < count; i++)
			{
				string[] inputs = Console.ReadLine().Split(' ');
				string enemy = inputs[0]; // The name of this enemy
				int dist = int.Parse(inputs[1]); // The distance to your cannon of this enemy

				enemies.Add(new KeyValuePair<string, int>(enemy, dist));
			}
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.Error.WriteLine(enemies.OrderBy(i => i.Value).First());
			Console.WriteLine("Buzz"); // The name of the most threatening enemy (HotDroid is just one example)
		}
	}

	static void PowerOfThor()
	{
		string[] inputs = Console.ReadLine().Split(' ');
		int xPositionLight = int.Parse(inputs[0]); // the X position of the light of power
		int yPositionLight = int.Parse(inputs[1]); // the Y position of the light of power
		int xPositionThor = int.Parse(inputs[2]); // Thor's starting X position
		int yPositionThor = int.Parse(inputs[3]); // Thor's starting Y position

		// game loop
		while (true)
		{
			int E = int.Parse(Console.ReadLine()); // The level of Thor's remaining energy, representing the number of moves he can still make.

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.WriteLine("SE"); // A single line providing the move to be made: N NE E SE S SW W or NW
		}
	}
}