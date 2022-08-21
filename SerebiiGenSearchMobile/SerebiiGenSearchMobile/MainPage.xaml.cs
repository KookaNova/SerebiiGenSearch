using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.PlatformConfiguration;

namespace SerebiiGenSearchMobile
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, string> PokeDex = new Dictionary<string, string>();
        string url = "https://www.serebii.net/";
        string pokenum = "025";

        public MainPage()
        {
            InitializeComponent();
            CreateDictionary();
        }

        public void CreateDictionary()
        {
            
            ParseFileIntoDictionary.CreateDictionaryFromFile(PokeDex, "pokemon.txt", l_debug);
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string value = "";

            PokeDex.TryGetValue(e_input.Text.ToLower(), out value);

            if (value != null)
            {
                pokenum = value;
                Debug.WriteLine("Searching for pokemon #" + value);
                l_debug.Text = "Searching for pokemon #" + value;
            }
            else
            {
                pokenum = "025";
                Debug.WriteLine(e_input.Text + " not found in dictionary.");
                l_debug.Text = e_input.Text + " not found in dictionary.";
            }
        }
        private void OpenSite(string url)
        {
            //var uri = Android.Net.Uri.Parse("http://www.xamarin.com");
           // var intent = new Intent(Intent.ActionView, uri);
            
            try
            {
                //StartActivity(intent);
                //Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception other)
            {
                l_debug.Text = "Browser failed to open. Message: " + other.Message;
            }
        }

        private void b_rb_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "/" + pokenum);
        }
    }
}
