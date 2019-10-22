using System;
using System.Collections.Generic;
using Chapter.Port;

namespace Chapter.AcceptanceTests
{
    class InMemoryChapter : ChapterGateway
    {
        private List<Domain.Chapter> _chapters;

        public InMemoryChapter()
        {
            _chapters = new List<Domain.Chapter>();
        }

        public Domain.Chapter One(string id)
        {
            var chapter = _chapters[Int32.Parse(id)];
            chapter.Id = id;
            return chapter;
        }

        public string Save(Domain.Chapter chapter)
        {
            _chapters.Add(chapter);
            return (_chapters.Count - 1).ToString();
        }
    }
}