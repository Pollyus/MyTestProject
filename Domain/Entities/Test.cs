namespace Domain.Entities
{
    public class Test
    {
        public Guid Id { get; set; }
        public string? Namespace { get; set; }
        public int Pipeline { get; set; }
        public int Job { get; set; }
    }
}
