namespace PolicyMicroservice.Models;

public enum PaymentStatus
{
    /// <summary>
    /// This is a payment that has begun, but is not complete.  An example of this is someone who has filled out the checkout form and then gone to PayPal for payment.  We have the record of sale, but they haven't completed their payment yet.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// This is a payment that has been paid and the product delivered to the customer.
    /// </summary>
    Complete = 1,

    /// <summary>
    /// This is a payment where money has been transferred back to the customer and the customer no longer has access to the product.
    /// </summary>
    Refunded = 2,

    /// <summary>
    /// This is a payment where the payment process failed, whether it be a credit card rejection or some other error.
    /// </summary>
    Failed = 3,

    /// <summary>
    /// If a Pending payment is never completed it becomes Abandoned after a week.
    /// </summary>
    Abandoned = 4,

    /// <summary>
    ///  When a subscription is cancelled then the original payment gets set to cancelled as well.
    /// Cancelled is also used with preapprovals. A preapproval may be cancelled before payment is made.
    /// </summary>
    Cancelled = 5
}
