using EdaYucel_BKProject.Models.Request;
using EdaYucel_BKProject.Models.Response;
using FluentAssertions;

namespace EdaYucel_BKProject.Specs;
using System.Net;
using System.Text.Json;
using RestSharp;
using EdaYucel_BKProject.Specs.Drivers;

[Binding]

public class EcosystemStepDefinitions
{
    private readonly EcosystemCreateRequest _createRequest;
    private readonly EcosystemVerifyRequest _verifyRequest;
    private EcosystemCreateResponse _createResponse;
    private HttpStatusCode _ecosystemVerifyStatusCode;

    public EcosystemStepDefinitions(EcosystemCreateRequest createRequest, EcosystemCreateResponse createResponse, EcosystemVerifyRequest verifyRequest, HttpStatusCode ecosystemVerifyStatusCode)
    {
        _createRequest = createRequest;
        _createResponse = createResponse;
        _verifyRequest = verifyRequest;
        _ecosystemVerifyStatusCode = ecosystemVerifyStatusCode;
    }
    
    [Given(@"the ecosystem name is ""(.*)""")]
    public void GivenTheEcosystemNameIs(string ecosystemName)
    {
        _createRequest.EcosystemName = ecosystemName;

    }
    [When(@"the ecosystem created")]
    public void WhenTheEcosystemCreated()
    {
        var client = Driver.GetClient();
        var request = new RestRequest(resource: "ecosystems");
        request.AddJsonBody(_createRequest);

        var response = client.Post(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        _createResponse = JsonSerializer.Deserialize<EcosystemCreateResponse>(response.Content);
    }

    [Then(@"ecosystem id will be returned")]
    public void ThenEcosystemIdWillBeReturned()
    {
        _createResponse.EcosystemId.Should().BePositive();
    }

    [Given(@"the ecosystem id")]
    public void GivenTheEcosystemId(int EcosystemId)
    {
        
       _verifyRequest.Id = EcosystemId;
        
    }

    [When(@"the ecosystem verified")]
    public void WhenTheEcosystemVerified()
    {
        var client = Driver.GetClient();
        var request = new RestRequest(resource: "ecosystems/" + _verifyRequest.Id);
        request.AddJsonBody(_createRequest);

        var response = client.Post(request);

        _ecosystemVerifyStatusCode = response.StatusCode;
        
    }

    [Then(@"status code will success")]
    public void ThenStatusCodeWillSuccess()
    {
        _ecosystemVerifyStatusCode.Should().Be(HttpStatusCode.OK);
        
    }
}