using System;
using System.Collections.Generic;

namespace Poke.API.Models
{
    public class PokemonListWithLimit : IComparable<PokemonListWithLimit>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Result> results { get; set; }

        public int CompareTo(PokemonListWithLimit other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var countComparison = count.CompareTo(other.count);
            if (countComparison != 0) return countComparison;

            var nextComparison = string.Compare(next, other.next, StringComparison.Ordinal);
            if (nextComparison != 0) return nextComparison;

            return string.Compare(previous, other.previous, StringComparison.Ordinal);
        }
    }

    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}