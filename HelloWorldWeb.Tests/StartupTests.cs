using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToAspNetString()
        {
            //Assume
            string herokuConnectionString = "postgres://jfmvtlnuwfpgfc:bd8afec8a163c1da7c4cbd9ce8a9f11292da0b8fade3d1e0f15562fe096a3407@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/d6j4bkkcivkb88";

            //Act
            string aspNetConnectionString = Startup.ConvertHerokuStringToAspnetString(herokuConnectionString);

            //Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=d6j4bkkcivkb88;User Id=jfmvtlnuwfpgfc;Password=bd8afec8a163c1da7c4cbd9ce8a9f11292da0b8fade3d1e0f15562fe096a3407;Pooling=true;SSL Mode=Require;TrustServerCertificate=True", aspNetConnectionString);
        }
    }
}
