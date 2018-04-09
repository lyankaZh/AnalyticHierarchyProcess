using System.Collections.Generic;
using System.Linq;

namespace HierarchyProgram.Helpers
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
