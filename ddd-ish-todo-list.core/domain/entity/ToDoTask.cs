namespace ddd_ish_todo_list.core.domain.entity
{
    public class ToDoTask
    {
        public int Id { get; }
        public int OwnerId { get; }
        public string Details { get; }
        public string Title { get; }
        
        public ToDoTask(int id, string details, string title, int ownerId)
        {
            Id = id;
            Details = details;
            Title = title;
            OwnerId = ownerId;
        }
    }
}