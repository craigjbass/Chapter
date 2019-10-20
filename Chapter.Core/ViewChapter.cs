using System.Dynamic;

namespace Chapter
{
    public class ViewChapter
    {
        private readonly ChapterGateway _chapterGateway;

        public ViewChapter(ChapterGateway chapterGateway)
        {
            _chapterGateway = chapterGateway;
        }

        public dynamic Execute(dynamic request)
        {
            var chapter = _chapterGateway.One(request.Id);

            dynamic response = new ExpandoObject();
            response.Id = chapter.Id;
            response.Name = chapter.Name;
            response.Description = chapter.Description;
            return response;
        }
    }
}