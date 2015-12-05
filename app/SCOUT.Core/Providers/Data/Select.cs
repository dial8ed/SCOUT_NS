using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SCOUT.Core.Data
{
    public class Select : Query
    {
        #region Member Variables

        private bool m_dist = false;

        private readonly string[] m_cols = null;

        // Tables & Joins
        private string m_from = "";

        // Whole Query Conditions
        private readonly List<ConditionalItem> m_where = new List<ConditionalItem>();
        private readonly List<ConditionalItem> m_having = new List<ConditionalItem>();

        // Grouping and Ordering
        private string[] m_groupBy = null;
        private string[] m_orderBy = null;

        #endregion

        #region Constructors

        public Select()
        {
            m_cols = null;
        }

        public Select(params string[] cols)
        {
            m_cols = cols;
        }

        #endregion

        #region Utility

        private void ValidateState()
        {
            if (m_from.Trim() == "")
                throw new Exception("No table specified.");
        }

        #endregion

        #region Query Building

        public Select Distinct()
        {
            m_dist = true;
            return this;
        }

        #region Tables and Joins

        public Select From(string table)
        {
            m_from = table;
            return this;
        }

        #endregion

        #region Whole Query Conditions

        public Select Where(string where)
        {
            ConditionalItem ci = new ConditionalItem(where);
            m_where.Add(ci);
            return this;
        }

        public Select AndWhere(string where)
        {
            ConditionalItem ci = 
                new ConditionalItem(ConditionOperation.And, where);
            m_where.Add(ci);
            return this;
        }

        public Select OrWhere(string where)
        {
            ConditionalItem ci = 
                new ConditionalItem(ConditionOperation.Or, where);
            m_where.Add(ci);
            return this;
        }

        public Select Having(string having)
        {
            ConditionalItem ci = new ConditionalItem(having);
            m_having.Add(ci);
            return this;
        }

        public Select AndHaving(string having)
        {
            ConditionalItem ci = 
                new ConditionalItem(ConditionOperation.And, having);
            m_having.Add(ci);
            return this;
        }

        public Select OrHaving(string having)
        {
            ConditionalItem ci = 
                new ConditionalItem(ConditionOperation.Or, having);
            m_having.Add(ci);
            return this;
        }

        #endregion

        #region Grouping and Ordering

        public Select OrderBy(params string[] cols)
        {
            m_orderBy = cols;
            return this;
        }

        public Select GroupBy(params string[] cols)
        {
            m_groupBy = cols;
            return this;
        }

        #endregion

        #endregion

        #region Query Overrides

        protected override CommandType CommandType
        {
            get { return CommandType.Text; }
        }

        protected override IsolationLevel IsolationLevel
        {
            get { return IsolationLevel.ReadCommitted; }
        }

        #endregion

        #region ToString

        private static string GetJoinedArray(string[] array, string seperator)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; ++i)
            {
                sb.Append(array[i]);

                if (i < (array.Length - 1))
                    sb.Append(seperator);
            }

            return sb.ToString();
        }

        private string GetColsList()
        {
            if (m_cols == null)
                return "* ";

            return GetJoinedArray(m_cols, ", ") + " ";
        }

        private string GetOrderBy()
        {
            if (m_orderBy == null)
                return "";

            StringBuilder sb = new StringBuilder();

            sb.Append("ORDER BY ");
            sb.Append(GetJoinedArray(m_orderBy, ", "));
            sb.Append(" ");

            return sb.ToString();
        }

        private string GetGroupBy()
        {
            if (m_groupBy == null)
                return "";

            StringBuilder sb = new StringBuilder();

            sb.Append("GROUP BY ");
            sb.Append(GetJoinedArray(m_groupBy, ", "));
            sb.Append(" ");

            return sb.ToString();
        }

        private string GetWhere()
        {
            if (m_where.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            sb.Append("WHERE ");

            foreach (ConditionalItem wi in m_where)
                sb.Append(wi.ToString());

            sb.Append(" ");

            return sb.ToString();
        }

        private string GetHaving()
        {
            if (m_having.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            sb.Append("HAVING ");

            foreach (ConditionalItem wi in m_having)
                sb.Append(wi.ToString());

            sb.Append(" ");

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder rval = new StringBuilder();

            ValidateState();

            rval.Append("SELECT ");

            if (m_dist)
                rval.Append("DISTINCT ");

            rval.Append(GetColsList());

            rval.Append("FROM ");
            rval.Append(m_from);
            rval.Append(" ");

            rval.Append(GetWhere());
            rval.Append(GetHaving());

            rval.Append(GetGroupBy());
            rval.Append(GetOrderBy());

            return rval.ToString();
        }

        #endregion
    }

    /// <summary>
    /// Holds details about a conditional item.
    /// </summary>
    class ConditionalItem
    {
        private readonly ConditionOperation m_operation =
            ConditionOperation.First;
        private readonly string m_condition;

        #region Constructors

        public ConditionalItem(string condition)
        {
            m_condition = condition;
        }

        public ConditionalItem(
            ConditionOperation operation, 
            string condition)
        {
            m_operation = operation;
            m_condition = condition;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            switch (m_operation)
            {
            case ConditionOperation.And:
                sb.Append(@"AND ");
                break;

            case ConditionOperation.Or:
                sb.Append(@"OR ");
                break;

            case ConditionOperation.First:
            default:
                break;
            }

            sb.Append(m_condition);
            sb.Append(@" ");

            return sb.ToString();
        }
    }

    enum ConditionOperation
    {
        First = 0,
        And = 1,
        Or = 2
    }
}
