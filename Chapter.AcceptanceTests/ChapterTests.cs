using System.Collections.Generic;
using System.Dynamic;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.AcceptanceTests
{
    public class ChapterTests
    {
        class InMemoryChapter : ChapterGateway
        {
            private List<Chapter> _chapters;

            public InMemoryChapter()
            {
                _chapters = new List<Chapter>();
            }

            public Chapter One(string id)
            {
                var chapter = _chapters[int.Parse(id)];
                chapter.Id = id;
                return chapter;
            }

            public string Save(Chapter chapter)
            {
                _chapters.Add(chapter);
                return (_chapters.Count - 1).ToString();
            }
        }

        [Test]
        public void CanViewAChapter()
        {
            var chapterGateway = new InMemoryChapter();
            
            var createChapter = new CreateChapter(chapterGateway);

            dynamic createRequest = new ExpandoObject();
            createRequest.Name = "A warm hello";
            createRequest.Description = "Really nice people to hang out with...";
            
            var createResponse = createChapter.Execute(createRequest);
            
            var viewChapter = new ViewChapter(chapterGateway);

            dynamic viewRequest = new ExpandoObject();
            viewRequest.Id = createResponse.Id;

            dynamic viewResponse = viewChapter.Execute(viewRequest);

            ((string) viewResponse.Id).Should().Be(createResponse.Id);
            ((string) viewResponse.Name).Should().Be("A warm hello");
            ((string) viewResponse.Description).Should().Be("Really nice people to hang out with...");
        }
    }
}