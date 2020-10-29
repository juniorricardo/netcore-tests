using Comparable;
using FluentAssertions;
using Xunit;

namespace Pattern.Test
{

    public class OYearsShould
    {
        //Arrange //Act //Assert
        [Theory]
        [InlineData(2650, 2651)]
        public void SosMenor_Return_true(int yearSUT, int yearOther)
        {
            OYears sut = new OYears(yearSUT);
            OYears nYear = new OYears(yearOther);

            bool isTrue = sut.sosMenor(nYear);

            isTrue.Should().BeTrue();
        }

        [Fact]
        public void SosMenor_Return_false()
        {
            OYears sut = new OYears(15);
            OYears nYear = new OYears(8);

            bool isTrue = sut.sosMenor(nYear);

            isTrue.Should().BeFalse();
        }
        
        [Fact]
        public void SosIgual_Return_true()
        {
            OYears sut = new OYears(2);
            OYears nYear = new OYears(2);

            bool isTrue = sut.sosIgual(nYear);

            isTrue.Should().BeTrue();
        }

        [Fact]
        public void SosIgual_Return_false()
        {
            OYears sut = new OYears(0);
            OYears nYear = new OYears(1);

            bool isTrue = sut.sosIgual(nYear);

            isTrue.Should().BeFalse();
        }

        [Fact]
        public void SosMayor_Return_true()
        {
            OYears sut = new OYears(9);
            OYears nYear = new OYears(3);

            bool isTrue = sut.sosMayor(nYear);

            isTrue.Should().BeTrue();
        }

        [Fact]
        public void SosMayor_Return_false()
        {
            OYears sut = new OYears(5);
            OYears nYear = new OYears(8);

            bool isTrue = sut.sosMayor(nYear);

            isTrue.Should().BeFalse();
        }
    }
}

