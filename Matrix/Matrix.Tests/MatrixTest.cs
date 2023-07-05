using Xunit;

namespace MatrixTests;

public class MatrixTest
{
  [Theory]
  [InlineData("1,0,1;0,1,0", 3)]
  [InlineData("1,0,1;1,1,0", 2)]
  [InlineData("1,1,1,0;0,1,0,0", 1)]
  public void GetAreaCount_CalculatesCorrectly(string matrix, int expectedCount)
  {
    var actualCount = Matrix.GetAreaCount(matrix);
    Assert.Equal(expectedCount, actualCount);
  }
}