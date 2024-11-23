namespace DogQuiz.Domain.Shared.Constants;

internal static class LengthConstants
{
	// General Name Lengths
	public const int NameShortLength = 50;
	public const int NameMediumLength = 80;
	public const int NameLongLength = 130;

	// General Descriptions
	public const int DescriptionShortLength = 750;
	public const int DescriptionMediumLength = 1250;
	public const int DescriptionLongLength = 2000;

	// User
	public const int UserNameLength = 40;
	public const int UserNameMinLength = 3;

	// Questionnaire
	public const int QuestionTextLength = 300;
	public const int QuestionTitleLength = 100;

	// Tags
	public const int TagNameLength = 100;
	public const int TagGroupNameLength = 100;

	// ImageDetail
	public const int ImageFolderPathLength = 250;
	public const int ImageFileNameLength = 150;
	public const int ImageAttributionLength = 200;
	public const int ImageLicenseLength = 100;

	// Other
	public const int KnownForLength = 300;
	public const int OriginLength = 100;

	public const int IdentityProviderId = 64;
}