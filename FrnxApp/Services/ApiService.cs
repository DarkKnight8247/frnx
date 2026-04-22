using System.Net.Http.Json;
using FrnxApp.Models;

namespace FrnxApp.Services;

public class ApiService
{
    private readonly HttpClient _http;

    private string baseUrl = "http://10.0.2.2:5139/api/post";

    public ApiService()
    {
        _http = new HttpClient();
    }

    // READ (GET)
    public async Task<List<Post>> GetPosts()
    {
        return await _http.GetFromJsonAsync<List<Post>>(baseUrl)
               ?? new List<Post>();
    }

    // CREATE (POST)
    public async Task AddPost(Post post)
    {
        await _http.PostAsJsonAsync(baseUrl, post);
    }

    // DELETE
    public async Task DeletePost(int id)
    {
        await _http.DeleteAsync($"{baseUrl}/{id}");
    }

    // UPDATE (optional but good to have)
    public async Task UpdatePost(Post post)
    {
        await _http.PutAsJsonAsync($"{baseUrl}/{post.Id}", post);
    }
}