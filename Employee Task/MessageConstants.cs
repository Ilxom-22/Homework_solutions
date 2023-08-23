namespace Employee_Task;

public class MessageConstants
{
    public const string EmployeeToken = "{{Employee}}";
    public const string CompanyToken = "[Your Company]";

    public const string ConfirmationEmailSubject = "Confirm Your Email Address";
    public const string ConfirmationEmailBody = "Dear {{Employee}},\r\n\r\n" +
        "Thank you for joining the team. To start your journey we need to first confirm your email address, " +
        "please click on the following link to confirm your email address:\r\n\r\n" +
        "If you received this email mistakenly, please ignore this email.\r\n\r\n" +
        "Thank you";

    public const string WelcomeEmailSubject = "Welcome to [Your Company]";
    public const string WelcomeEmailBody = "Dear {{Employee}},\r\n\r\n" +
        "We are thrilled to welcome you! We are excited to have you on board and look forward to working with you.\r\n\r\n" +
        "As a new member of our team, we want to make sure you have everything you need to get started. " +
        "Please let us know if you have any questions or need any assistance.\r\n\r\n" +
        "We wish you all the best in your new role and look forward to your contributions to our team.\r\n\r\n" +
        "Best regards";

    public const string OfficePoliciesSubject = "Office Policies and Guidelines";
    public const string OfficePoliciesBody = "Dear {{Employee}},\r\n\r\n" +
        "As a member of our team, it is important that you are aware of our office policies and guidelines. " +
        "These policies are designed to ensure a safe and productive work environment for everyone.\r\n\r\n" +
        "Please take a moment to review the attached document, which outlines our policies and guidelines. " +
        "If you have any questions or concerns, please do not hesitate to reach out to us.\r\n\r\n" +
        "Thank you for your cooperation and adherence to our policies.\r\n\r\n" +
        "Best regards";
}
