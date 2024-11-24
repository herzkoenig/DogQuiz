namespace DogQuiz.TempUI.Services;

public class ApiService
{
	private readonly HttpClient _httpClient;

	public ApiService(IHttpClientFactory httpClientFactory)
	{
		_httpClient = httpClientFactory.CreateClient("API");
	}

	public async Task<T?> GetAsync<T>(string endpoint)
	{
		var response = await _httpClient.GetAsync(endpoint);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<T>();
	}

	public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
	{
		var response = await _httpClient.PostAsJsonAsync(endpoint, data);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<TResponse>();
	}

	public async Task DeleteAsync(string endpoint)
	{
		var response = await _httpClient.DeleteAsync(endpoint);
		response.EnsureSuccessStatusCode();
	}
}
