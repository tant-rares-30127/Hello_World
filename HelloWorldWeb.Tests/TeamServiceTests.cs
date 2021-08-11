using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTests
    {
        private ITimeService timeService;

        public TeamServiceTests()
        {
            this.timeService = new FakeTimeService();
        }

        [Fact]
        public void GettingAgeTest()
        {
            // Assume

            var newTeamMember = new Member("Lisa", 6, timeService);
            newTeamMember.Birthdate = new DateTime(1990, 10, 13);

            // Act

            int age = newTeamMember.GetAge();

            // Assert

            Assert.Equal(30, age);
        }
    }
    internal class FakeTimeService : ITimeService
    {
        public DateTime Now()
        {
            return new DateTime(2021, 08, 11);
        }
    }
}

