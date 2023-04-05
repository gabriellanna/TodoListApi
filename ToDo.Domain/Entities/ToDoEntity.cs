namespace ToDo.Domain.Entities
{
    public class ToDoEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}