using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace CarInfo.Tests
{
    public class TestDataLoader
    {
        public static IEnumerable GetTestCases(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var testCases = new List<TestCaseData>();

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                int first = int.Parse(parts[0]);
                double second = double.Parse(parts[1]);

                testCases.Add(new TestCaseData(first, second));
            }

            return testCases;
        }
    }
}
