using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace APITests
{
    [TestFixture]
    public class APITests
    {

        Users users;
        [SetUp]
        public void Setup()
        {
            users = new Users();
        }

        [Test]
        public void GetUserById_ReturnsSuccess()
        {
            // Act
            HttpResponseMessage response = users.Get("1");
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            string expectedUserName = "Leanne Graham";
            // Act
            HttpResponseMessage response = users.Get("1");
            string responseBody = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            StringAssert.Contains(expectedUserName, responseBody);
        }

        [Test]
        public void CreateUser_ReturnsCorrectUser()
        {
            // Arrange
            var userData = new
            {
                id = 1,
                name = "John Dou",
                username = "JDou",
                email = "JDou@email.com",
                address = new
                {
                    street = "Kulas Light",
                    suite = "Apt. 556",
                    city = "Gwenborough",
                    zipcode = "92998-3874",
                    geo = new
                    {
                        lat = "-37.3159",
                        lng = "81.1496"
                    }
                },
                phone = "1-770-736-8031 x56442",
                website = "hildegard.org",
                company = new
                {
                    name = "Romaguera-Crona",
                    catchPhrase = "Multi-layered client-server neural-net",
                    bs = "harness real-time e-markets"
                }
            };
            // Act
            HttpResponseMessage response = users.Create(userData);
            string responseBody = response.Content.ReadAsStringAsync().Result;
            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
