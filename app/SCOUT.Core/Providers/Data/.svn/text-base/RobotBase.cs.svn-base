using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// A base level class that supports rule validation.
    /// </summary>
    public class RobotBase : 
        IDataErrorInfo
    {
        #region Rule Validation

        public BrokenRules GetBrokenRules()
        {
            BrokenRules v = new BrokenRules();
            ValidateRules(v);
            return v;
        }

        /// <summary>
        /// Validates any business logic rules.
        /// </summary>
        protected virtual void ValidateRules(BrokenRules Verify)
        {
        }

        #endregion

        #region IDataErrorInfo Members

        [Bindable(false), Browsable(false)]
        public string Error
        {
            get
            {
                List<BrokenRule> brokenRules = GetBrokenRules();
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < brokenRules.Count; ++i)
                {
                    if (i > 0)
                        sb.Append("\n");

                    sb.Append("- ");
                    sb.Append(brokenRules[i].Description);
                }

                return sb.ToString();
            }
        }

        public string this[string columnName]
        {
            get
            {
                List<BrokenRule> brokenRules = GetBrokenRules();
                StringBuilder sb = new StringBuilder();
                int cnt = 0, i;

                for (i = 0; i < brokenRules.Count; ++i)
                {
                    if (brokenRules[i].Column != columnName)
                        continue;

                    if (cnt > 0)
                        sb.Append("\n");

                    sb.Append("- ");
                    sb.Append(brokenRules[i].Description);
                    ++cnt;
                }

                return sb.ToString();
            }
        }

        #endregion
    }
}
