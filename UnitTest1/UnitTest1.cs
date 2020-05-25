
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labka2.Models;
using labka2.Controllers;
using Xunit;
namespace UnitTest1
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<labka2Context>()
                .UseInMemoryDatabase(databaseName: "labka2")
                .Options;
            var context = new labka2Context(options);

            Seed(context);
            var query = new PublishingHousesController(context);
            var result = query.Execute();
            Assert.Equal(3, result.Count);
            // Arrange

        }

        [Fact]
        public void Test2()
        {
            var options = new DbContextOptionsBuilder<labka2Context>()
                .UseInMemoryDatabase(databaseName: "labka2")
                .Options;
            var context = new labka2Context(options);
            Seed(context);
            var query = new PublishingHousesController(context);
            var result = query.Delete(1);
            Assert.True(result);
            // Arrange

        }
        private void Seed(labka2Context context)
        {
            var publishingHouses = new[]
            {
            new PublishingHouse {Name = "First"},
            new PublishingHouse {Name = "Second"},
            new PublishingHouse {Name = "Third"}
            };
            context.PublishingHouse.AddRange(publishingHouses);
            context.SaveChanges();
        }
    }
}
