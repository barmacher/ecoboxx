//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace EcoboxApi.IntegrationTests
//{
//    internal class IntegrationTestOne
//    {
//        [Fact, Priority(1)]
//        public async Task GetAll_WithoutAnyDepartaments_ReturnsEmptyResponse()
//        {
//            // Arrange          
//            await AuthenticateAsync();
//            // Act
//            var response = await TestClient.GetAsync("https://localhost:44312/api/Departments");

//            // Assert
//            response.StatusCode.Should().Be(HttpStatusCode.OK);
//            (await response.Content.ReadFromJsonAsync<List<DepartmentModels.GetDepartmentModel>>()).Should().BeEmpty();
//        }

//    }
//}
