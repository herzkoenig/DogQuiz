using Microsoft.AspNetCore.Mvc.RazorPages;
using DogQuiz.TempUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DogQuiz.TempUI.Pages;

public class CreateBreedModel : PageModel
{
	private readonly ApiService _apiService;

	public CreateBreedModel(ApiService apiService)
	{
		_apiService = apiService;
	}

	[BindProperty]
	public BreedInputModel Input { get; set; } = new();

	public List<CountryViewModel> AvailableCountries { get; private set; } = new();

	public async Task OnGetAsync()
	{
		try
		{
			AvailableCountries = await _apiService.GetAsync<List<CountryViewModel>>("/api/countries");
		}
		catch
		{
			ModelState.AddModelError(string.Empty, "Failed to load countries.");
		}
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		try
		{
			var payload = new
			{
				Input.Name,
				Input.Description,
				Input.Difficulty,
				Input.HistoricalContext,
				Input.AdditionalNames,
				Input.AdditionalImageUrls
			};

			await _apiService.PostAsync<object, object>("/api/breeds", payload);
			TempData["SuccessMessage"] = "Breed created successfully!";
			return RedirectToPage("Index");
		}
		catch (Exception ex)
		{
			ModelState.AddModelError(string.Empty, $"Failed to create breed: {ex.Message}");
			return Page();
		}
	}

	public class BreedInputModel
	{
		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(500)]
		public string? Description { get; set; }

		[Range(1, 10)]
		public int? Difficulty { get; set; }

		public string? HistoricalContext { get; set; }
		public List<string> AdditionalNames { get; set; } = new();
		public List<string> AdditionalImageUrls { get; set; } = new();
	}

	public class CountryViewModel
	{
		public string Name { get; set; }
		public string? TwoLetterCode { get; set; }
	}
}
