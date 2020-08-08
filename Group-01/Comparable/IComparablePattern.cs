namespace Comparable
{
    public interface IComparablePattern<T>
    {
        bool sosIgual(T comparable);
        bool sosMenor(T comparable);
        bool sosMayor(T comparable);
    }
}
