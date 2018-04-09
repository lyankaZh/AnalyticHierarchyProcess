using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarhyTest.Helpers
{
  public static class Extensions
  {
    public static IEnumerable<double> Normalize(this IEnumerable<double> collection)
    {
      var sum = collection.Sum();
      return collection.Select(x => x / sum);
    }
  }
}
