using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTests
    {
        private Mock<ITimeService> timeMock;

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 8, 11));
        }

        [Fact]
        public void GettingAgeTest()
        {
            // Assume
            InitializeTimeServiceMock();
            var timeService = timeMock.Object;
            var newTeamMember = new Member("Lisa", 6, timeService);
            newTeamMember.Birthdate = new DateTime(1990, 10, 13);

            // Act
            int age = newTeamMember.GetAge();

            // Assert
            Assert.Equal(30, age);
            timeMock.Verify(_ => _.Now(), Times.Once());
        }
    }
}

