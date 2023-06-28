using System.Net;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebApplication1.Models.DTOs;
using Xunit;

namespace WebApplication1.Test.IntegrationTest;

public class IntegrationTest
{
    private readonly HttpClient _httpClient;
    public IntegrationTest()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task StartIntegrationTest()
    {
        //Create
        var request = new CreateUserRequest
        {
            FirstName = "john",
            LastName = "doe",
            Password = "123456",
            Username = "j1"
        };
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7107/User/CreateUser", request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //Get
        response = await _httpClient.GetAsync("https://localhost:7107/User/GetUser");
        var responseJson = await response.Content.ReadAsStringAsync();
        var userInfos = JsonConvert.DeserializeObject<List<UserInfo>>(responseJson);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, userInfos.Count);
        Assert.Equal(1, userInfos[0].Id);
        Assert.Equal(3, userInfos[1].Id);
         
         
         
         //Put
         var httpRequest = new HttpRequestMessage(HttpMethod.Put, "https://localhost:7107/User/UpdateUser");
         httpRequest.Content =
             new StringContent(
                 JsonConvert.SerializeObject(new UpdateUserRequest
                     { 
                         FirstName = "a",
                         LastName = "b",
                         OldPassword = "123456",
                         Username = "j1",
                         Password = "123456",
                         OldUserName = "j1"
                     }
                 ),
                 Encoding.UTF8, "application/json");
         response = await _httpClient.SendAsync(httpRequest);
         Assert.Equal(HttpStatusCode.OK, response.StatusCode);
         
         //Delete
         httpRequest = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7107/User/DeleteUser");
         httpRequest.Content = new StringContent(JsonConvert.SerializeObject(new CreateUserRequest
             {
                 Username = "j1",
                 Password = "123456"
                 
             }
         ), Encoding.UTF8, "application/json");
         response = await _httpClient.SendAsync(httpRequest);
         Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
    
}