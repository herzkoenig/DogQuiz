using DogQuiz.Server.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DogQuiz.Server.Models.CreateDummyData;

public class CreateDummyData(DbContext context)
{
    private readonly DbContext context = context;

    public void CreateDataData()
    {
        //var breed = new Breed
        //{
        //    Name = "Labrador Retriever",
        //    Description = "A popular family dog known for its friendly nature and intelligence.",
        //    Origin = "Canada",
        //    Difficulty = 2,
        //    Image = new ImageDetail
        //    {
        //        Folder = "Images/Breeds/Labrador",
        //        FileName = "labrador_primary.jpg",
        //        Attribution = "Photo by Jane Doe",
        //        License = "CC BY-SA 4.0"
        //    }
        //};

        //// Adding items individually for AdditionalNames
        //breed.AdditionalNames.Add(new BreedName { Name = "Lab" });
        //breed.AdditionalNames.Add(new BreedName { Name = "Labrador" });

        //// Adding items individually for AdditionalImages
        //breed.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/Labrador", FileName = "labrador_1.jpg" });
        //breed.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/Labrador", FileName = "labrador_2.jpg" });

        //// Adding items individually for Varieties
        //breed.Varieties.Add(new BreedVariety { Name = "American Labrador" });
        //breed.Varieties.Add(new BreedVariety { Name = "English Labrador" });

        //// Adding items individually for Roles
        //breed.Roles.Add(BreedRoleType.Companion);
        //breed.Roles.Add(BreedRoleType.Assistance);
        //breed.Roles.Add(BreedRoleType.Therapy);

        //// Adding items individually for Facts
        //breed.Facts.Add(new BreedFact { Type = FactType.Historical, Text = "Originally bred in Newfoundland." });
        //breed.Facts.Add(new BreedFact { Type = FactType.Behavioral, Text = "Known for its excellent retrieving skills." });

        //// Adding items individually for TextQuestions
        //breed.TextQuestions.Add(new Text
        //{
        //    Title = "Labrador Colors",
        //    Text = "What colors are Labradors typically found in?",
        //    Answer = new Answer { Type = AnswerType.MultipleChoice, MultipleChoiceAnswers = new List<string> { "Black", "Yellow", "Chocolate" } },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});
        //breed.TextQuestions.Add(new Text
        //{
        //    Title = "Labrador Characteristics",
        //    Text = "Are Labradors good family dogs?",
        //    Answer = new Answer { Type = AnswerType.Boolean, BooleanAnswer = true },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});

        //// Adding items individually for NotableOwners
        //breed.NotableOwners.Add(new NotableOwner { Name = "John Smith", KnownFor = "Famous dog trainer", Description = "Specialist in Labrador training" });

        //// Adding items individually for NotableDogs
        //breed.NotableDogs.Add(new NotableDog { Name = "Buddy", KnownFor = "TV Star", Description = "Appeared in several TV shows" });

        //var breed2 = new Breed
        //{
        //    Name = "German Shepherd",
        //    Description = "A highly intelligent and versatile breed, known for its loyalty and courage.",
        //    Origin = "Germany",
        //    Difficulty = 3,
        //    Image = new ImageDetail
        //    {
        //        Folder = "Images/Breeds/GermanShepherd",
        //        FileName = "german_shepherd_primary.jpg",
        //        Attribution = "Photo by John Doe",
        //        License = "CC BY-SA 4.0"
        //    }
        //};

        //// Adding items individually for AdditionalNames
        //breed2.AdditionalNames.Add(new BreedName { Name = "GSD" });
        //breed2.AdditionalNames.Add(new BreedName { Name = "Alsatian" });

        //// Adding items individually for AdditionalImages
        //breed2.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/GermanShepherd", FileName = "german_shepherd_1.jpg" });
        //breed2.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/GermanShepherd", FileName = "german_shepherd_2.jpg" });

        //// Adding items individually for Varieties
        //breed2.Varieties.Add(new BreedVariety { Name = "Working Line" });
        //breed2.Varieties.Add(new BreedVariety { Name = "Show Line" });

        //// Adding items individually for Roles
        //breed2.Roles.Add(BreedRoleType.Guarding);
        //breed2.Roles.Add(BreedRoleType.Working);
        //breed2.Roles.Add(BreedRoleType.Companion);

        //// Adding items individually for Facts
        //breed2.Facts.Add(new BreedFact { Type = FactType.Historical, Text = "Developed in Germany in the late 19th century." });
        //breed2.Facts.Add(new BreedFact { Type = FactType.Behavioral, Text = "Known for its protective instincts and trainability." });

        //// Adding items individually for TextQuestions
        //breed2.TextQuestions.Add(new Text
        //{
        //    Title = "German Shepherd Colors",
        //    Text = "What colors are German Shepherds typically found in?",
        //    Answer = new Answer { Type = AnswerType.MultipleChoice, MultipleChoiceAnswers = new List<string> { "Black and Tan", "Sable", "All Black" } },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});
        //breed2.TextQuestions.Add(new Text
        //{
        //    Title = "German Shepherd Roles",
        //    Text = "Are German Shepherds commonly used as police dogs?",
        //    Answer = new Answer { Type = AnswerType.Boolean, BooleanAnswer = true },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});

        //// Adding items individually for NotableOwners
        //breed2.NotableOwners.Add(new NotableOwner { Name = "Max von Stephanitz", KnownFor = "German dog breeder", Description = "Credited with the development of the breed" });

        //// Adding items individually for NotableDogs
        //breed2.NotableDogs.Add(new NotableDog { Name = "Rin Tin Tin", KnownFor = "Famous movie star", Description = "Appeared in numerous Hollywood films" });

        //var breed3 = new Breed
        //{
        //    Name = "Golden Retriever",
        //    Description = "A friendly, intelligent, and devoted breed, popular as a family and assistance dog.",
        //    Origin = "Scotland",
        //    Difficulty = 2,
        //    Image = new ImageDetail
        //    {
        //        Folder = "Images/Breeds/GoldenRetriever",
        //        FileName = "golden_retriever_primary.jpg",
        //        Attribution = "Photo by Alex Smith",
        //        License = "CC BY-SA 4.0"
        //    }
        //};

        //// Adding items individually for AdditionalNames
        //breed3.AdditionalNames.Add(new BreedName { Name = "Golden" });
        //breed3.AdditionalNames.Add(new BreedName { Name = "Retriever" });

        //// Adding items individually for AdditionalImages
        //breed3.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/GoldenRetriever", FileName = "golden_retriever_1.jpg" });
        //breed3.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/GoldenRetriever", FileName = "golden_retriever_2.jpg" });

        //// Adding items individually for Varieties
        //breed3.Varieties.Add(new BreedVariety { Name = "British Golden Retriever" });
        //breed3.Varieties.Add(new BreedVariety { Name = "American Golden Retriever" });

        //// Adding items individually for Roles
        //breed3.Roles.Add(BreedRoleType.Assistance);
        //breed3.Roles.Add(BreedRoleType.Companion);
        //breed3.Roles.Add(BreedRoleType.Therapy);

        //// Adding items individually for Facts
        //breed3.Facts.Add(new BreedFact { Type = FactType.Historical, Text = "Originally bred in Scotland for hunting." });
        //breed3.Facts.Add(new BreedFact { Type = FactType.Behavioral, Text = "Known for its gentle temperament and love of water." });

        //// Adding items individually for TextQuestions
        //breed3.TextQuestions.Add(new Text
        //{
        //    Title = "Golden Retriever Coat",
        //    Text = "What type of coat do Golden Retrievers typically have?",
        //    Answer = new Answer { Type = AnswerType.MultipleChoice, MultipleChoiceAnswers = new List<string> { "Smooth", "Curly", "Wavy" } },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});
        //breed3.TextQuestions.Add(new Text
        //{
        //    Title = "Golden Retriever Personality",
        //    Text = "Are Golden Retrievers generally friendly towards strangers?",
        //    Answer = new Answer { Type = AnswerType.Boolean, BooleanAnswer = true },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});

        //// Adding items individually for NotableOwners
        //breed3.NotableOwners.Add(new NotableOwner { Name = "Geraldine Rockefeller Dodge", KnownFor = "Philanthropist", Description = "One of the early breeders of Golden Retrievers in the United States" });

        //// Adding items individually for NotableDogs
        //breed3.NotableDogs.Add(new NotableDog { Name = "Liberty", KnownFor = "Presidential pet", Description = "Pet of U.S. President Gerald Ford" });

        //var breed4 = new Breed
        //{
        //    Name = "Bulldog",
        //    Description = "A muscular and loyal breed with a distinct wrinkled face and pushed-in nose, known for its gentle disposition.",
        //    Origin = "England",
        //    Difficulty = 3,
        //    Image = new ImageDetail
        //    {
        //        Folder = "Images/Breeds/Bulldog",
        //        FileName = "bulldog_primary.jpg",
        //        Attribution = "Photo by Sarah Johnson",
        //        License = "CC BY-SA 4.0"
        //    }
        //};

        //// Adding items individually for AdditionalNames
        //breed4.AdditionalNames.Add(new BreedName { Name = "British Bulldog" });
        //breed4.AdditionalNames.Add(new BreedName { Name = "English Bulldog" });

        //// Adding items individually for AdditionalImages
        //breed4.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/Bulldog", FileName = "bulldog_1.jpg" });
        //breed4.AdditionalImages.Add(new ImageDetail { Folder = "Images/Breeds/Bulldog", FileName = "bulldog_2.jpg" });

        //// Adding items individually for Varieties
        //breed4.Varieties.Add(new BreedVariety { Name = "Miniature Bulldog" });
        //breed4.Varieties.Add(new BreedVariety { Name = "Standard Bulldog" });

        //// Adding items individually for Roles
        //breed4.Roles.Add(BreedRoleType.Companion);
        //breed4.Roles.Add(BreedRoleType.Guarding);

        //// Adding items individually for Facts
        //breed4.Facts.Add(new BreedFact { Type = FactType.Historical, Text = "Originally bred for bull-baiting in England." });
        //breed4.Facts.Add(new BreedFact { Type = FactType.Behavioral, Text = "Known for being affectionate and dependable with a gentle nature." });

        //// Adding items individually for TextQuestions
        //breed4.TextQuestions.Add(new Text
        //{
        //    Title = "Bulldog Physical Traits",
        //    Text = "What characteristic physical trait is most associated with Bulldogs?",
        //    Answer = new Answer { Type = AnswerType.MultipleChoice, MultipleChoiceAnswers = new List<string> { "Wrinkled face", "Long legs", "Pointed ears" } },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});
        //breed4.TextQuestions.Add(new Text
        //{
        //    Title = "Bulldog Temperament",
        //    Text = "Are Bulldogs known to be good family pets?",
        //    Answer = new Answer { Type = AnswerType.Boolean, BooleanAnswer = true },
        //    Type = TextQuestionType.SingleImageMultipleNames
        //});

        //// Adding items individually for NotableOwners
        //breed4.NotableOwners.Add(new NotableOwner { Name = "Winston Churchill", KnownFor = "British Prime Minister", Description = "Known for his fondness of Bulldogs" });

        //// Adding items individually for NotableDogs
        //breed4.NotableDogs.Add(new NotableDog { Name = "Handsome Dan", KnownFor = "Yale University Mascot", Description = "The official live mascot of Yale since the 1880s" });

        //// Add the breed to the database context
        //context.Set<Breed>().Add(breed4);
        //context.SaveChanges();

        //// Add the breed to the database context
        //context.Set<Breed>().Add(breed3);
        //context.SaveChanges();

        //// Add the breed to the database context
        //context.Set<Breed>().Add(breed2);
        //context.SaveChanges();

        //// Add the breed to the database context
        //context.Set<Breed>().Add(breed);
        //context.SaveChanges();
    }
}
