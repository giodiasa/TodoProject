namespace Todo.Service.Exceptions
{
    internal class TodoNotFoundException : Exception
    {
        public TodoNotFoundException() : base("Todo not found in the database")
        {
        }
    }
}
