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
            return _chapterGateway.One(request.Id);
        }
    }
}