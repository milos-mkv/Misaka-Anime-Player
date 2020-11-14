using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisakaAnimePlayer.models
{
    public class Episode
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        public string Description { get; set; }
        
        public Episode(int number, string title, string link, string description)
        {
            this.Number = number;
            this.Title = title;
            this.Link = link;
            this.Description = description;
        }
    }
}
