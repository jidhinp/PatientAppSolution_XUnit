using Xunit;
using Moq;
using App;

namespace App.Tests
{
    public class PatientServiceTests
    {
        [Fact]
        public void GetPatientSummary_ReturnsCorrectSummary()
        {
            // Arrange
            var mockRepo = new Mock<IPatientRepository>();
            mockRepo.Setup(r => r.GetPatient(1)).Returns(new Patient
            {
                Name = "John",
                Age = 30,
                Gender = "Male",
                Address = "New York"
            });

            var service = new PatientService(mockRepo.Object);

            // Act
            var summary = service.GetPatientSummary(1);

            // Assert
            Assert.Equal("John, 30 years old, Male from New York", summary);
        }
    }
}
