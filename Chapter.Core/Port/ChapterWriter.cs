namespace Chapter.Port
{
    public interface ChapterWriter
    {
        string Save(Domain.Chapter chapter);
    }
}