using System;
using System.Collections.Generic;
using System.Text;

namespace Spent.Common.models
{
    public class Catagory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public decimal BudgetAmount { get; set; }
        public sting IconColor { get; set; } = "#3B82F6";
        public bool IsStandard { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = Datetime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }

    public class StandardCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal DefaultAmount { get; set; }
        public string IconColor { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}

