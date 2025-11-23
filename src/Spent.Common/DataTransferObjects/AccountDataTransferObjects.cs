namespace Spent.Common.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsManual { get; set; }
        public DateTime? LastSynced { get; set; }
        public decimal CurrentBalance { get; set; }
    }

    public class CreateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
