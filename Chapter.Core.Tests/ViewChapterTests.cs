using System.Dynamic;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.Core.Tests
{
    public class ViewChapterTests : ChapterGateway
    {
        private Chapter _chapter;
        private string _lastId;
        public Chapter One(string id)
        {
            _lastId = id;
            return _chapter;
        }

        public string Save(Chapter chapter)
        {
            throw new System.NotImplementedException();
        }


        [TestCase("a", "Agile 101", "For beginners")]
        [TestCase("z", "Agile Leadership Works!", "For everyone else")]
        public void CanViewAChapter(string id, string name, string description)
        {
            _chapter = new Chapter
            {
                Id = id,   
                Name = name,
                Description = description
            };
            
            var viewChapter = new ViewChapter(this);
            dynamic request = new ExpandoObject();
            request.Id = "asd";
            
            dynamic response = viewChapter.Execute(request);

            ((string) response.Id).Should().Be(id);
            ((string) response.Name).Should().Be(name);
            ((string) response.Description).Should().Be(description);
        }

        [TestCase("asd")]
        public void FetchesOneByCorrectId(string id)
        {
            var viewChapter = new ViewChapter(this);

            dynamic request = new ExpandoObject();
            request.Id = id;
            
            viewChapter.Execute(request);

            _lastId.Should().Be(id);

        }
    }
}