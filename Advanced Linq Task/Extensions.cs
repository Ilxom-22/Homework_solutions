public static class Extensions
{
    public static Guid GetOtherUserId(this Guid authorId, List<User> users)
    {
        var random = new Random();
        var userId = Guid.Empty;
        do
        {
            userId = users[random.Next(0, 20)].Id;
        } while (userId == authorId);

        return userId;
    }
}
