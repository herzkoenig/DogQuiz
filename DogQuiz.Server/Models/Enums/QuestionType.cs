namespace DogQuiz.Server.Models.Enums;

public enum QuestionType
{
    SingleImageMultipleNames,
    MultipleImagesSingleName,
    TrueOrFalse,
    SingleChoiceText,
    MultipleChoiceText,
    MatchImageToBreed,
    IdentifyBreedFromDescription,
    FillInTheBlank, // e.g. origin, role, health, historical use, coat type, size, famous owner, ...
    GuessTheOrigin,
    MatchBreedToRole
}