namespace TaskManager
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[✓]" : "[ ]";
            return $"{Id}. {status} {Title}";
        }
    }
}