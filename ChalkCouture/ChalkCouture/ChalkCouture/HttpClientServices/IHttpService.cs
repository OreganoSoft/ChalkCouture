using System;
using System.Collections.Generic;
using System.Text;

namespace ChalkCouture.HttpClientServices
{
    public interface IHttpService
    {
        void GetOrder(int customerId);
    }
}
