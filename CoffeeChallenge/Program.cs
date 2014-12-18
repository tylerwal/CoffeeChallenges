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
		FirstChallenge();
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
}