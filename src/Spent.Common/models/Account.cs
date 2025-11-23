using System;
using System.Collections.Generic;
using System.Text;

namespace Spent.Common.models
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public AccountType Type { get; set; }
        public string? PlaidAccountId  { get; set; }
        public string? PlaidAccessToken { get; set; }
        public bool IsManual { get; set; } = true;
        public DateTime? LastSynced {  get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Transaction>? Transactions { get; set; }
    }

    public enum AccountType
    {
        Checking,
        Savings,
        CreditCard,
        Cash,
        Other,
    }
}
