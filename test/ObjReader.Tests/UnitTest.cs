using Xunit;

namespace Reality.ObjReader.Tests
{
    public class ReaderTests
    {
        const string filename = @"/Users/danielwalsh/git/github.com/dangwalsh/ObjReader/data/test.obj";

        [Fact]
        public void GetNodes()
        {
            var count = Facade.ImportObjects(filename);
            Assert.Equal(2, count);
        }

        [Fact]
        public void GetVertices()
        {
            var count = Facade.ImportObjects(filename);
            var verts = Facade.GetVertices();
            Assert.Equal(96, verts.Length);
        }

        [Fact]
        public void GetUVs()
        {
            var count = Facade.ImportObjects(filename);
            var uvs = Facade.GetUVs();
            Assert.Equal(96, uvs.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetVertexIndexOfObject(int index)
        {
            var count = Facade.ImportObjects(filename);
            var inds = Facade.GetVertexIndexOfObject(index);
            Assert.Equal(36, inds.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetNormalIndexOfObject(int index)
        {
            var count = Facade.ImportObjects(filename);
            var inds = Facade.GetNormalIndexOfObject(index);
            Assert.Equal(36, inds.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetUVIndexOfObject(int index)
        {
            var count = Facade.ImportObjects(filename);
            var inds = Facade.GetUVIndexOfObject(index);
            Assert.Equal(36, inds.Length);
        }

        [Theory]
        [InlineData(0)]
        public void GetDiffuseColorOfObject(int index)
        {
            var count = Facade.ImportObjects(filename);
            var color = Facade.GetKdOfObject(index);
            Assert.Equal(0.5, color[0]);
        }
    }
}
