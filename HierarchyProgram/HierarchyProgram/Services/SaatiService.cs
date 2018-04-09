using System;
using System.Collections.Generic;
using System.Linq;
using HierarchyProgram.Helpers;

namespace HierarchyProgram.Services
{
    public class SaatiService : ISaatiService
    {
        public const int MAX_ETALON_KEY = 13;
        private static Dictionary<double, double> EtalonValues = new Dictionary<double, double>()
    {
      {3, 0.58 },
      {4, 0.9 },
      {5,1.12 },
      { 6, 1.24},
      { 7,1.32},
      { 8,1.41},
      { 9,1.45},
      { 10,1.49},
      { 11,1.51},
      { 12,1.54},
      { 13,1.56}
    };


        private IList<double> GetLList(Matrix matrix)
        {
            List<double> L = new List<double>();
            for (int i = 0; i < matrix.Size; i++)
            {
                L.Add(GetEigenValue(matrix.GetMatrixColumn(i)));
            }

            return L;
        }

        private double GetEigenValue(IList<double> values)
        {
            var product = values.Aggregate((a, b) => a * b);
            return Math.Pow(product, 1.0 / values.Count);
        }

        public int DetermineTheBestAlternative(Matrix criterias, IList<Matrix> alternatives, int alternativesCount)
        {
            List<double> mainL = GetLList(criterias).Normalize().ToList();
            var consistencyIndex = GetConsistencyIndex(criterias, mainL.AsEnumerable().Reverse());

            var dictionary = new Dictionary<int, List<double>>();
            for (int i = 0; i < alternativesCount; i++)
            {
                dictionary[i] = new List<double>();
            }

            foreach (var alternative in alternatives)
            {
                var a = GetLList(alternative).Normalize().ToList();
                for (int i = 0; i < alternativesCount; i++)
                {
                    dictionary[i].Add(a[i]);
                }
            }

            var sums = new List<double>();

            for (int i = 0; i < alternativesCount; i++)
            {
                sums.Add(mainL.Zip(dictionary[i], (a, b) => a * b).Sum());
            }

            return sums.IndexOf(sums.Max());
        }

        public double GetConsistencyIndex(Matrix matrix, IEnumerable<double> vector)
        {
            int count = vector.Count();
            if (count > MAX_ETALON_KEY)
            {
                throw new ArgumentException("Could not calculate consistency index");
            }

            var product = matrix.MultipleOnVector(vector.ToList());
            double lambdaMax = product.Sum();
            double index = (lambdaMax - count) / (count - 1);
            return index / EtalonValues[count];
        }
    }
}
