namespace Cinema.Course.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Critic Critic { get; set; }
        public float Score { get; set; }
    }
}