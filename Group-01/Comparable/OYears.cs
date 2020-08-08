namespace Comparable
{
    public class OYears : IComparablePattern<OYears>
    {
        private readonly int year;

        public OYears(int year) => this.year = year;
        public OYears() { }


        public bool sosIgual(OYears inYear) => year == inYear.year;

        public bool sosMenor(OYears inYear) => year < inYear.year;

        public bool sosMayor(OYears inYear) => year > inYear.year;

    }
}
