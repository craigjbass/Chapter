namespace Chapter.Port
{
    public interface ChapterReader
    {
        Domain.Chapter One(string id);
    }
}