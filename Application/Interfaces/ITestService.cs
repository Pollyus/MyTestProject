using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    /// <summary>
    /// CRUD service for test
    /// </summary>
    public interface ITestService
    {
        public List<TestResponseDto> GetAllTests();

        public TestResponseDto GetTestById(Guid id);

        public void SetTest(TestRequestDto testDto);

        public void DeleteTestById(Guid id);

        public void UpdateTest(Guid id, TestRequestDto test);
    }
}
