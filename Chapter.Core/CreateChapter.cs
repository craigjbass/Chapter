using System.Dynamic;

namespace Chapter
{
    public class CreateChapter
    {
        private readonly ChapterGateway _chapterGateway;

        public CreateChapter(ChapterGateway chapterGateway)
        {
            _chapterGateway = chapterGateway;
        }

        public dynamic Execute(dynamic request)
        {
            var id = _chapterGateway.Save(new Chapter()
            {
                Name = request.Name,
                Description = request.Description
            });
            dynamic response = new ExpandoObject();
            response.Id = id;
            return response;
        }
    }
}