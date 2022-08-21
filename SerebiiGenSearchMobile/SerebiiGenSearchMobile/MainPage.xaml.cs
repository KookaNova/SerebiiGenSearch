using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Essentials;

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

        private void SearchDex()
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
        private async void OpenSite(string url)
        {

            Uri uri = new Uri(url);
            try
            {
                await Browser.OpenAsync(uri);
            }
            catch (Exception other)
            {
                l_debug.Text = "Browser failed to open. Message: " + other.Message;
            }
        }
        private void e_input_Unfocused(object sender, FocusEventArgs e)
        {
            SearchDex();
        }
        

        private void b_rb_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "/" + pokenum + ".shtml");
        }

        private void b_gs_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-gs" + "/" + pokenum + ".shtml");
        }

        private void b_rs_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-rs" + "/" + pokenum + ".shtml");
        }

        private void b_dp_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-dp" + "/" + pokenum + ".shtml");
        }

        private void b_bw_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-bw" + "/" + pokenum + ".shtml");
        }

        private void b_xy_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-xy" + "/" + pokenum + ".shtml");
        }

        private void b_sm_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-sm" + "/" + pokenum + ".shtml");
        }

        private void b_swsh_Clicked(object sender, EventArgs e)
        {
            OpenSite(url + "pokedex" + "-swsh" + "/" + pokenum + ".shtml");
        }

        
    }
}
