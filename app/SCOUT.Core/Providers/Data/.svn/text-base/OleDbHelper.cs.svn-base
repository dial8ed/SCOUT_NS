using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Wraps a method that creates a OleDbConnection from a file.
    /// </summary>
    /// <param name="fileInfo"></param>
    /// <returns></returns>
    public delegate OleDbConnection CreateOleDbConnectionDelegate(
        FileInfo fileInfo);

    public class OleDbHelper 
    {

        public static T FillDataSet<T>(ref T dataSet, string tableName, OleDbConnection connection, string commandText) 
            where T : DataSet
        {
            OleDbCommand command = new OleDbCommand(commandText, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            using (connection)
            {
                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, tableName);
                    return dataSet;
                }
                catch (OleDbException ex)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                    return null;
                }                
            }            
        }
    }       
}