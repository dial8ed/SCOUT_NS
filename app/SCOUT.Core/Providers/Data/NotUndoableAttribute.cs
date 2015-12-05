using System;
using System.Collections.Generic;
using System.Text;

namespace SCOUT.Core.Data
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class NotUndoableAttribute : Attribute
    {
    }
}
