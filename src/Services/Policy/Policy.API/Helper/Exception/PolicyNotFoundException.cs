namespace PolicyMicroservice.Helper;

internal class PolicyNotFoundExpection : Exception
{
    private new const string Message = "Policy Not Found";

    public string? Reason { get; set; }

    public PolicyNotFoundExpection(Guid policyId)
        : base(Message)
    {
        base.Data[nameof(policyId)] = policyId;
    }

    public PolicyNotFoundExpection(Guid policyId, string reason)
        : this(policyId)
    {
        base.Data[nameof(reason)] = reason;
    }

    public PolicyNotFoundExpection()
    { }

    public PolicyNotFoundExpection(string? message) : base(message)
    { }

    public PolicyNotFoundExpection(string? message, Exception? innerException) : base(message, innerException)
    { }
}