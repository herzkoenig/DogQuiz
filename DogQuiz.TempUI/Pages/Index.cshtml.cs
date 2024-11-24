using Microsoft.AspNetCore.Mvc.RazorPages;
using DogQuiz.TempUI.Services;

namespace DogQuiz.TempUI.Pages;

public class IndexModel : PageModel
{
	private readonly ApiService _apiService;

	public IndexModel(ApiService apiService)
	{
		_apiService = apiService;
	}

	public List<BreedViewModel> Breeds { get; set; } = new();

	//public async Task OnGetAsync()
	//{
	//	try
	//	{
	//		// Fetch breeds from the API
	//		var breeds = await _apiService.GetAsync<List<BreedViewModel>>("/api/breeds");
	//		if (breeds != null)
	//		{
	//			Breeds = breeds;
	//		}
	//	}
	//	catch (Exception ex)
	//	{
	//		// Handle errors
	//		ModelState.AddModelError(string.Empty, "Failed to load breeds: " + ex.Message);
	//	}
	//}

	public class BreedViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
	}
}
