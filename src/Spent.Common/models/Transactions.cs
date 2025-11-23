using System;
using System.Collections.Generic;
using System.Text;

namespace Spent.Common.models
{
    internal class Transactions
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public Guid CategoryId  { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date {  get; set; }
        public string Description { get; set; } = string.Empty;
        public string IsManual { get; set; } = true;
        public string? PlaidTransactionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Category? Category { get; set; }
        public Account? Account { get; set; }
    }


}
