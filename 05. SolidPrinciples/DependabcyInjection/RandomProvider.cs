using DependencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class RandomProvider : IRandomProvider
    {
        private static readonly Random Random = new Random();

        public int Number(int min, int max)
            => Random.Next(min, max + 1);
    }
}
