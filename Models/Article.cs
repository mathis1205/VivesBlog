namespace VivesBlog.Ui.Mvc.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public  string? Description { get; set; }
        public  string? Content { get; set; }
    }
}
