namespace DogQuiz.Server.Enums;

/// <summary>
/// Specifies the type of question format in the quiz.
/// </summary>
public enum QuestionType
{
    /// <summary>
    /// One image with multiple name options to choose from.
    /// </summary>
    SingleImageMultipleNames,

    /// <summary>
    /// Multiple images with one name option to match.
    /// </summary>
    MultipleImagesSingleName,

    /// <summary>
    /// A true or false question.
    /// </summary>
    TrueOrFalse,

    /// <summary>
    /// A multiple-choice text question without images.
    /// </summary>
    MultipleChoiceText,

    /// <summary>
    /// Match a set of images to their correct dog breeds.
    /// </summary>
    MatchImageToBreed
}