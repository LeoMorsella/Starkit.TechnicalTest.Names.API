using Persistence;
using Persistence.Services;
using System.Reflection;
using Xunit;
using Assert = Xunit.Assert;


namespace Test
{
    public class PersonTest
    {
        [Fact]
        public void NoParams_GetAllNames_IsNotNull()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(null, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FilterPersonWithGenderM_ReturnsOnlyMaleNames()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(Models.Gender.M, null);

            Assert.All(result, n => Assert.Equal(Models.Gender.M, n.Gender));

        }

        [Fact]
        public void FilterPersonWithGenderF_ReturnsOnlyFemaleNames()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(Models.Gender.F, null);

            Assert.All(result, n => Assert.Equal(Models.Gender.F, n.Gender));

        }

        [Fact]
        public void FilterPersonWithStartsWith_ReturnsFilteredNames()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(null, "D");

            Assert.All(result, n => Assert.StartsWith("D", n.Name));

        }

        [Fact]
        public void FilterPersonWithStartsWith_LetterWithLowerAndUpperCase_ReturnsFilteredNames()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(null, "dA");

            Assert.All(result, n => Assert.StartsWith("Da", n.Name));

        }

        [Fact]
        public void FilterPersonWithStartsWithAndGender_ReturnsFilteredNamesWithGender()
        {
            //Arrange
            var repository = new PersonRepository();
            var service = new PersonService(repository);

            //Act
            var result = service.FilterPerson(Models.Gender.M, "A");
            Assert.Multiple(
                () => Assert.All(result, n => Assert.StartsWith("A", n.Name)),
                () => Assert.All(result, n => Assert.Equal(Models.Gender.M, n.Gender))
                );
        }

    }
}