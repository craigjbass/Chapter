using System.Dynamic;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.Core.Tests
{
    public class CreateChapterTests : ChapterGateway
    {
        private Chapter _lastSavedChapter;
        private string _id;
        public Chapter One(string id) => null;
        public string Save(Chapter chapter)
        {
            _lastSavedChapter = chapter;
            return _id;
        }

        [TestCase("A Good Chapter", "Great")]
        [TestCase("A Better Chapter", "Betterer!")]
        public void CanCreateChapter(string name, string description)
        {
            var createChapter = new CreateChapter(this);
            dynamic request = new ExpandoObject();
            request.Name = name;
            request.Description = description;
            createChapter.Execute(request);

            _lastSavedChapter.Name.Should().Be(name);
            _lastSavedChapter.Description.Should().Be(description);
        }

        [TestCase("z")]
        [TestCase("e")]
        public void CanRespondWithTheId(string id)
        {
            _id = id;
            var createChapter = new CreateChapter(this);
            dynamic request = new ExpandoObject();
            request.Name = "Unused";
            request.Description = "Unused";
            dynamic response = createChapter.Execute(request);
            ((string) response.Id).Should().Be(id);
        }
    }
}