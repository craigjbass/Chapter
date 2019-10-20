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
                return _chapters[int.Parse(id)];
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
            
            var createResponse = createChapter.Execute(createRequest);
            
            var viewChapter = new ViewChapter(chapterGateway);

            dynamic viewRequest = new ExpandoObject();
            viewRequest.Id = createResponse.Id;

            dynamic viewResponse = viewChapter.Execute(viewRequest);

            ((string) viewResponse.Name).Should().Be("A warm hello");
        }
    }
}