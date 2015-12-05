namespace SCOUT.Core.Data
{
    /// <summary>
    /// Declares what is required to get and show errors for a Validator class.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Returns true if a error exists. False if Not.
        /// </summary>
        /// <returns></returns>
        bool HasError();

        /// <summary>
        /// The error message that is displayed by the MessageListener
        /// </summary>
        string Error { get;}

        /// <summary>
        /// Checks if task is valid
        /// Sets m_error to the error if it is not valid.
        /// </summary>
        void GetError();

        /// <summary>
        /// Shows the error in a message box.
        /// </summary>
        void ShowError();

        /// <summary>
        /// Tells the message listener the error. 
        /// </summary>
        void RaiseError();

        /// <summary>
        /// Checks for an error and raises the error if one exists.
        /// </summary>
        /// <returns></returns>
        bool Validated();
        
        
    }
}