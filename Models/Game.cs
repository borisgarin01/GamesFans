namespace Cinema.Course.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinAge { get; set; }
        public float Rating { get; set; }
        public Type[] Types { get; set; }
        public Genre[] Genres { get; set; }
        public Review[] Reviews { get; set; }
        public string ImageUrl { get; set; }
    }
}