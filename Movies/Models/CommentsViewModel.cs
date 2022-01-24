namespace Movies.Models
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int MovieID { get; set ; }

    }
}
