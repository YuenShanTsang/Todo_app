namespace Todo_app.Models
{
    // A model to track a To-do
    public class Todo
	{
        public int TodoId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public bool IsComplete { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}

