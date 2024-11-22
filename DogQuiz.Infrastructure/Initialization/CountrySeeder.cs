//using DogQuiz.Infrastructure;

//namespace DogQuiz.Infrastructure.Initialization;

//internal class CountrySeeder
//{
//	private readonly ApplicationDbContext _context;

//	public CountrySeeder(ApplicationDbContext context)
//	{
//		_context = context;
//	}

//	//public void Seed()
//	//{
//	//    if (!_context.Countries.Any())
//	//    {
//	//        Console.WriteLine("Seeding countries from ISO3166...");

//	//        var countries = MapToEfCoreModel();
//	//        _context.Countries.AddRange(countries);
//	//        _context.SaveChanges();

//	//        Console.WriteLine("Countries seeded successfully.");
//	//    }
//	//    else
//	//    {
//	//        Console.WriteLine("Countries already seeded. Skipping...");
//	//    }
//	//}

//	//public static List<Entities.General.Country> MapToEfCoreModel()
//	//{
//	//    return ISO3166.Country.List
//	//        .Select(c => new Entities.General.Country
//	//        {
//	//            Name = c.Name,
//	//            TwoLetterCode = c.TwoLetterCode,
//	//            ThreeLetterCode = c.ThreeLetterCode,
//	//            NumericCode = c.NumericCode,
//	//        })
//	//        .ToList();
//	//}
//}
