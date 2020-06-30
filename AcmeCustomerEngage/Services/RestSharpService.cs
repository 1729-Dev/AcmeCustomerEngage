using RestSharp;
using System;

namespace AcmeCustomerEngage.Services
{
    public class RestSharpService
    {
        private static RestClient client;
        private static RestRequest request;

        public RestSharpService(string baseUrl, string endPoint)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(endPoint, DataFormat.Json);
        }

        public RestResponse<T> GetResponseExpectOK<T>()
        {
            IRestResponse<T> response = client.Get<T>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(string.Format("Expected: StatusCode 'OK'. Actual: {0}. BaseUrl: {1}. EndPoint: {2}. Response: {3}",
                    response.StatusCode,
                    client.BaseUrl,
                    request.Resource,
                    response));
            }

            return (RestResponse<T>)response;
        }
    }
}
