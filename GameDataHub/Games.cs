using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataHub
{
    internal class Games
    {
        public string id { get; set; }
        public string name { get; set; }
        public string developer { get; set; }
        public string platform { get; set; }
        public string genre { get; set; }
        public string imageUrl { get; set; } 

        //CONSTRUCTOR
        public Games()
        {
            id = string.Empty;
            name = string.Empty;
            developer = string.Empty;
            platform = string.Empty;
            genre = string.Empty;
            imageUrl = string.Empty;
        }
        public Games(string id, string name, string developer, string platform, string genre, string imageUel)
        {
            this.id = id;
            this.name = name;
            this.developer = developer;
            this.platform = platform;
            this.genre = genre;
            this.imageUrl = imageUel;
        }
    }
}
