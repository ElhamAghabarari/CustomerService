namespace Elham.OrderManagement.Service
{
    public interface ICustomerService
    {
        void Create();
        void Get(int id);
        void GetList();
        void Update();
        void Delete(int id);
    }
}
