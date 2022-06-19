using Xunit;
using GraphChecker.Checkers;

namespace GraphCheckerTests
{
    public class InvalidGraphTest
    {
        [Fact]
        public void NoChildWithRootTest()
        {
            var fileName = "../../../../GraphChecker/Samples/root_without_child_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_CHILD_NOT_FOUND, actual);
        }

        [Fact]
        public void NoChildWithNormalTest()
        {
            var fileName = "../../../../GraphChecker/Samples/normal_without_child_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_CHILD_NOT_FOUND, actual);
        }

        [Fact]
        public void LeafWithChildTest()
        {
            var fileName = "../../../../GraphChecker/Samples/leaf_with_child_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_LEAF_HAS_CHILD, actual);
        }

        [Fact]
        public void UnknownTypeTest()
        {
            var fileName = "../../../../GraphChecker/Samples/unknown_type_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_UNKNOW_TYPE, actual);
        }

        [Fact]
        public void NoRootTest()
        {
            var fileName = "../../../../GraphChecker/Samples/no_root_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_ROOT_NOT_FOUND, actual);
        }

        [Fact]
        public void MultiRootTest()
        {
            var fileName = "../../../../GraphChecker/Samples/multi_root_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_MULTI_ROOT, actual);
        }

        [Fact]
        public void NullNameTest()
        {
            var fileName = "../../../../GraphChecker/Samples/null_name_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_NULL_NODE_NAME, actual);
        }

        [Fact]
        public void DuplicatedNodeNameTest()
        {
            var fileName = "../../../../GraphChecker/Samples/duplicated_node_names_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_DUP_NODE_NAME, actual);
        }

        [Fact]
        public void NullChildNameTest()
        {
            var fileName = "../../../../GraphChecker/Samples/null_child_name_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_NULL_CHILD_NAME, actual);
        }

        [Fact]
        public void DuplicatedChildNameTest()
        {
            var fileName = "../../../../GraphChecker/Samples/duplicated_child_names_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_DUP_CHILD_NAME, actual);
        }

        [Fact]
        public void IsolatedNormalTest()
        {
            var fileName = "../../../../GraphChecker/Samples/isolated_normal_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_ISOLATED, actual);
        }

        [Fact]
        public void IsolatedLeafTest()
        {
            var fileName = "../../../../GraphChecker/Samples/isolated_leaf_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_ISOLATED, actual);
        }

        [Fact]
        public void LoopPerfectTest()
        {
            var fileName = "../../../../GraphChecker/Samples/loop_perfect_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_LOOP, actual);
        }

        [Fact]
        public void LoopPartial1Test()
        {
            var fileName = "../../../../GraphChecker/Samples/loop_partial_1_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_LOOP, actual);
        }

        [Fact]
        public void LoopPartial2Test()
        {
            var fileName = "../../../../GraphChecker/Samples/loop_partial_2_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_LOOP, actual);
        }

        [Fact]
        public void LoopPartial3Test()
        {
            var fileName = "../../../../GraphChecker/Samples/loop_partial_3_nodes.json";
            var graphChecker = new SRDAGChecker(fileName);
            TreeStatusCodes actual = graphChecker.Run();

            Assert.Equal(TreeStatusCodes.ERR_LOOP, actual);
        }
    }
}