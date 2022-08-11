using System;
using System.Collections.Generic;

namespace MVC_Favotire_Song_List_Api.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Group { get; set; } = null!;
        public short Year { get; set; }
        public string Genre { get; set; } = null!;
    }
}
