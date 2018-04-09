using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HierarchyProgram.Helpers;

namespace HierarchyProgram.Services
{
    interface ISaatiService
    {
        int DetermineTheBestAlternative(Matrix criterias, IList<Matrix> alternatives, int alternativesCount);
    }
}
