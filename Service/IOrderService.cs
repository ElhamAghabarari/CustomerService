using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elham.OrderManagement.Service
{
    public interface IOrderService
    {
        void Create();
        void Get(int id);
        void GetList();
        void Update();
        void Delete(int id);
    }
}
