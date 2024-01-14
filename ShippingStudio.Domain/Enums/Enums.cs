namespace ShippingStudio.Domain.Enums
{

    public enum LineStatusEnum
        {
            /// <summary>
            /// A Line is in the new status prior to it being shipped.
            /// </summary>
            New = 1,

            /// <summary>
            /// Line or part line has been shipped.
            /// </summary>
            InProgress = 2,

            /// <summary>
            /// Line has been delivered as required taking into consideration the tolerance level.
            /// </summary>
            Completed = 3,

            /// <summary>
            /// A Line has been placed on hold.
            /// </summary>
            Onhold = 4,

            /// <summary>
            /// Line has been cancellled.
            /// </summary>
            Cancelled = 5
        }
    public enum OrderStatus
        {
            /// <summary>
            /// Order in a new state prior to a confirmed indent from the supplier.
            /// </summary>
            New = 1,

            /// <summary>
            /// Shipping cycle has started
            /// </summary>
            InProgress = 2,

            /// <summary>
            /// All requirements have been met and the order has been delivered.
            /// </summary>
            Completed = 3,

            /// <summary>
            /// Order has been placed on hold for what ever reason including authoritiy checks etc.
            /// </summary>
            Onhold = 4,

            /// <summary>
            /// Order cancelled and is no longer required.
            /// </summary>
            Cancelled = 5
        }

    public enum SystemCodes
    {
        success = 0,
        nullObject = 1,
        requestValidationError = 2,

    }
 
}

