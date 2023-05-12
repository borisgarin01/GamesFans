using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Course.Models
{
    public class GameGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float CriticsRating { get; set; }
        public float GamersRating { get; set; }
        public int MarksCount { get; set; }
        public Developer Developer { get; set; }
        public Publisher Publisher { get; set; }
        public Platform[] Platforms { get; set; }
        public Genre[] Genres { get; set; }
        public string Localization { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string[] Trailers { get; set; }
        public string[] Screenshots { get; set; }
        public string[] VideoReviews { get; set; }
        public CriticReview[] CriticsReviews { get; set; }
        public GamerReview[] GamersReviews { get; set; }

    }
}