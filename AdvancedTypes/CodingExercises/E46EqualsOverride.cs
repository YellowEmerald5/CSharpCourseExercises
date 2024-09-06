using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    public override bool Equals(object? obj)
    {
        return obj is FullName other && First == other.First && Last == other.Last;
    }
}
