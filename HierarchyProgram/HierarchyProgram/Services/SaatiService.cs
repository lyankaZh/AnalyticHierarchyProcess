using HierarhyTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HierarhyTest.Services
{
  public class SaatiService
  {
    public IList<double> GetLList(Matrix matrix)
    {
      List<double> L = new List<double>();
      for (int i = 0; i < matrix.Size; i++)
      {
        L.Add(GetEigenValue(matrix.GetMatrixColumn(i)));
      }

      return L;
    }

    public double GetEigenValue(IList<double> values)
    {
      var product = values.Aggregate((a, b) => a * b);
      return Math.Pow(product, 1.0 / values.Count);
    }

    public int DetermineTheBestAlternative(Matrix criterias, IList<Matrix> alternatives, int alternativesCount)
    {
      List<double> mainL = GetLList(criterias).Normalize().ToList();

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
  }
}
