using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SerebiiGenSearch
{
    internal static class ParseFileIntoDictionary
    {

        public static void CreateDictionaryFromFile(Dictionary<string, string> dictionary, string fileLocation, Label debugLabel)
        {
            try
            {
                var lines = File.ReadLines(fileLocation).ToList();
                foreach(string line in lines)
                {
                    var both = line.Split("/").ToArray();
                    var number = both[0].Remove(0, 1);
                    dictionary.Add(both[1].ToLower(), number); //key: name, value: number
                    Debug.WriteLine("Dictionary - Key: " + both[1].ToLower() + " - Value: " + number);
                }
            }
            catch
            {
                debugLabel.Text = "Error: Dictionary not created from " + fileLocation;
                Debug.WriteLine("Error: Dictionary not created from " + fileLocation);
            }
            
            
        }


    }
}
