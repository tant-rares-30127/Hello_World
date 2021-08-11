using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTests
    {
        [Fact]
        public void GettingAgeTest()
        {
            // Assume

            var newTeamMember = new Member("Lisa", 6);
            newTeamMember.Birthdate = new DateTime(1990, 10, 13);

            // Act

            int age = newTeamMember.GetAge();

            // Assert

            Assert.Equal(30, age);
        }
    }
}
