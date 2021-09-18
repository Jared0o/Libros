using Core.Dtos.Author;
using Core.Validators.Author;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ValidatorsTests
{
    public class CreateAuthorValidatorTests
    {
        private CreateAuthorValidator createAuthorValidator;
        private CreateAuthorRequest createAuthorRequest;

        public CreateAuthorValidatorTests()
        {
            createAuthorValidator = new CreateAuthorValidator();
        }

        [Fact]
        public async Task TestValidationWhenAllPropertiesAreCorrect()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(-1), DateOfDeath = DateTime.Now };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenFirstNameIsTooShort()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "A", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(-1), DateOfDeath = DateTime.Now };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenFirstNameIsTooLong()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Aasdasdafsfsdgdfgsdfgsfdasdasfsdfgfdgsasd", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(-1), DateOfDeath = DateTime.Now };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenLasttNameIsTooShort()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Mi", DateOfBirth = DateTime.Now.AddDays(-1), DateOfDeath = DateTime.Now };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenLastNameIsTooLong()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Aasdasdafsfsdgdfgsdfgsfdasdasfsdfgfdgsasd", DateOfBirth = DateTime.Now.AddDays(-1), DateOfDeath = DateTime.Now };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenDateOfBirthIsHigherThanDateOfDeat()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = DateTime.Now, DateOfDeath = DateTime.Now.AddDays(-1) };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenDateOfBirthIsHigherThanDateTimeNow()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(1), DateOfDeath = DateTime.Now.AddDays(2) };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestValidationWhenDateOfDeathisNull()
        {
            createAuthorRequest = new CreateAuthorRequest { FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = DateTime.Now.AddDays(-1) };
            var result = await createAuthorValidator.ValidateAsync(createAuthorRequest);
            Assert.True(result.IsValid);
        }

    }
}
