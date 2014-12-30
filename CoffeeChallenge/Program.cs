using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using LetterToAsciiMap = System.Collections.Generic.KeyValuePair<char, char[,]>;

//using LetterToAsciiMap = System.Tuple<char, char[,]>;

class Player
{
	static void Main(string[] args)
	{
		ChuckNorris("C");
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

	#region MarsLanderPart1

	public static void MarsLanderPart1()
	{
		string[] inputs;

		// the number of points used to draw the surface of Mars.
		int numberPointsMarsSurface = int.Parse(Console.ReadLine());

		for (int i = 0; i < numberPointsMarsSurface; i++)
		{
			inputs = Console.ReadLine().Split(' ');

			// X coordinate of a surface point. (0 to 6999)
			int xSurfacePoint = int.Parse(inputs[0]);
			Console.Error.WriteLine("X Surface Point: {0}", xSurfacePoint);

			// Y coordinate of a surface point. By linking all the points together in a sequential fashion, 
			// you form the surface of Mars.
			int ySurfacePoint = int.Parse(inputs[1]);
			Console.Error.WriteLine("Y Surface Point: {0}", ySurfacePoint);
		}

		int thrust = 3;

		// game loop
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int X = int.Parse(inputs[0]);
			int Y = int.Parse(inputs[1]);

			int horizontalSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.

			int verticalSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.

			int fuelRemaining = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.

			int rotationalAngle = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).

			int thrustPower = int.Parse(inputs[6]); // the thrust power (0 to 4).

			if (verticalSpeed < -20 && thrust <= 3)
			{
				Console.Error.WriteLine("Thrust increased");
				thrust++;
			}
			else if (verticalSpeed > -7 && thrust >= 0)
			{
				Console.Error.WriteLine("Thrust decreased");
				thrust--;
			}

			Console.WriteLine("0 {0}", thrust); // R P. R is the desired rotation angle. P is the desired thrust power.
		}
	}

	#endregion MarsLanderPart1

	#region Temperatures

	public static void Temperatures()
	{
		{
			List<KeyValuePair<int, string>> absoluteMap = new List<KeyValuePair<int, string>>();

			string closestToZero = "0";

			string concatenatedTemperatures = Console.ReadLine(); // the N temperatures expressed as integers ranging from -273 to 5526
			Console.Error.WriteLine(concatenatedTemperatures);

			if (!string.IsNullOrWhiteSpace(concatenatedTemperatures))
			{
				string[] temperatures = concatenatedTemperatures.Split(' ');

				foreach (string temperature in temperatures)
				{
					int temp = int.Parse(temperature);

					absoluteMap.Add(new KeyValuePair<int, string>(Math.Abs(temp), temperature));
				}

				IOrderedEnumerable<KeyValuePair<int, string>> sortedTemperatures = absoluteMap.OrderByDescending(i => i.Key).ThenByDescending(i => i.Value);

				closestToZero = sortedTemperatures.Last().Value;
			}

			Console.WriteLine(closestToZero);
		}
	}

	#endregion Temperatures

	#region ASCII Art

	public static void AsciiArt()
	{
		/*
		 Getting the initial data from the challenge
		 */
		int widthOfLetter = int.Parse(Console.ReadLine());
		int heightOfLetter = int.Parse(Console.ReadLine());
		string desiredText = Console.ReadLine();

		/*
		 A map of a char to the ASCII Art array associated with it
		 */
		LetterToAsciiMaps letterToAsciiMaps = new LetterToAsciiMaps();
		letterToAsciiMaps.AddRange(
			Enumerable.Range('a', 'z' - 'a' + 1)
			.Select(c => new LetterToAsciiMap(
				((Char)c).ToString().ToUpper().First(), new char[widthOfLetter, heightOfLetter])
				)
			);
		letterToAsciiMaps.Add(new LetterToAsciiMap('?', new char[widthOfLetter, heightOfLetter]));

		/*
		 Filling the ASCII Art arrays of each letter
		 */
		for (int asciiRowIncrement = 0; asciiRowIncrement < heightOfLetter; asciiRowIncrement++)
		{
			List<char> givenAsciiArtRow = Console.ReadLine().ToList();
			List<char>.Enumerator givenAsciiArtRowEnumerator = givenAsciiArtRow.GetEnumerator();

			foreach (LetterToAsciiMap letterToAsciiMap in letterToAsciiMaps)
			{
				for (int currentCharInAsciiArt = 0; currentCharInAsciiArt < widthOfLetter; currentCharInAsciiArt++)
				{
					givenAsciiArtRowEnumerator.MoveNext();
					letterToAsciiMap.Value[currentCharInAsciiArt, asciiRowIncrement] = givenAsciiArtRowEnumerator.Current;
				}
			}
		}

		var desiredChars = desiredText.ToCharArray();

		for (int currentRow = 0; currentRow < heightOfLetter; currentRow++)
		{
			foreach (char desiredChar in desiredChars)
			{
				char[,] currentMap = letterToAsciiMaps.FirstOrDefault(c => c.Key.ToString().ToLower() == desiredChar.ToString().ToLower()).Value;

				if (currentMap == null)
				{
					currentMap = letterToAsciiMaps.First(c => c.Key == '?').Value;
				}

				for (int currentColumnOfSingleChar = 0; currentColumnOfSingleChar < currentMap.GetLength(0); currentColumnOfSingleChar++)
				{
					Console.Write(currentMap[currentColumnOfSingleChar, currentRow]);
				}
			}

			Console.WriteLine();
		}
	}

	private class LetterToAsciiMaps : List<LetterToAsciiMap>
	{
	}

	#endregion ASCII Art

	#region ChuckNorris

	public static string ChuckNorris(string inputMessage)
	{
		char[] charInputArray = inputMessage.ToCharArray();

		StringBuilder binaryInputMessageBuilder = new StringBuilder();

		foreach (char letter in charInputArray)
		{
			string letterInBinary = Convert.ToString(letter, 2).PadLeft(7, '0');

			binaryInputMessageBuilder.Append(Convert.ToString(letterInBinary));
		}

		string binaryInputNumbers = binaryInputMessageBuilder.ToString();

		var binarySequence = new List<BinarySequence>();

		foreach (char currentBinaryInput in binaryInputNumbers)
		{
			if (binarySequence.Count == 0)
			{
				binarySequence.Add(new BinarySequence(currentBinaryInput));
			}
			else
			{
				var lastAddedSequence = binarySequence.Last();

				if (currentBinaryInput == lastAddedSequence.BinaryNumber)
				{
					lastAddedSequence.Iterations++;
				}
				else
				{
					binarySequence.Add(new BinarySequence(currentBinaryInput));
				}
			}
		}

		StringBuilder outputMessageBuilder = new StringBuilder();

		foreach (BinarySequence sequence in binarySequence)
		{
			/*One or Zero*/
			outputMessageBuilder.Append(sequence.BinaryNumber == '1' ? "0" : "00");
			outputMessageBuilder.Append(" ");

			outputMessageBuilder.Append(new string('0', sequence.Iterations));
			outputMessageBuilder.Append(" ");
		}

		Console.WriteLine(outputMessageBuilder.ToString().Trim());

		return outputMessageBuilder.ToString().Trim();
	}

	private class BinarySequence
	{
		public char BinaryNumber { get; set; }

		public int Iterations { get; set; }

		public BinarySequence(char binaryNumber)
		{
			BinaryNumber = binaryNumber;
			Iterations = 1;
		}

		public BinarySequence(char binaryNumber, int iterations)
		{
			BinaryNumber = binaryNumber;
			Iterations = iterations;
		}
	}

	#endregion ChuckNorris

	#region MimeType

	public static void MimeType()
	{
		int numberOfElementsInAssociationTable = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
		int numberOfInputFileNames = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

		Dictionary<string, string> extensionMimeMaps = new Dictionary<string, string>();

		for (int i = 0; i < numberOfElementsInAssociationTable; i++)
		{
			string fileAssociationLine = Console.ReadLine();
			string[] inputs = fileAssociationLine.Split(' ');
			string fileExtension = inputs[0].ToLower(); // file extension
			string mimeType = inputs[1]; // MIME type.

			extensionMimeMaps.Add(fileExtension, mimeType);
		}

		List<string> fileNames = new List<string>();

		for (int i = 0; i < numberOfInputFileNames; i++)
		{
			string inputFileName = Console.ReadLine(); // One file name per line.
			fileNames.Add(inputFileName);
		}

		Console.Error.WriteLine("\n!!!! Output !!!!\n");

		foreach (string fileName in fileNames)
		{
			string extension = fileName.Split('.').Last();

			bool isMappedType = fileName != extension && extensionMimeMaps.ContainsKey(extension.ToLower());

			Console.WriteLine(isMappedType ? extensionMimeMaps[extension.ToLower()] : "UNKNOWN");
		}
	}

	#endregion MimeType
}