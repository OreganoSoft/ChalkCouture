using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.Models
{
    public enum ApiErrorCode
    {
        None,
        UnAuthorized,
        SerializationError,
        ServerException,
        Networkexception,
        NotFoundException,
        ReturnToLogin
    }
    public enum MainMenu
    {
        Home,
        Customers,
        WholesaleInventory,
        PersonalInventory,
        Orders,
        Transfer
    }

    public enum OrderStatus
    {
        Completed,
        Opened,

    }

    public enum PaidThrough
    {
        Card,
        Cash
    }

    public enum Category
    {
        Cake,
    }
}
