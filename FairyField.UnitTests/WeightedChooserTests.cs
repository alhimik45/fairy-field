using FluentAssertions;
using NUnit.Framework;

namespace FairyField.UnitTests
{
    [TestFixture]
    public class WeightedChooserTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(6, 3)]
        [TestCase(8, 5)]
        [TestCase(14, 1)]
        [TestCase(24, 5)]
        public void WeightedChooser_GetByOffsetReturnsCorrectElement(int n, int expected)
        {
            var chooser = new WeightedChooser<int>(new[]
            {
                (1, 1),
                (2, 2),
                (3, 4),
                (5, 6)
            });
            chooser.GetByOffset(n).Should().Be(expected);
        }
    }
}