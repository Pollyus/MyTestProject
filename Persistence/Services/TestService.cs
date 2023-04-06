using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Persistence.Services
{
    public class TestService : ITestService
    {
        private readonly IGenericRepository<Test> _repository;
        private readonly IValidationService<TestRequestDto> _validator;

        public TestService(IUnitOfWork unitOfWork, IValidationService<TestRequestDto> validator)
        {
            _repository = unitOfWork.TestRepository;
            _validator = validator;
        }

        public List<TestResponseDto> GetAllTests()
        {
            return _repository.GetList()
                .Select(test => new TestResponseDto
                {
                    Id = test.Id,
                    Name = test.Name,
                    Namespace = test.Namespace,
                    Pipeline = test.Pipeline,
                    Job = test.Job
                })
                .OrderBy(test => test.Name)
                .ToList();
        }

        public TestResponseDto GetTestById(Guid id)
        {
            var test = FindTestInRepositoryByIdAndThrow(id);

            return new TestResponseDto
            {
                Id = test.Id,
                Name = test.Name,
                Namespace = test.Namespace,
                Pipeline = test.Pipeline,
                Job = test.Job
            };
        }

        public void SetTest(TestRequestDto testDto)
        {
            _validator.Validate(testDto);

            _repository.Insert(new Test
            {
                Name = testDto.Name,
                Namespace = testDto.Namespace,
                Pipeline = testDto.Pipeline,
                Job = testDto.Job
            });
        }

        public void DeleteTestById(Guid id)
        {
            var Test = FindTestInRepositoryByIdAndThrow(id);

            _repository.Delete(Test);
        }

        public void UpdateTest(Guid id, TestRequestDto testDto)
        {
            _validator.Validate(testDto);
            var Test = FindTestInRepositoryByIdAndThrow(id);

            Test.Name = testDto.Name;
            Test.Namespace = testDto.Namespace;
            Test.Pipeline = testDto.Pipeline;
            Test.Job = testDto.Job;

            _repository.Update();
        }

        private Test FindTestInRepositoryByIdAndThrow(Guid id)
        {
            var test = _repository.GetByID(id);

            if (test == null)
                throw new NotFoundException(nameof(test), id);

            return test;
        }
    }
}
