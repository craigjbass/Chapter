using System.Dynamic;
using Chapter.Port;

namespace Chapter.UseCase
{
    public class ViewChapter
    {
        private readonly ChapterReader _chapterGateway;

        public ViewChapter(ChapterReader chapterGateway)
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