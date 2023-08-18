namespace Extension_Methods_Task;

public static class CollectionExtensions
{
    public static List<Skill> Update(this ICollection<Skill> first, ICollection<Skill> second)
    {
        var list = first.ToList();

        var addedItems = second.Except(first);
        var deletedItems = first.Except(second);
        var updatedItems = first.Select(item => item.Id).Intersect(second.Select(item => item.Id));

        foreach(var item in addedItems)
            list.Add(item);

        foreach (var item in deletedItems)
            list.Remove(item);

        foreach (var item in updatedItems)
        {
            var firstItem = list.First(first => first.Id == item);
            var secondItem = second.First(sec => sec.Id == item);

            firstItem.Name = secondItem.Name;
            firstItem.Level = secondItem.Level;
        }

        return list;
    }
}

