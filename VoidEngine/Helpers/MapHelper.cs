using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace VoidEngine.Helpers
{
	public static class MapHelper
	{
		/// <summary>
		/// Returns the formated array from a list of strings.
		/// '.' and ',' return 0.
		/// '1'-'9', 'a'-'z', 'A'-'Z', and all symbols on a english keyboard
		/// except ' and " will return 1 to 84 respectifully.
		/// </summary>
		public static uint[,] GetTileArray(List<string> lines)
		{
			uint[,] tileArray = new uint[lines[0].Length, lines.Count];
			for (int i = 0; i < lines[0].Length; i++)
			{
				for (int j = 0; j < lines.Count; j++)
				{
					switch (lines[j][i])
					{
						case '.':
							tileArray[i, j] = 0;
							break;
						case ' ':
							tileArray[i, j] = 0;
							break;
						case '1':
							tileArray[i, j] = 1;
							break;
						case '2':
							tileArray[i, j] = 2;
							break;
						case '3':
							tileArray[i, j] = 3;
							break;
						case '4':
							tileArray[i, j] = 4;
							break;
						case '5':
							tileArray[i, j] = 5;
							break;
						case '6':
							tileArray[i, j] = 6;
							break;
						case '7':
							tileArray[i, j] = 7;
							break;
						case '8':
							tileArray[i, j] = 8;
							break;
						case '9':
							tileArray[i, j] = 9;
							break;
						case 'a':
							tileArray[i, j] = 10;
							break;
						case 'b':
							tileArray[i, j] = 11;
							break;
						case 'c':
							tileArray[i, j] = 12;
							break;
						case 'd':
							tileArray[i, j] = 13;
							break;
						case 'e':
							tileArray[i, j] = 14;
							break;
						case 'f':
							tileArray[i, j] = 15;
							break;
						case 'g':
							tileArray[i, j] = 16;
							break;
						case 'h':
							tileArray[i, j] = 17;
							break;
						case 'i':
							tileArray[i, j] = 18;
							break;
						case 'j':
							tileArray[i, j] = 19;
							break;
						case 'k':
							tileArray[i, j] = 20;
							break;
						case 'l':
							tileArray[i, j] = 21;
							break;
						case 'm':
							tileArray[i, j] = 22;
							break;
						case 'n':
							tileArray[i, j] = 23;
							break;
						case 'o':
							tileArray[i, j] = 24;
							break;
						case 'p':
							tileArray[i, j] = 25;
							break;
						case 'q':
							tileArray[i, j] = 26;
							break;
						case 'r':
							tileArray[i, j] = 27;
							break;
						case 's':
							tileArray[i, j] = 28;
							break;
						case 't':
							tileArray[i, j] = 29;
							break;
						case 'u':
							tileArray[i, j] = 30;
							break;
						case 'v':
							tileArray[i, j] = 31;
							break;
						case 'w':
							tileArray[i, j] = 32;
							break;
						case 'x':
							tileArray[i, j] = 33;
							break;
						case 'y':
							tileArray[i, j] = 34;
							break;
						case 'z':
							tileArray[i, j] = 35;
							break;
						case 'A':
							tileArray[i, j] = 36;
							break;
						case 'B':
							tileArray[i, j] = 37;
							break;
						case 'C':
							tileArray[i, j] = 38;
							break;
						case 'D':
							tileArray[i, j] = 39;
							break;
						case 'E':
							tileArray[i, j] = 40;
							break;
						case 'F':
							tileArray[i, j] = 41;
							break;
						case 'G':
							tileArray[i, j] = 42;
							break;
						case 'H':
							tileArray[i, j] = 43;
							break;
						case 'I':
							tileArray[i, j] = 44;
							break;
						case 'J':
							tileArray[i, j] = 45;
							break;
						case 'K':
							tileArray[i, j] = 46;
							break;
						case 'L':
							tileArray[i, j] = 47;
							break;
						case 'M':
							tileArray[i, j] = 48;
							break;
						case 'N':
							tileArray[i, j] = 49;
							break;
						case 'O':
							tileArray[i, j] = 50;
							break;
						case 'P':
							tileArray[i, j] = 51;
							break;
						case 'Q':
							tileArray[i, j] = 52;
							break;
						case 'R':
							tileArray[i, j] = 53;
							break;
						case 'S':
							tileArray[i, j] = 54;
							break;
						case 'T':
							tileArray[i, j] = 55;
							break;
						case 'U':
							tileArray[i, j] = 56;
							break;
						case 'V':
							tileArray[i, j] = 57;
							break;
						case 'W':
							tileArray[i, j] = 58;
							break;
						case 'X':
							tileArray[i, j] = 58;
							break;
						case 'Y':
							tileArray[i, j] = 59;
							break;
						case 'Z':
							tileArray[i, j] = 60;
							break;
						case '!':
							tileArray[i, j] = 61;
							break;
						case '@':
							tileArray[i, j] = 62;
							break;
						case '#':
							tileArray[i, j] = 63;
							break;
						case '$':
							tileArray[i, j] = 64;
							break;
						case '*':
							tileArray[i, j] = 65;
							break;
						case '(':
							tileArray[i, j] = 66;
							break;
						case ')':
							tileArray[i, j] = 67;
							break;
						case '_':
							tileArray[i, j] = 68;
							break;
						case '-':
							tileArray[i, j] = 69;
							break;
						case '+':
							tileArray[i, j] = 70;
							break;
						case '=':
							tileArray[i, j] = 71;
							break;
						case '{':
							tileArray[i, j] = 72;
							break;
						case '}':
							tileArray[i, j] = 73;
							break;
						case '[':
							tileArray[i, j] = 74;
							break;
						case ']':
							tileArray[i, j] = 75;
							break;
						case '|':
							tileArray[i, j] = 76;
							break;
						case ':':
							tileArray[i, j] = 77;
							break;
						case ';':
							tileArray[i, j] = 78;
							break;
						case '<':
							tileArray[i, j] = 79;
							break;
						case ',':
							tileArray[i, j] = 80;
							break;
						case '>':
							tileArray[i, j] = 81;
							break;
						case '?':
							tileArray[i, j] = 82;
							break;
						case '/':
							tileArray[i, j] = 83;
							break;
						default:
							break;
					}
				}
			}

			return tileArray;
		}

		public static int[,] ImgToLevel(Texture2D texture)
		{
			int[,] tempIntArray = new int[texture.Width, texture.Height];
			Color[] tempColorArray = new Color[texture.Width * texture.Height];
			texture.GetData(tempColorArray);

			for (int i = 0; i < tempColorArray.Length; i++)
			{
				int x = i / texture.Width;
				int y = i % texture.Width;

				if (tempColorArray[i] == new Color(0, 0, 0, 0))
				{
					tempIntArray[y, x] = 0;
				}
				if (tempColorArray[i] == new Color(128, 128, 128))
				{
					tempIntArray[y, x] = 1;
				}
				if (tempColorArray[i] == new Color(0, 114, 70))
				{
					tempIntArray[y, x] = 2;
				}
				if (tempColorArray[i] == new Color(200, 200, 200))
				{
					tempIntArray[y, x] = 3;
				}
				if (tempColorArray[i] == new Color(64, 64, 64))
				{
					tempIntArray[y, x] = 4;
				}
				if (tempColorArray[i] == new Color(255, 255, 0))
				{
					tempIntArray[y, x] = 25;
				}
				if (tempColorArray[i] == new Color(0, 255, 255))
				{
					tempIntArray[y, x] = 77;
				}
				if (tempColorArray[i] == new Color(68, 255, 78))
				{
					tempIntArray[y, x] = 78;
				}
				if (tempColorArray[i] == new Color(174, 85, 167))
				{
					tempIntArray[y, x] = 79;
				}
				if (tempColorArray[i] == new Color(255, 193, 86))
				{
					tempIntArray[y, x] = 80;
				}
				if (tempColorArray[i] == new Color(249, 0, 0))
				{
					tempIntArray[y, x] = 81;
				}
				if (tempColorArray[i] == new Color(255, 142, 217))
				{
					tempIntArray[y, x] = 82;
				}
			}

			return tempIntArray;
		}
	}
}
