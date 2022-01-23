namespace Movies.Models
{
    public class MovieViewModel
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }
        public int Year { get; set; }
        public int Popularity { get; set; }

        public  List<CommentsViewModel> Comments { get; set; }
    }
}
