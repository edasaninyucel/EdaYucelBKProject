using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using EdaYucel_BKProject.Models.Response;


namespace EdaYucel_BKProject.Specs.Drivers
{
    public class Driver
    {
        public static string GetToken()
        {
            var loginClient = new RestClient(new RestClientOptions(baseUrl: "https://seam.riskscore.cards/api/v2/")
            {
                Authenticator = new HttpBasicAuthenticator(username: "4f9cd500fd2c44bc91b8058e9551a7b9",
                    password: "499efbe1a8754e1ba0d94aef2203baf7")

            });
            var request = new RestRequest(resource: "oauth/token", Method.Post);
            request.AddParameter(name: "grant_type", value: "client_credentials");

            var response = loginClient.Post<GetTokenResponse>(request);

            if (response == null)
            {
                throw new Exception(message: "Error on get token process, check credentials");
            }

            return response.AccessToken; 
            
        }
        public static RestClient GetClient()
        {
            return new RestClient(new RestClientOptions(baseUrl: "https://seam.riskscore.cards/api/v2/")
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken: GetToken(), tokenType: "Bearer")
            });
            
        }
        }
        
        
        
}
