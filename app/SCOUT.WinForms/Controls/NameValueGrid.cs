/* ===================================================================== */
/*
 * STS.Controls.NameValueGridcontrol.
 * 
 * Copyright (C) 2006-2007 Streamline Technical Services
 */
/* ===================================================================== */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;

namespace SCOUT.WinForms.Controls
{
    /// <summary>
    /// Converts a string into a name value list that is displayed in the text box.
    /// The values then can be edited and saved back into the input string.
    /// </summary>
    [ToolboxItem(true)]
    public class NameValueGrid : System.Windows.Forms.DataGrid
    {

        #region  Windows designer code 

        // NOTE: The following procedure is required by
        // the windows form Designer
        private System.ComponentModel.Container components = null;
        private void InitializeComponent() 
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #region Local Members

        private TokenBindingObject tbo;

        #endregion

        #region Constructors

        public NameValueGrid()	
        {
            //
            // ctor
            //
            InitializeComponent();

            this.AllowNavigation = false;
            this.AllowDrop = false;
            this.CaptionVisible = false;
            this.ColumnHeadersVisible = false;
            this.ParentRowsVisible = false;
            this.BorderStyle = BorderStyle.None;
            this.Size = new System.Drawing.Size(100, 100);
        }

        #endregion

        #region Helper functions

        public void DisplayProperties(string inputString) 
        {
            // guard
            if (inputString.Length <= 5)
                return;

            this.BuildTableStyles();

            tbo = new TokenBindingObject(inputString);

            this.DataSource = tbo.PropertyCollection;
        }

        private void BuildTableStyles()
        {

            this.TableStyles.Clear();

            DataGridTableStyle dgts;
            dgts = new DataGridTableStyle();
            dgts.RowHeadersVisible = false;

            dgts.MappingName = "PropertyCollection";

            DataGridTextBoxColumn colKey = new DataGridTextBoxColumn();
            colKey.MappingName = "Key";
            colKey.Width = 125;
            colKey.ReadOnly = true;
			
            DataGridTextBoxColumn colValue = new DataGridTextBoxColumn();
            colValue.MappingName = "Value";
            colValue.Width = 200;

            dgts.GridColumnStyles.Add(colKey);
            dgts.GridColumnStyles.Add(colValue);

            this.TableStyles.Add(dgts);
        }

        #endregion

        #region Base Overrides

        public override string ToString()
        {
            String m_TokenString = "";
            String splitter = "";

            if (tbo != null)
            {
                for (int i = 0; i < tbo.PropertyCollection.Count; i++)
                {

                    if ( i > 0 ) 
                    {
                        splitter = "_";
                    }

                    m_TokenString += String.Format(
                        "{0}{1}{2} ",
                        splitter,
                        tbo.PropertyCollection[i].Key.Trim(),
                        tbo.PropertyCollection[i].Value.Trim());

                }

                return m_TokenString;
            }	
            else 
            { 
                return base.ToString();
            }
        }

        #endregion
    }

    /// <summary>
    /// Property Description
    /// </summary>
    public class Property
    {
        private string m_key = "";
        private string m_value = "";

        #region Constructors

        public Property(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        #endregion

        #region Properties
		
        public string Key
        {
            get { return m_key; }
            set 
            {
                if ( m_key != value )
                    m_key = value;
            }
        }

        public string Value
        {
            get { return m_value; }
            set 
            {
                if ( m_value != value )
                {
                    // Remove underscore from value
                    if ( value.IndexOf("_") > -1 ) 
                        value = value.Replace("_"," ");


                    // Remove colon from value
                    if ( value.IndexOf(":") > -1 )
                    {
                        value = value.Replace(":","");
                    }

                    m_value = value.Trim();

                    m_value = value.Trim();

                }
            }
        }

        #endregion
    }

    /// <summary>
    ///  PropertyCollection description
    /// </summary>
    public class PropertyCollection : System.Collections.CollectionBase
    {
        public PropertyCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Property this [int index]
        {
            get { return (Property)this.List[index]; }
        }

        public void Add(Property obj) 
        {
            this.List.Add(obj);
        }

        public void Add(string Key, string Value)
        {
            Property obj = new Property(Key,Value);
            List.Add(obj);
        }

        public void Remove(Property prop)
        {
            this.Remove(prop);
        }
    }

    public class TokenBindingObject
    {
        #region Local members

        private PropertyCollection m_PropertyCollection = null;
        private string m_tokenString = "";
		
        #endregion

        public TokenBindingObject(String inputString)
        {
            m_tokenString = inputString;
        }

        #region Properties

        public  PropertyCollection PropertyCollection 
        {
            get 
            { 
                if ( m_PropertyCollection == null || m_PropertyCollection.Count <= 0 )
                {
                    InitPropertyCollection();
                }

                return m_PropertyCollection;
            }
        }

        #endregion

        #region Helper Functions

        private void InitPropertyCollection()
        {
            m_PropertyCollection = new PropertyCollection();

            char[] splitter = {'_'};

            string[] tokens =	 m_tokenString.Split(splitter);


            foreach ( string s in tokens )
            {


                string tokenKey = s.Substring(0, s.IndexOf(":") + 1 );
                string tokenValue = s.Substring( s.IndexOf(":"),( s.Length - s.IndexOf(":") ) );

                Property prop = new Property(tokenKey,tokenValue);

                m_PropertyCollection.Add(prop);

            }
        }

//		/// <summary>
//		/// Parses input values
//		/// </summary>
//		/// <returns>string[]</returns>
//		private string[] Values(string inputString)
//		{
//			// Parse value values from the input string
//			Regex m_valueRegEx;
//			m_valueRegEx = new Regex(m_valuePattern);
//
//			string[] m_values;
//
//			MatchCollection m_matches;
//			
//			m_matches = m_valueRegEx.Matches(inputString);
//
//			m_values = new string[m_matches.Count];
//
//			for (int i = 0; i < m_matches.Count; i++)
//				m_values[i] = m_matches[i].Value.ToString();
//
//			return m_values;
//		}

//		private string InitializeString(string inputString) 
//		{
//			// Add right space if it doesnt exist.
//			Regex m_spaceRegEx;
//			m_spaceRegEx = new Regex(m_endSpacePattern);
//
//			if (!m_spaceRegEx.IsMatch(inputString))	
//				inputString.PadRight(1, ' ');
//
//			return inputString;
//		}


        #endregion
    }
}