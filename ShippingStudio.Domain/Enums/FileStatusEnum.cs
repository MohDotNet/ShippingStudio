using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Enums
{

    /// <summary>
    /// Enum should correspond to the values in the Filestatus table.
    /// </summary>
    public enum FileStatusEnum
    {
        /// <summary>
        /// File has been created but no active order has been associated with it
        /// </summary>
        New = 0,

        /// <summary>
        /// File is open when orders are associated with it, and such order/s have an order status of other than closed
        /// </summary>
        Open = 1,

        /// <summary>
        /// A File is set on hold if for any reason a supplier cannot commit to orders for the near future without resolution pending.
        /// </summary>
        Onhold = 2,

        /// <summary>
        /// All orders have been closed.
        /// </summary>
        Closed = 3
    }
}
