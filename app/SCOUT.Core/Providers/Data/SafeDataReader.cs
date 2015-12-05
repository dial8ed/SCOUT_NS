using System;
using System.Data;

/// <summary> 
/// 
/// </summary> 
namespace SCOUT.Core.Data
{

    /// <summary> 
    /// This is a DataReader that 'fixes' any null values before 
    /// they are returned to our business code. 
    /// </summary> 
    public class SafeDataReader : IDataReader
    {


        protected IDataReader mDataReader;

        /// <summary> 
        /// Initializes the SafeDataReader object to use data from 
        /// the provided DataReader object. 
        /// </summary> 
        /// <param name="DataReader">The source DataReader object containing the data.</param> 
        public SafeDataReader(IDataReader DataReader)
        {
            mDataReader = DataReader;
        }

        /// <summary> 
        /// Gets a string value from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns empty string for null. 
        /// </remarks> 
         public string GetString(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return "";
            }
            else
            {
                return mDataReader.GetString(i);
            }
        }

        /// <summary> 
        /// Gets a string value from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns "" for null. 
        /// </remarks> 
        public string GetString(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetString(index);
        }

        /// <summary> 
        /// Gets a value of type <see cref="System.Object" /> from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns Nothing for null. 
        /// </remarks> 
        public object GetValue(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return null;
            }
            else
            {
                return mDataReader.GetValue(i);
            }
        }

        /// <summary> 
        /// Gets a value of type <see cref="System.Object" /> from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns Nothing for null. 
        /// </remarks> 
        public object GetValue(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetValue(index);
        }

        /// <summary> 
        /// Gets an integer from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns 0 for null. 
        /// </remarks> 
        public int GetInt32(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetInt32(i);
            }
        }

        /// <summary> 
        /// Gets an integer from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns 0 for null. 
        /// </remarks> 
        public int GetInt32(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetInt32(index);
        }

        /// <summary> 
        /// Gets a double from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns 0 for null. 
        /// </remarks> 
        public double GetDouble(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetDouble(i);
            }
        }

        /// <summary> 
        /// Gets a double from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns 0 for null. 
        /// </remarks> 
        public double GetDouble(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetDouble(index);
        }

        /// <summary> 
        /// Gets a Guid value from the datareader. 
        /// </summary> 
        public Guid GetGuid(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return Guid.Empty;
            }
            else
            {
                return mDataReader.GetGuid(i);
            }
        }

        /// <summary> 
        /// Gets a Guid value from the datareader. 
        /// </summary> 
        public Guid GetGuid(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetGuid(index);
        }

        /// <summary> 
        /// Reads the next row of data from the datareader. 
        /// </summary> 
        public bool Read()
        {
            return mDataReader.Read();
        }

        /// <summary> 
        /// Moves to the next result set in the datareader. 
        /// </summary> 
        public bool NextResult()
        {
            return mDataReader.NextResult();
        }

        /// <summary> 
        /// Closes the datareader. 
        /// </summary> 
        public void Close()
        {
            mDataReader.Close();
        }

        /// <summary> 
        /// Returns the depth property value from the datareader. 
        /// </summary> 
        public int Depth
        {
            get { return mDataReader.Depth; }
        }

        /// <summary> 
        /// Calls the Dispose method on the underlying datareader. 
        /// </summary> 
        public void Dispose()
        {
            mDataReader.Dispose();
        }

        /// <summary> 
        /// Returns the FieldCount property from the datareader. 
        /// </summary> 
        public int FieldCount
        {
            get { return mDataReader.FieldCount; }
        }

        /// <summary> 
        /// Gets a boolean value from the datareader. 
        /// </summary> 
        public bool GetBoolean(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return false;
            }
            else
            {
                return mDataReader.GetBoolean(i);
            }
        }

        /// <summary> 
        /// Gets a boolean value from the datareader. 
        /// </summary> 
        public bool GetBoolean(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetBoolean(index);
        }

        /// <summary> 
        /// Gets a byte value from the datareader. 
        /// </summary> 
        public byte GetByte(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetByte(i);
            }
        }

        /// <summary> 
        /// Gets a byte value from the datareader. 
        /// </summary> 
        public byte GetByte(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetByte(index);
        }

        /// <summary> 
        /// Invokes the GetBytes method of the underlying datareader. 
        /// </summary> 
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
            }
        }

        /// <summary> 
        /// Invokes the GetBytes method of the underlying datareader. 
        /// </summary> 
        public long GetBytes(string Name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            int index = this.GetOrdinal(Name);
            return this.GetBytes(index, fieldOffset, buffer, bufferoffset, length);
        }

        /// <summary> 
        /// Gets a char value from the datareader. 
        /// </summary> 
        public char GetChar(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return char.MinValue;
            }
            else
            {
                char[] myChar = new char[0];
                mDataReader.GetChars(i, 0, myChar, 0, 1);
                return myChar[0];
            }
        }

        /// <summary> 
        /// Gets a char value from the datareader. 
        /// </summary> 
        public char GetChar(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetChar(index);
        }

        /// <summary> 
        /// Invokes the GetChars method of the underlying datareader. 
        /// </summary> 
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
            }
        }

        /// <summary> 
        /// Invokes the GetChars method of the underlying datareader. 
        /// </summary> 
        public long GetChars(string Name, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            int index = this.GetOrdinal(Name);
            return this.GetChars(index, fieldoffset, buffer, bufferoffset, length);
        }

        /// <summary> 
        /// Invokes the GetData method of the underlying datareader. 
        /// </summary> 
        public System.Data.IDataReader GetData(int i)
        {
            return mDataReader.GetData(i);
        }

        /// <summary> 
        /// Invokes the GetData method of the underlying datareader. 
        /// </summary> 
        public System.Data.IDataReader GetData(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetData(index);
        }

        /// <summary> 
        /// Invokes the GetDataTypeName method of the underlying datareader. 
        /// </summary> 
        public string GetDataTypeName(int i)
        {
            return mDataReader.GetDataTypeName(i);
        }

        /// <summary> 
        /// Invokes the GetDataTypeName method of the underlying datareader. 
        /// </summary> 
        public string GetDataTypeName(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetDataTypeName(index);
        }

        /// <summary> 
        /// Gets a date value from the datareader. 
        /// </summary> 
        public DateTime GetDateTime(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return System.DateTime.MinValue;
            }
            else
            {
                return mDataReader.GetDateTime(i);
            }
        }

        /// <summary> 
        /// Gets a date value from the datareader. 
        /// </summary> 
        public System.DateTime GetDateTime(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetDateTime(index);
        }

        /// <summary> 
        /// Gets a decimal value from the datareader. 
        /// </summary> 
        public decimal GetDecimal(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetDecimal(i);
            }
        }

        /// <summary> 
        /// Gets a decimal value from the datareader. 
        /// </summary> 
        public decimal GetDecimal(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetDecimal(index);
        }

        /// <summary> 
        /// Invokes the GetFieldType method of the underlying datareader. 
        /// </summary> 
        public System.Type GetFieldType(int i)
        {
            return mDataReader.GetFieldType(i);
        }

        /// <summary> 
        /// Invokes the GetFieldType method of the underlying datareader. 
        /// </summary> 
        public System.Type GetFieldType(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetFieldType(index);
        }

        /// <summary> 
        /// Gets a Single value from the datareader. 
        /// </summary> 
        public float GetFloat(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetFloat(i);
            }
        }

        /// <summary> 
        /// Gets a Single value from the datareader. 
        /// </summary> 
        public float GetFloat(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetFloat(index);
        }

        /// <summary> 
        /// Gets a Short value from the datareader. 
        /// </summary> 
        public short GetInt16(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetInt16(i);
            }
        }

        /// <summary> 
        /// Gets a Short value from the datareader. 
        /// </summary> 
        public short GetInt16(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetInt16(index);
        }

        /// <summary> 
        /// Gets a Long value from the datareader. 
        /// </summary> 
        public long GetInt64(int i)
        {
            if (mDataReader.IsDBNull(i))
            {
                return 0;
            }
            else
            {
                return mDataReader.GetInt64(i);
            }
        }

        /// <summary> 
        /// Gets a Long value from the datareader. 
        /// </summary> 
        public long GetInt64(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.GetInt64(index);
        }

        /// <summary> 
        /// Invokes the GetName method of the underlying datareader. 
        /// </summary> 
        public string GetName(int i)
        {
            return mDataReader.GetName(i);
        }

        /// <summary> 
        /// Gets an ordinal value from the datareader. 
        /// </summary> 
        public int GetOrdinal(string name)
        {
            return mDataReader.GetOrdinal(name);
        }

        /// <summary> 
        /// Invokes the GetSchemaTable method of the underlying datareader. 
        /// </summary> 
        public System.Data.DataTable GetSchemaTable()
        {
            return mDataReader.GetSchemaTable();
        }

        /// <summary> 
        /// Invokes the GetValues method of the underlying datareader. 
        /// </summary> 
        public int GetValues(object[] values)
        {
            return mDataReader.GetValues(values);
        }

        /// <summary> 
        /// Returns the IsClosed property value from the datareader. 
        /// </summary> 
        public bool IsClosed
        {
            get { return mDataReader.IsClosed; }
        }

        /// <summary> 
        /// Invokes the IsDBNull method of the underlying datareader. 
        /// </summary> 
        public bool IsDBNull(int i)
        {
            return mDataReader.IsDBNull(i);
        }

        /// <summary> 
        /// Invokes the IsDBNull method of the underlying datareader. 
        /// </summary> 
        public bool IsDBNull(string Name)
        {
            int index = this.GetOrdinal(Name);
            return this.IsDBNull(index);
        }

        /// <summary> 
        /// Returns a value from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns Nothing if the value is null. 
        /// </remarks> 
        public object this[string name]
        {
            get
            {
                object value = mDataReader[name];
                if (DBNull.Value.Equals(value))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
        }

        /// <summary> 
        /// Returns a value from the datareader. 
        /// </summary> 
        /// <remarks> 
        /// Returns Nothing if the value is null. 
        /// </remarks> 
        public object this[int i]
        {
            get
            {
                if (mDataReader.IsDBNull(i))
                {
                    return null;
                }
                else
                {
                    return mDataReader[i];
                }
            }
        }

        /// <summary> 
        /// Returns the RecordsAffected property value from the underlying datareader. 
        /// </summary> 
        public int RecordsAffected
        {
            get { return mDataReader.RecordsAffected; }
        }
    }

}