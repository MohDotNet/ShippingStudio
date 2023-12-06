using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Enums
{
    public class Enums
    {
        enum LineStatusEnum
        {
            /// <summary>
            /// A Line is in the new status prior to it being shipped.
            /// </summary>
            New = 0,

            /// <summary>
            /// Line or part line has been shipped.
            /// </summary>
            InProgress = 1,

            /// <summary>
            /// Line has been delivered as required taking into consideration the tolerance level.
            /// </summary>
            Completed = 2,

            /// <summary>
            /// A Line has been placed on hold.
            /// </summary>
            Onhold = 3,

            /// <summary>
            /// Line has been cancellled.
            /// </summary>
            Cancelled = 4
        }

        enum OrderStatus
        {
            /// <summary>
            /// Order in a new state prior to a confirmed indent from the supplier.
            /// </summary>
            New = 0,

            /// <summary>
            /// Shipping cycle has started
            /// </summary>
            InProgress = 1,

            /// <summary>
            /// All requirements have been met and the order has been delivered.
            /// </summary>
            Completed = 2,

            /// <summary>
            /// Order has been placed on hold for what ever reason including authoritiy checks etc.
            /// </summary>
            Onhold = 3,

            /// <summary>
            /// Order cancelled and is no longer required.
            /// </summary>
            Cancelled = 4
        }
    }
}
