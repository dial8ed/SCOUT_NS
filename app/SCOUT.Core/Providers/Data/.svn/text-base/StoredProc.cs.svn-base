using System.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Query object that wraps around a stored proc.
    /// </summary>
    public class StoredProc : Query
    {
        private readonly string m_name;
        private ProcType m_type = ProcType.Select;

        /// <summary>
        /// Constructs a query object.
        /// </summary>
        /// <param name="Name">Name of the stored proc.</param>
        public StoredProc(string Name)
        {
            m_name = Name;
        }

        /// <summary>
        /// Constructs a query object.
        /// </summary>
        /// <param name="Name">Name of the stored proc.</param>
        /// <param name="type">Type of stored proc.</param>
        public StoredProc(string Name, ProcType type)
        {
            m_name = Name;
            m_type = type;
        }

        protected override CommandType CommandType
        {
            get { return CommandType.StoredProcedure; }
        }

        protected override IsolationLevel IsolationLevel
        {
            get 
            {
                IsolationLevel rval = IsolationLevel.ReadCommitted;

                if ((m_type == ProcType.Insert) ||
                    (m_type == ProcType.Delete) ||
                    (m_type == ProcType.Update)
                   )
                {
                    rval = IsolationLevel.Serializable;
                }

                return rval;
            }
        }

        /// <summary>
        /// The stored proc type.  See 
        /// <see cref="ProcType"/> enum for types.
        /// </summary>
        public ProcType Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public override string ToString()
        {
            return m_name;
        }
    }

    /// <summary>
    /// Stored proc types.
    /// </summary>
    public enum ProcType
    {
        Select,
        Insert,
        Update,
        Delete
    }
}
