using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoidEngine
{
	public static class MapHelper
	{
		public static uint[,] GetBrickArray(List<string> lines)
		{
			uint[,] brickArray = new uint[lines[0].Length, lines.Count];
			for (int i = 0; i < lines[0].Length; i++)
			{
				for (int j = 0; j < lines.Count; j++)
				{
					switch (lines[j][i])
					{
						case '.':
							brickArray[i, j] = 0;
							break;
						case '1':
							brickArray[i, j] = 1;
							break;
						case '2':
							brickArray[i, j] = 2;
							break;
						case '3':
							brickArray[i, j] = 3;
							break;
						case '4':
							brickArray[i, j] = 4;
							break;
						case '5':
							brickArray[i, j] = 5;
							break;
						case '6':
							brickArray[i, j] = 6;
							break;
						case '7':
							brickArray[i, j] = 7;
							break;
						case '8':
							brickArray[i, j] = 8;
							break;
						case '9':
							brickArray[i, j] = 9;
							break;
						case 'a':
							brickArray[i, j] = 10;
							break;
						case 'b':
							brickArray[i, j] = 11;
							break;
						case 'c':
							brickArray[i, j] = 12;
							break;
						case 'd':
							brickArray[i, j] = 13;
							break;
						case 'e':
							brickArray[i, j] = 14;
							break;
						case 'f':
							brickArray[i, j] = 15;
							break;
						case 'g':
							brickArray[i, j] = 16;
							break;
						case 'h':
							brickArray[i, j] = 17;
							break;
						case 'i':
							brickArray[i, j] = 18;
							break;
						case 'j':
							brickArray[i, j] = 19;
							break;
						case 'k':
							brickArray[i, j] = 20;
							break;
						case 'l':
							brickArray[i, j] = 21;
							break;
						case 'm':
							brickArray[i, j] = 22;
							break;
						case 'n':
							brickArray[i, j] = 23;
							break;
						case 'o':
							brickArray[i, j] = 24;
							break;
						case 'p':
							brickArray[i, j] = 25;
							break;
						case 'q':
							brickArray[i, j] = 26;
							break;
						case 'r':
							brickArray[i, j] = 27;
							break;
						case 's':
							brickArray[i, j] = 28;
							break;
						case 't':
							brickArray[i, j] = 29;
							break;
						case 'u':
							brickArray[i, j] = 30;
							break;
						case 'v':
							brickArray[i, j] = 31;
							break;
						case 'w':
							brickArray[i, j] = 32;
							break;
						case 'x':
							brickArray[i, j] = 33;
							break;
						case 'y':
							brickArray[i, j] = 34;
							break;
						case 'z':
							brickArray[i, j] = 35;
							break;
						default:
							break;
					}
				}
			}
			return brickArray;
		}
	}
}
