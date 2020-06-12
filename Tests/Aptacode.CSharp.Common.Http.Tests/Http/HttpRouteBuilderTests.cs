using System.Collections.Generic;
using Aptacode.CSharp.Common.Http.Models;
using Aptacode.CSharp.Common.Http.Services;
using Aptacode.CSharp.Common.Http.Tests.Http.TestData;
using Xunit;

namespace Aptacode.CSharp.Common.Http.Tests.Http
{
    public class HttpRouteBuilderTests
    {
        [Theory]
        [ClassData(typeof(HttpRouteBuilderBuildRouteTestData))]
        public void BuildRouteTests(ServerAddress serverAddress, object[] baseComponents, object[] extraComponents,
            string expectedAddress)
        {
            var sut = new HttpRouteProvider(serverAddress, baseComponents);
            Assert.Equal(expectedAddress, sut.Build(extraComponents));
        }

        [Theory]
        [ClassData(typeof(HttpRouteBuilderToStringTestData))]
        public void ToStringTests(ServerAddress serverAddress, object[] baseComponents, string expectedAddress)
        {
            var sut = new HttpRouteProvider(serverAddress, baseComponents);
            Assert.Equal(expectedAddress, sut.ToString());
        }

        [Theory]
        [ClassData(typeof(HttpRouteBuilderAppendTestData))]
        public void AppendTests(ServerAddress serverAddress, object[] baseComponents, List<object[]> components,
            string expectedAddress)
        {
            var sut = new HttpRouteProvider(serverAddress, baseComponents);

            foreach (var component in components)
            {
                sut.Append(component);
            }

            Assert.Equal(expectedAddress, sut.ToString());
        }
    }
}