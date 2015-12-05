using System;

namespace SCOUT.Core.Data
{
    public static class Strings
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">comma delimited list of strings</param>
        /// <param name="search">string value to search for</param>
        /// <returns></returns>
        public static bool DelimitedListContains(this string list, string search)
        {
            try
            {
                string[] searchList = list.Split(char.Parse(","));
                foreach (string s in searchList)
                {
                    if(s.Equals(search))
                        return true;
                }               
            } 
            catch(Exception e)
            {
                throw new InvalidOperationException(
                    string.Format("Error processing [{0}] as a comma delimited list",list));                  
            }

            return false;
        }


        public static string WrapInDoubleQuotes(string statementToWrap)
        {
            string doubleQuote = @"""";

            return string.Format("{0}{1}{2}", doubleQuote, statementToWrap,
                                 doubleQuote);
        }

    }
}