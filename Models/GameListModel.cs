using System;

namespace Cinema.Course.Models
{
    public class GameListModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MinAge { get; set; }
        public float CriticsRating { get; set; }
        public float GamersRating { get; set; }
        public Platform[] Platforms { get; set; }
        public Genre[] Genres { get; set; }
        public string ImageUrl { get; set; }
    }
}