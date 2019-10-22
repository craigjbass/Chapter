using Chapter.UseCase;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter.AcceptanceTests
{
    public class ChapterTests
    {
        private InMemoryChapter _chapterGateway;
        private CreateChapter _createChapter;
        private ViewChapter _viewChapter;

        private dynamic ViewChapter(object request) => _viewChapter.Execute(request.ToDynamic());
        private dynamic CreateChapter(object request) => _createChapter.Execute(request.ToDynamic());

        [SetUp]
        public void SetUp()
        {
            _chapterGateway = new InMemoryChapter();
            _createChapter = new CreateChapter(_chapterGateway);
            _viewChapter = new ViewChapter(_chapterGateway);
        }

        [Test]
        public void CanViewAChapter()
        {
            var createResponse = CreateChapter(new
            {
                Name = "A warm hello",
                Description = "Really nice people to hang out with..."
            });

            var viewResponse = ViewChapter(new
            {
                createResponse.Id
            });

            ((string) viewResponse.Id).Should().Be(createResponse.Id);
            ((string) viewResponse.Name).Should().Be("A warm hello");
            ((string) viewResponse.Description).Should().Be("Really nice people to hang out with...");
        }
    }
}