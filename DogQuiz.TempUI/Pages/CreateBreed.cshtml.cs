using DogQuiz.TempUI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
			// Fetch available countries from the API
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
				Origin = Input.Countries,
				Roles = Input.Roles,
				BreedTags = Input.BreedTags,
				AdditionalNames = Input.AdditionalNames
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

		[Required]
		public List<string> Countries { get; set; } = new();

		public List<string> Roles { get; set; } = new();

		public List<string> BreedTags { get; set; } = new();

		public List<string> AdditionalNames { get; set; } = new();
	}

	public class CountryViewModel
	{
		public string Name { get; set; }
		public string TwoLetterCode { get; set; }
	}
}
