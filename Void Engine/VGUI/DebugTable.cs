using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VoidEngine.VGUI
{
    public class DebugTable
    {
        public string[,] RawTable;

        public int bestlength;
        public Point bestLengthPosition;

        public void initalizeTable(string[,] table)
        {
            RawTable = table;

            for (int m = 0; m < RawTable.GetLength(0); m++)
            {
                for (int s = 0; s < RawTable.GetLength(1); s++)
                {
                    if (s == 0)
                    {
                        if (RawTable[m, s].Length + 2 > bestlength)
                        {
                            bestlength = RawTable[m, s].Length + 2;
                            bestLengthPosition = new Point(m, s);
                        }
                    }
                    else if (s > 0)
                    {
                        if (RawTable[m, s].Length + 5 > bestlength)
                        {
                            bestlength = RawTable[m, s].Length + 5;
                            bestLengthPosition = new Point(m, s);
                        }
                    }
                }
            }
        }

        public string ReturnStringSegment(int mainIndex, int subIndex)
        {
            string tempString = "";
            int tempLength = 0;

            if (mainIndex < 0 || subIndex < 0)
            {
                tempString = "[ERROR]";
            }
            else
            {
                if (subIndex == 0)
                {
                    tempString = " " + RawTable[mainIndex, 0] + " ";
                    tempLength = tempString.Length;

                    if (bestLengthPosition.Y > 0)
                    {
                        for (int i = 0; i < bestlength - tempLength; i++)
                        {
                            tempString += " ";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < bestlength - tempLength; i++)
                        {
                            tempString += " ";
                        }
                    }

                    tempString += "|| ";
                }
                else if (subIndex > 0)
                {
                    tempString = "  - " + RawTable[mainIndex, subIndex] + " ";
                    tempLength = tempString.Length;

                    if (bestLengthPosition.Y > 0)
                    {
                        for (int i = 0; i < bestlength - tempLength; i++)
                        {
                            tempString += " ";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < bestlength - tempLength; i++)
                        {
                            tempString += " ";
                        }
                    }

                    tempString += "|| ";
                }
            }

            return tempString;
        }
    }
}
