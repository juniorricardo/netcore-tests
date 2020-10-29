namespace Comparable
{
    public interface IComparablePattern<T> where T: class
    {
        bool sosIgual(T comparable);
        bool sosMenor(T comparable);
        bool sosMayor(T comparable);
    }
}
