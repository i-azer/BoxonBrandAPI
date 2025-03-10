namespace BoxonBrandAPI.FormData;

public class FormSubmissionResponse
{
	public string Status { get; set; } // Status of the submission (e.g., "Success", "Error")
	public int EnglishUsersAdded { get; set; } // Number of users added in the English list
	public int ArabicUsersAdded { get; set; } // Number of users added in the Arabic list
}

