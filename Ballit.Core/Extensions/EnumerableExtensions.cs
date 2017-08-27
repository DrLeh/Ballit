﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballit.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
