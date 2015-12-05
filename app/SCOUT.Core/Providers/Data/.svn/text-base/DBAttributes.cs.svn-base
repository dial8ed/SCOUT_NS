using System;

namespace SCOUT.Core.Data
{
    public abstract class DBAttribute : Attribute
    {
        public DBAttribute()
        {
        }

        public virtual string ConfigVal { get { return "DB:SCOUT"; } }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SecurityDB : DBAttribute
    {
        public SecurityDB()
        {
        }

        public override string ConfigVal { get { return "DB:Security"; } }
    }

    [AttributeUsage(AttributeTargets.Property)]
    sealed class ColumnAttribute : Attribute
    {
        private readonly string m_columnName;

        public ColumnAttribute(string ColumnName)
        {
            m_columnName = ColumnName;
        }

        public string ColumnName { get { return m_columnName; } }
    }

    [AttributeUsage(AttributeTargets.Class)]
    sealed class TableAttribute : Attribute
    {
        private readonly string m_table;

        public TableAttribute(string table)
        {
            m_table = table;
        }

        public string Table { get { return m_table; } }
    }
}
