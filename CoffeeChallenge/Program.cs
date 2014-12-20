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

	#region Onboarding

	static void Onboarding()
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

	#endregion Onboarding

	#region PowerOfThor

	static void PowerOfThor()
	{
		string[] inputs = Console.ReadLine().Split(' ');
		int xPositionLight = int.Parse(inputs[0]); // the X position of the light of power
		int yPositionLight = int.Parse(inputs[1]); // the Y position of the light of power
		int xPositionThor = int.Parse(inputs[2]); // Thor's starting X position
		int yPositionThor = int.Parse(inputs[3]); // Thor's starting Y position

		Queue<string> moves = new Queue<string>();

		int xDistance = xPositionLight - xPositionThor;
		int xAbsoluteDistance = Math.Abs(xDistance);
		Console.Error.WriteLine("X Absolute Distance: {0}", xAbsoluteDistance);

		int yDistance = yPositionThor - yPositionLight;
		int yAbsoluteDistance = Math.Abs(yPositionThor - yPositionLight);
		Console.Error.WriteLine("Y Absolute Distance: {0}", yAbsoluteDistance);

		int maxDistance = Math.Max(xAbsoluteDistance, yAbsoluteDistance);

		Console.Error.WriteLine("Max Distance: {0}", maxDistance);

		string xDirection = GetEastWest(xDistance);
		string yDirection = GetNorthSouth(yDistance);

		for (int i = 0; i < maxDistance; i++)
		{
			string direction = string.Empty;

			if (i < yAbsoluteDistance)
			{
				direction += yDirection;
			}
			if (i < xAbsoluteDistance)
			{
				direction += xDirection;
			}

			Console.Error.WriteLine("i: {0} - Move Added: {1}", i, direction);

			moves.Enqueue(direction);
		}

		// game loop
		while (true)
		{
			int E = int.Parse(Console.ReadLine()); // The level of Thor's remaining energy, representing the number of moves he can still make.

			string move = moves.Dequeue();

			Console.WriteLine(move); // A single line providing the move to be made: N NE E SE S SW W or NW
		}
	}

	static string GetNorthSouth(int yDistance)
	{
		string returnedValue = string.Empty;

		if (yDistance < 0)
		{
			returnedValue = "S";
		}
		else if (yDistance > 0)
		{
			returnedValue = "N";
		}

		return returnedValue;
	}

	static string GetEastWest(int xDistance)
	{
		string returnedValue = string.Empty;

		if (xDistance > 0)
		{
			returnedValue = "E";
		}
		else if (xDistance < 0)
		{
			returnedValue = "W";
		}

		return returnedValue;
	} 

	#endregion PowerOfThor

	#region KirksQuest

	public void KirksQuest()
	{
		while (true)
		{
			string[] inputs = Console.ReadLine().Split(' ');

			int shipXPosition = int.Parse(inputs[0]);
			Console.Error.WriteLine("Ship X: {0}", shipXPosition);
			int shipYPosition = int.Parse(inputs[1]);
			Console.Error.WriteLine("Ship Y: {0}: ", shipYPosition);

			Dictionary<int, int> mountainHeights = new Dictionary<int, int>();

			for (int i = 0; i < 8; i++)
			{
				int mountainHeight = int.Parse(Console.ReadLine()); // represents the height of one mountain, from 9 to 0. Mountain heights are provided from left to right.

				Console.Error.WriteLine("Moutain {0}: {1}", i, mountainHeight);

				mountainHeights.Add(i, mountainHeight);
			}

			int highestMountainXPosition = mountainHeights.OrderByDescending(i => i.Value).First().Key;

			string fireCommand = "FIRE";
			string holdCommand = "HOLD";

			string action = shipXPosition == highestMountainXPosition ? fireCommand : holdCommand;

			Console.WriteLine(action); // either:  FIRE (ship is firing its phase cannons) or HOLD (ship is not firing).
		}
	}

	#endregion KirksQuest

	#region SkynetChasm

	public static void SkynetChasm()
	{
		int lengthBeforeGap = int.Parse(Console.ReadLine()); // the length of the road before the gap.
		int gapLength = int.Parse(Console.ReadLine()); // the length of the gap.
		int landingPlatformLength = int.Parse(Console.ReadLine()); // the length of the landing platform.

		int desiredSpeed = gapLength + 1;
		int endOfGap = lengthBeforeGap + gapLength;

		Console.Error.WriteLine("Road length: " + lengthBeforeGap);
		Console.Error.WriteLine("Gap length: " + gapLength);
		Console.Error.WriteLine("Landing platform length: " + landingPlatformLength);

		string action = "SPEED";
		bool hasJumped = false;

		while (true)
		{
			int motorbikeSpeed = int.Parse(Console.ReadLine()); // the motorbike's speed.
			int motorbikePosition = int.Parse(Console.ReadLine()); // the position on the road of the motorbike.

			Console.Error.WriteLine("Motorbike speed: " + motorbikeSpeed);
			Console.Error.WriteLine("Motorbike position: " + motorbikePosition);

			if (hasJumped)
			{
				if (motorbikePosition >= endOfGap)
				{
					action = "SLOW";
				}
				else
				{
					action = "WAIT";
				}
			}
			else
			{
				if (motorbikePosition + (motorbikeSpeed * 1) > lengthBeforeGap)
				{
					action = "JUMP";
					hasJumped = true;
				}
				else if (motorbikeSpeed == desiredSpeed)
				{
					action = "WAIT";
				}
				else if (motorbikeSpeed >= desiredSpeed)
				{
					action = "SLOW";
				}
			}

			Console.WriteLine(action); // A single line containing one of 4 keywords: SPEED, SLOW, JUMP, WAIT.
		}
	}

	#endregion SkynetChasm
}