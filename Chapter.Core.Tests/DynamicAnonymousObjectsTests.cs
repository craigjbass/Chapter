using FluentAssertions;
using NUnit.Framework;

namespace Chapter.Core.Tests
{
    public class DynamicAnonymousObjectsTests
    {
        [Test]
        public void CanAccessDynamicObjects()
        {
            dynamic dynamic = new
            {
                A = 123,
                B = "String",
                C = new
                {
                    Z = 987
                }
            }.ToDynamic();

            ((int) dynamic.A).Should().Be(123);
            ((string) dynamic.B).Should().Be("String");
            ((int) dynamic.C.Z).Should().Be(987);
        }
        
        [Test]
        public void NestedAnonymousObjectsAreConvertedToExpando()
        {
            dynamic dynamic = new
            {
                C = new
                {
                    Z = 987
                }
            }.ToDynamic();

            dynamic.C.J = "hello";
            
            ((string) dynamic.C.J).Should().Be("hello");
        }
    }
}