namespace SCOUT.Core.Data
{
    public interface ISerialIdentifier
    {
        string Example { get;}
        string DisplayName { get;}
        bool SilentValidate();
        void SetSerial(string sn);
    }
}