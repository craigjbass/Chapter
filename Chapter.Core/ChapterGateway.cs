namespace Chapter
{
    public interface ChapterGateway
    {
        Chapter One(string id);
        string Save(Chapter chapter);
    }
}