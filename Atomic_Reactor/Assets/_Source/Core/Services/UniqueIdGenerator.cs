using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public static class UniqueIdGenerator
    {
        private static readonly List<int> _allIds = new();

        public static int GenerateId()
        {
            int generated;

            do
            {
                generated = Random.Range(int.MinValue, int.MaxValue);
            } while (_allIds.Contains(generated));

            _allIds.Add(generated);
            return generated;
        }
    }
}