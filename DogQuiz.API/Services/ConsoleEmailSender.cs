using DogQuiz.Data.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace DogQuiz.API.Services;

public class ConsoleEmailSender : IEmailSender<User>
{
	public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
	{
		Console.WriteLine($"[Confirmation Email]\nTo: {email}\nUser: {user.Username}\nConfirmation Link: {confirmationLink}\n");
		return Task.CompletedTask;
	}

	public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
	{
		Console.WriteLine($"[Password Reset Code]\nTo: {email}\nUser: {user.Username}\nReset Code: {resetCode}\n");
		return Task.CompletedTask;
	}

	public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
	{
		Console.WriteLine($"[Password Reset Link]\nTo: {email}\nUser: {user.Username}\nReset Link: {resetLink}\n");
		return Task.CompletedTask;
	}
}