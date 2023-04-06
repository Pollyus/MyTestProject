namespace Application.Models.Requests
{
    public class TestRequestDto
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public int Pipeline { get; set; }
        public int Job { get; set; }
    }
}
