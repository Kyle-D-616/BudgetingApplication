namespace Spent.Common.DataTransferObjects
{
	public class TransationDto
	{
		public Guid Id { get; set; }
		public Guid AccountId { get; set; }
		public string AccountName { get; set; }
		public Guid CategoryId { get; set; }
        	public string CategoryName { get; set; } = string.Empty;
        	public decimal Amount { get; set; }
        	public DateTime Date { get; set; }
        	public string Description { get; set; } = string.Empty;
        	public bool IsManual { get; set; }
	}
	public class CreateTransactionDto
	    {
		public Guid AccountId { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Amount { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; } = string.Empty;
	    }

	public class UpdateTransactionDto
	    {
		public Guid? CategoryId { get; set; }
		public decimal? Amount { get; set; }
		public DateTime? Date { get; set; }
		public string? Description { get; set; }
	    }
}
