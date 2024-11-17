//using Microsoft.EntityFrameworkCore;

//namespace DogQuiz.API;

//public class CreateDummyData(DbContext context)
//{
//	private readonly DbContext context = context;

//	public void CreateData()
//	{

//		/* NOT FULLY WORKING YET */
//		//var faker = new Faker();
//		//var breedFaker = new Faker<Breed>()
//		//    .RuleFor(b => b.Name, f => f.Random.Word() + $" {f.Random.Word}".OrNull(f, .3f) + $" {f.Random.Word}".OrNull(f, .8f))
//		//    .RuleFor(b => b.Description, f => f.Lorem.Sentence(f.Random.Int(1, 10)).OrNull(f, .4f))
//		//    .RuleFor(b => b.Origin, f => f.Address.Country())
//		//    .RuleFor(b => b.Difficulty, f => f.Random.Int(1, 10).OrNull(f, .3f))
//		//    .RuleFor(b => b.Image, f => new ImageDetail
//		//    {
//		//        Folder = "images/breeds",
//		//        FileName = f.System.FileName("jpg"),
//		//        Attribution = f.Name.FullName(),
//		//        License = f.Random.Word() + " License"
//		//    })
//		//    .RuleFor(b => b.AdditionalImages, f => new Faker<ImageDetail>()
//		//        .RuleFor(i => i.Folder, "Images/breeds")
//		//        .RuleFor(i => i.FileName, f => f.System.FileName("jpg"))
//		//        .RuleFor(i => i.Attribution, f => f.Name.FullName())
//		//        .RuleFor(i => i.License, f => f.Random.Word() + " License")
//		//        .Generate(f.Random.Int(1, 3)))  // Generates 1 to 3 additional images
//		//    .RuleFor(b => b.AdditionalNames, f => new Faker<BreedName>()
//		//        .RuleFor(n => n.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(n => n.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(n => n.Name, f => f.Commerce.ProductName())
//		//        .Generate(f.Random.Int(1, 2)))  // Generates 1 or 2 additional names
//		//    .RuleFor(b => b.Varieties, f => new Faker<BreedVariety>()
//		//        .RuleFor(v => v.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(v => v.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(v => v.Name, f => f.Random.Word() + " Variety")
//		//        .Generate(f.Random.Int(0, 2)))  // Generates up to 2 varieties
//		//    .RuleFor(b => b.Roles, f => new Faker<BreedRole>()
//		//        .RuleFor(r => r.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(r => r.PermissionRole, f => f.PickRandom<BreedRoleType>())
//		//        .Generate(f.Random.Int(1, 3)))  // Generates 1 to 3 roles
//		//    .RuleFor(b => b.Facts, f => new Faker<Fact>()
//		//        .RuleFor(fa => fa.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(fa => fa.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(fa => fa.Type, f => f.PickRandom<FactType>())
//		//        .RuleFor(fa => fa.Content, f => f.Lorem.Paragraph())
//		//        .Generate(f.Random.Int(1, 3)))  // Generates 1 to 3 facts
//		//    .RuleFor(b => b.NotableDogs, f => new Faker<NotableDog>()
//		//        .RuleFor(d => d.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(d => d.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(d => d.Name, f => f.Name.FirstName())
//		//        .RuleFor(d => d.KnownFor, f => f.Commerce.Product())
//		//        .RuleFor(d => d.Description, f => f.Lorem.Sentence())
//		//        .RuleFor(d => d.PrimaryImage, f => new ImageDetail
//		//        {
//		//            Folder = "images/dogs",
//		//            FileName = f.System.FileName("jpg"),
//		//            Attribution = f.Name.FullName()
//		//        })
//		//        .Generate(f.Random.Int(1, 2)))  // Generates 1 or 2 notable dogs
//		//    .RuleFor(b => b.NotableOwners, f => new Faker<NotableOwner>()
//		//        .RuleFor(o => o.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(o => o.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(o => o.Name, f => f.Name.FullName())
//		//        .RuleFor(o => o.KnownFor, f => f.Company.CatchPhrase())
//		//        .RuleFor(o => o.Description, f => f.Lorem.Sentence())
//		//        .RuleFor(o => o.PrimaryImage, f => new ImageDetail
//		//        {
//		//            Folder = "images/owners",
//		//            FileName = f.System.FileName("jpg"),
//		//            Attribution = f.Name.FullName()
//		//        })
//		//        .Generate(f.Random.Int(1, 2)))  // Generates 1 or 2 notable owners
//		//    .RuleFor(b => b.Questions, f => new Faker<Question>()
//		//        .RuleFor(q => q.Id, f => f.Random.Int(1, 1000))
//		//        .RuleFor(q => q.BreedId, f => f.Random.Int(1, 1000))
//		//        .RuleFor(q => q.QuestionTextType, f => f.PickRandom<QuestionTextType>())
//		//        .RuleFor(q => q.QuestionTextType, f => f.PickRandom<QuestionTextType>())
//		//        .RuleFor(q => q.Title, f => f.Lorem.Sentence())
//		//        .RuleFor(q => q.Text, f => f.Lorem.Paragraph())
//		//        .RuleFor(q => q.Difficulty, f => f.Random.Int(1, 5))
//		//        .RuleFor(q => q.TextAnswer, f => new TextAnswer
//		//        {
//		//            Id = f.Random.Int(1, 1000),
//		//            QuestionId = f.Random.Int(1, 1000),
//		//            Type = f.PickRandom<AnswerType>(),
//		//            Text = f.Lorem.Sentence(),
//		//        })
//		//        .Generate(f.Random.Int(1, 3)));

//		//context.Set<Breed>().Add(breedFaker.Generate());
//		//context.SaveChanges();
//	}
//}