using FastEndpoints;

namespace BoxonBrandAPI.FormData;

public class Create : Endpoint<FormSubmissionRequest, FormSubmissionResponse>
{

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("/api/form/submit-fast"); // Define the endpoint route
        AllowAnonymous(); // Allow anonymous access
        Summary(s =>
        {
            s.Summary = "Submit a form with users from both English and Arabic lists";
            s.Description = "This endpoint receives a form submission and calculates the number of users in each list.";
            s.Responses[200] = "Form submission processed successfully";
            s.Responses[400] = "Invalid form data";
        });
    }

    public override async Task HandleAsync(FormSubmissionRequest req, CancellationToken ct)
    {
        // Count the number of users added
        int englishUsersCount = req.Users?.Count ?? 0;
        int arabicUsersCount = req.UsersArabic?.Count ?? 0;

        // Log the received data (for demonstration)
        await Console.Out.WriteLineAsync("English Users:");
        foreach (var user in req.Users ?? [])
        {
            await Console.Out.WriteLineAsync($"Name: {user.Name}, Email: {user.Email}, Phone: {user.Phone}");
        }

        await Console.Out.WriteLineAsync("Arabic Users:");
        foreach (var user in req.UsersArabic ?? [])
        {
            await Console.Out.WriteLineAsync($"Name: {user.Name}, Email: {user.Email}, Phone: {user.Phone}");
        }

        // Create the response object
        var response = new FormSubmissionResponse
        {
            Status = "Success",
            EnglishUsersAdded = englishUsersCount,
            ArabicUsersAdded = arabicUsersCount
        };

        // Return the response
        await SendAsync(response, cancellation: ct);
    }
}
