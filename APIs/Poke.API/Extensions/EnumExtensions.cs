#nullable enable
using System.Collections.Generic;
using System.Linq;
using Poke.API.Models;

namespace Poke.API.Extensions
{
    public static class EnumExtensions
    {
        public static List<PokemonValue> GetValues<T>()
        {
            return (from object? itemType in System.Enum.GetValues(typeof(T))
                select new PokemonValue
                {
                    Name = System.Enum.GetName(typeof(T), itemType),
                    Value = (int) itemType
                }).ToList();
        }

        public static List<T> GetEnumList<T>()
        {
            var array = (T[]) System.Enum.GetValues(typeof(T));
            var list = new List<T>(array);
            return list;
        }
    }
}