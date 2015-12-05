using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class SerializedHistoryService
    {        
        public static SerializedUnit GetLastReturn(Session session, SerializedUnit unit)
        {
            return SerializedHistoryRepository.GetLastReturn(session, unit);
        }

        public static int GetTimeInFieldFor(SerializedUnit unit)
        {
            return SerializedHistoryRepository.GetTimeInFieldFor(unit);
        }

        public static int GetReturnSeedFor(SerializedUnit unit)
        {
            return SerializedHistoryRepository.GetReturnSeedFor(unit);
        }        
    }
}