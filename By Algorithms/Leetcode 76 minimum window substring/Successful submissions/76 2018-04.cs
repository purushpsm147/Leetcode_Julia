﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _76_minimum_windows_substring___2018_04
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 2018-04 submission 
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public string MinWindow(String source, String pattern)
        {
            var map = new int[256];

            foreach (char c in pattern.ToCharArray())
            {
                map[c - 'A']++;
            }

            int minLen = int.MaxValue;
            int minStart = 0;

            var totalNeedFound = pattern.Length;

            var sourceCharArray = source.ToCharArray();

            int start = 0;
            int end = 0;

            while (end < sourceCharArray.Length)
            {
                int endChar = sourceCharArray[end] - 'A';

                map[endChar]--;

                if (map[endChar] >= 0)
                { // still need more endChar
                    totalNeedFound--;
                }

                if (totalNeedFound == 0)
                {
                    int startChar = sourceCharArray[start] - 'A';

                    while (map[startChar] < 0)
                    {  // extra char is found
                        map[startChar]++;
                        start++;
                        startChar = sourceCharArray[start] - 'A';
                    }

                    int currentLength = end - start + 1;

                    if (currentLength < minLen)
                    {
                        minLen = currentLength;
                        minStart = start;
                    }

                    map[startChar]++;
                    start++;
                    totalNeedFound++;
                }

                end++;
            }

            return minLen == int.MaxValue ? "" : source.Substring(minStart, minLen);
        }
    }
}
