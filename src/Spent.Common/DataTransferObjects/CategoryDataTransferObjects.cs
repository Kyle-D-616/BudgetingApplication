using System;
using System.Collections.Generic;
using System.Text;

namespace Spent.Common.DataTransferObjects
{
   public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public string IconColor { get; set; } = string.Empty;
        public bool IsStandard { get; set; }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal BudgetAmount { get; set; }
        public string IconColor { get; set; } = "#3B82F6";
    }

    public class UpdateCategoryDto
    { 
        public string? Name { get; set; }
        public decimal? BudgetAmount { get; set; }
        public string? IconColor { get; set; }
        public bool? IsActive { get; set; }
    }
}
