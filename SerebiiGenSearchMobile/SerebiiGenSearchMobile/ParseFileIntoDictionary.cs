using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SerebiiGenSearchMobile
{
    internal static class ParseFileIntoDictionary
    {
        public async static void CreateDictionaryFromFile(Dictionary<string, string> dictionary, string path, Label debugLabel)
        {

            var file = await FileSystem.OpenAppPackageFileAsync(path);
            if(file == null)
            {
                debugLabel.Text = "Error: Dictionary not created from " + path;
                Debug.Fail("Error: Dictionary not created from " + path);
                return;
            }
            var reader = new StreamReader(file);
            char[] splitter = "\n".ToCharArray();
            List<string> lines = reader.ReadToEnd().Split(splitter).ToList();
            foreach (string line in lines)
            {
                if (line.ToString().Trim() == "") return;
                var both = line.Split('/').ToArray();
                string number = both[0].Remove(0, 1);
                dictionary.Add(both[1].ToLower().Trim(), number); //key: name, value: number
                Debug.WriteLine("Key: " + both[1].ToLower().Trim() + " - Value: " + number);
            }
            reader.Close();
        }
    }
}
