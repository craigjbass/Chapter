using System.Dynamic;
using Chapter.Port;

namespace Chapter.UseCase
{
    public class CreateChapter
    {
        private readonly ChapterWriter _chapterGateway;

        public CreateChapter(ChapterWriter chapterGateway)
        {
            _chapterGateway = chapterGateway;
        }

        public dynamic Execute(dynamic request)
        {
            var id = _chapterGateway.Save(new Domain.Chapter()
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