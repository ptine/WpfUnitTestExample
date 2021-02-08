using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Utils
    {
        /// <summary>
        /// Method returning the free positions
        /// </summary>
        /// <param name="positions">Array of positions. False value if position is available, true instead</param>
        /// <param name="isCircular">If the array is circular the first position is adjacent to the last</param>
        /// <param name="neededPositions">Number of positions needed</param>
        /// <returns>Index of first position found (zero based) or -1 if no position is found</returns>
        public static int FindFreePosition(bool[] positions, int neededPositions, bool isCircular)
        {
            int length = positions.Length;

            if (isCircular)
                length *= 2;

            int freePlacesCount = 0;

            for (int i = 0; i < length; i++)
            {
                int newIndex = i % positions.Length;
                if (!positions[newIndex])
                {
                    freePlacesCount++;
                    if (freePlacesCount == neededPositions)
                        return (i + 1) - freePlacesCount;
                }
                else
                    freePlacesCount = 0;
            }

            return -1;
        }
    }
}
