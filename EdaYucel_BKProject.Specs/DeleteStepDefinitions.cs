using System.Net;
using System.Text.Json;
using EdaYucel_BKProject.Models.Request;
using EdaYucel_BKProject.Models.Response;
using EdaYucel_BKProject.Specs.Drivers;
using FluentAssertions;
using RestSharp;
namespace EdaYucel_BKProject.Specs;

[Binding]
public class DeleteStepDefinitions
{
    private readonly CompanyDeleteRequest _companyRequest;
    private readonly EcosystemDeleteRequest _ecosystemRequest;
    
    private HttpStatusCode _getCompanyStatusCode;

    public DeleteStepDefinitions(CompanyDeleteRequest companyRequest, EcosystemDeleteRequest ecosystemRequest, HttpStatusCode getCompanyStatusCode)
    {
        _companyRequest = companyRequest;
        _ecosystemRequest = ecosystemRequest;
        _getCompanyStatusCode = getCompanyStatusCode;
    }
    [Given(@"the company id is (.*)")]
    public void GivenTheCompanyIdIs(int companyId)
    {
        _companyRequest.CompanyId = companyId;
        
    }
    [Given(@"the company deleted")]
    public void GivenTheCompanyDeleted()
    {
        var client = Driver.GetClient();
        var request = new RestRequest(resource: "companies/" + _companyRequest.CompanyId);
        request.AddJsonBody(_companyRequest);

        var response = client.Delete(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);    
    }

    [When(@"get the company")]
    public void WhenGetTheCompany()
    {
        var client = Driver.GetClient();
        
        var request = new RestRequest(resource: "companies/" + _companyRequest.CompanyId);
        request.AddJsonBody(_companyRequest);
        
        var response = client.Get(request);

        _getCompanyStatusCode = response.StatusCode;    }

    [Then(@"status code will not be success")]
    public void ThenStatusCodeWillNotBeSuccess()
    {
        _getCompanyStatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Given(@"the ecosystem id is (.*)")]
    public void GivenTheEcosystemIdIs(int ecosystemId)
    {
        _ecosystemRequest.Id = ecosystemId;    }
    
    [Then(@"the ecosystem deleted")]
    public void ThenTheEcosystemDeleted()
    {
        var client = Driver.GetClient();

        var request = new RestRequest(resource: "ecosystems/" + _ecosystemRequest.Id);
        request.AddJsonBody(_ecosystemRequest);

        var response = client.Delete(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
    }
}