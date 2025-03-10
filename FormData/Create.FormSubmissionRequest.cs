namespace BoxonBrandAPI.FormData;

public class FormSubmissionRequest
{
    public List<UserData> Users { get; set; }
    public List<UserData> UsersArabic { get; set; }
}

public class UserData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
