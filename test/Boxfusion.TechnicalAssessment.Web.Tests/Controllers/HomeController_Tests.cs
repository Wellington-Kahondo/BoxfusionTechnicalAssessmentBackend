using System.Threading.Tasks;
using Boxfusion.TechnicalAssessment.Models.TokenAuth;
using Boxfusion.TechnicalAssessment.Web.Controllers;
using Shouldly;
using Xunit;

namespace Boxfusion.TechnicalAssessment.Web.Tests.Controllers
{
    public class HomeController_Tests: TechnicalAssessmentWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}