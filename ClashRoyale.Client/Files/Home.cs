﻿namespace ClashRoyale.Client.Files
{
    using System.IO;
    using System.Text;

    using Newtonsoft.Json.Linq;

    internal static class Home
    {
        internal static JObject Json;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Home"/> has been already initalized.
        /// </summary>
        internal static bool Initalized
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        internal static void Initialize()
        {
            if (Home.Initalized)
            {
                return;
            }

            if (Directory.Exists("Gamefiles/level/"))
            {
                if (File.Exists("Gamefiles/level/starting_home.json"))
                {
                    string RawFile = File.ReadAllText("Gamefiles/level/starting_home.json", Encoding.UTF8);

                    if (!string.IsNullOrEmpty(RawFile))
                    {
                        Home.Json = JObject.Parse(RawFile);
                    }
                    else
                    {
                        Logging.Error(typeof(Home), "string.IsNullOrEmpty(RawFile) == true at Initialize().");
                    }
                }
                else
                {
                    Logging.Error(typeof(Home), "File.Exists(Path) != true at Initialize().");
                }
            }
            else
            {
                Logging.Error(typeof(Home), "Directory.Exists(Path) != true at Initialize().");
            }

            Home.Initalized = true;
        }
    }
}