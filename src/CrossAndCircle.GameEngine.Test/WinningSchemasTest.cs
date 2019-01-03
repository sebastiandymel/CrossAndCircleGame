using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrossAndCircle.GameEngine.Test
{
    [TestClass]
    public class WinningSchemasTest
    {
        [TestMethod]
        public void Winners()
        {
            var schemas = new WinningSchemas(3);
            Assert.IsTrue(schemas.Contains(new[] { 0, 1, 2 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 3, 4, 5 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 6, 7, 8 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 0, 4, 8 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 6, 4, 2 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 2, 1, 0 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 5, 4, 3 }, out var _));
            Assert.IsTrue(schemas.Contains(new[] { 0, 1, 2, 3, 4, 5, 6 }, out var _));
        }

        [TestMethod]
        public void Losers()
        {
            var schemas = new WinningSchemas(3);
            Assert.IsFalse(schemas.Contains(new[] { 0, 5, 2 }, out var _));
            Assert.IsFalse(schemas.Contains(new[] { 6, 7, 3 }, out var _));
            Assert.IsFalse(schemas.Contains(new[] { 2, 1, 8 }, out var _));
        }
    }
}
