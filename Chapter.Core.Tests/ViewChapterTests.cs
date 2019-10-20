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


        [TestCase("Agile 101")]
        [TestCase("Agile Leadership Works!")]
        public void CanViewAChapter(string name)
        {
            _chapter = new Chapter
            {
                Name = name
            };
            
            var viewChapter = new ViewChapter(this);
            dynamic request = new ExpandoObject();
            request.Id = "asd";
            
            dynamic response = viewChapter.Execute(request);

            ((string) response.Name).Should().Be(name);
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