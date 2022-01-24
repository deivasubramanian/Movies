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

        public string RatingText
        {
            get
            {

                switch (Rating)
                {
                    case 0:
                        return "Poor";
                    case 1:
                        return "Average";
                    case 2:
                        return "Above average";
                    case 3:
                        return "Good";
                    case 4:
                        return "Exceptional";
                    default: return "No rating for this movie";
                }
            }
        }
        public  List<CommentsViewModel> Comments { get; set; }
    }
}
