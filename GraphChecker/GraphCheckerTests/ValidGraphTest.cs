using Xunit;
using GraphChecker.Checkers;

namespace GraphCheckerTests
{
    public class ValidGraphTest
    {
        [Fact]
        public void NormalTest()
        {
            var fileName = "../../../../GraphChecker/Samples/valid_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.OK, actual);
        }

        [Fact]
        public void RhombusTest()
        {
            var fileName = "../../../../GraphChecker/Samples/rhombus_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.OK, actual);
        }

        [Fact]
        public void MinimumTest()
        {
            var fileName = "../../../../GraphChecker/Samples/minimum_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.OK, actual);
        }
    }
}