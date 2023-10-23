using System.Net;
using System.Text.Json;
using EdaYucel_BKProject.Models.Request;
using EdaYucel_BKProject.Models.Response;
using EdaYucel_BKProject.Specs.Drivers;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using RestSharp;

namespace EdaYucel_BKProject.Specs;

[Binding]
public class CompanyStepDefinitions
{
    private readonly CompanyCreateRequest _createRequest;
    private readonly CompanySearchRequest _searchRequest;
    private readonly CompanyListRequest _listRequest;
    private CompanyCreateResponse _createResponse;
    private CompanySearchResponse _searchResponse;
    private CompanyListResponse _listResponse;

    private readonly ScenarioContext _scenarioContext;
    

    public CompanyStepDefinitions(CompanyCreateRequest createRequest, CompanyCreateResponse createResponse, ScenarioContext scenarioContext)
    {
        _createRequest = createRequest;
        _createResponse = createResponse;
        _scenarioContext = _scenarioContext;
    }
    
    [Given(@"the domain name is ""(.*)""")]
    public void GivenTheDomainNameIs(string domainName)
    {
        _createRequest.MainDomainValue = domainName;
    }

    [Given(@"the company name is ""(.*)""")]
    public void GivenTheCompanyNameIs(string companyName)
    {
        _createRequest.CompanyName = companyName;
    }

    [Given(@"the ecosystem id for company is (.*)")]
    public void GivenTheEcosystemIdForCompanyIs(string ecosystemId)
    {
        _createRequest.EcosystemId = ecosystemId;
    }
    [Given(@"the licence type is ""(.*)""")]
    public void GivenTheLicenceTypeIs(string licenseType)
    {
        _createRequest.LicenseType = licenseType;
    }
    [When(@"the company created")]
    public void WhenTheCompanyCreated()
    {
        var client = Driver.GetClient();
        
        var request = new RestRequest(resource: "companies");
        request.AddJsonBody(_createRequest);
        
        var response = client.Post(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        _createResponse = JsonSerializer.Deserialize<CompanyCreateResponse>(response.Content);
    }
    [Then(@"company id will be returned")]
    public void ThenCompanyIdWillBeReturned()
    {
        _createResponse.CompanyId.Should().BePositive();
    }
//------------------------------------
    [Given(@"send the ecosystem id (.*)")]
    public void GivenSendTheEcosystemId(int ecosystemId)
    {
        _searchRequest.EcosystemIds = ecosystemId;
    }
    [Given(@"send the GenericSearchText is ""(.*)"";")]
    public void GivenSendTheGenericSearchTextIs(string majid)
    {
        _searchRequest.GenericSearchText = majid;
    }

    [When(@"search the company")]
    public void WhenSearchTheCompany()
    {
        var client = Driver.GetClient();
        var request = new RestRequest(resource: "companies/search");
        request.AddJsonBody(_searchRequest);
        
        var response = client.Post(request);
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        _searchResponse = JsonSerializer.Deserialize<CompanySearchResponse>(response.Content);
    }

    [Then(@"api will be returned key")]
    public void ThenApiWillBeReturnedKey(int key)
    {
        _searchResponse.Key = key;
    }
//-------
    [Given(@"send the key")]
    public void GivenSendTheKey(string key)
    {
        _listRequest.Key = _searchResponse.Key;
    }

    [Given(@"get the company")]
    public void GivenGetTheCompany()
    {
        var client = Driver.GetClient();
        var request = new RestRequest(resource: "companies");
        request.AddJsonBody(_listResponse);
        var response = client.Get(request);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        _listResponse = JsonSerializer.Deserialize<CompanyListResponse>(response.Content);
        
    }

    [When(@"verify scan status is ""(.*)""")]
    public void WhenVerifyScanStatusIs(string scanStatus)
    {
        _listResponse.ScanStatus = scanStatus;
        scanStatus.Should().Be("Extended Rescan Results Ready");
    }

    [Then(@"verify Values")]
    public void ThenVerifyValues()
    {
        _createResponse.CompanyId.Should().BePositive();
        _createResponse.CompanyName.Should().NotBeNull();
        _createResponse.MainDomainValue.Should().NotBeNull();
        _createResponse.EcosystemId.Should().BePositive();
        _createResponse.EcosystemName.Should().NotBeNull();
        
    }


    
}