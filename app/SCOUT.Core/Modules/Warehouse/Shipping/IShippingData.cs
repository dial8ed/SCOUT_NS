namespace SCOUT.Core.Data
{
    public interface IShippingData
    {
        object[] GetData();
        Packlist GetPacklist(IUnitOfWork uow, string packlistId);
    }
}