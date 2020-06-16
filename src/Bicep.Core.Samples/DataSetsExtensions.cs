﻿using System.Collections.Generic;
using System.Linq;

namespace Bicep.Core.Samples
{
    public static class DataSetsExtensions
    {
        public static IEnumerable<object[]> ToDynamicTestData(this IEnumerable<DataSet> source)
        {
            return source.Select(ds => new object[] {ds});
        }
    }
}