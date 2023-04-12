namespace Todo_app.Models
{
	public class Todo
	{
        public int TodoId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool IsComplete { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

