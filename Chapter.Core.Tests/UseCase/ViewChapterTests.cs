using System.Dynamic;
using Chapter.Port;
using Chapter.UseCase;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.Core.Tests.UseCase
{
    public class ViewChapterTests : ChapterReader
    {
        private Domain.Chapter _chapter;
        private string _lastId;
        public Domain.Chapter One(string id)
        {
            _lastId = id;
            return _chapter;
        }

        [TestCase("a", "Agile 101", "For beginners")]
        [TestCase("z", "Agile Leadership Works!", "For everyone else")]
        public void CanViewAChapter(string id, string name, string description)
        {
            _chapter = new Domain.Chapter
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