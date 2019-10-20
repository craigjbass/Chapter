using System.Dynamic;
using Chapter.Port;
using Chapter.UseCase;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.Core.Tests.UseCase
{
    public class CreateChapterTests : ChapterWriter
    {
        private Domain.Chapter _lastSavedChapter;
        private string _id;
        public string Save(Domain.Chapter chapter)
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