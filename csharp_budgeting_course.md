# 📚 Course: Building a Budgeting Web App in C# with SOLID, DI, and TDD

---

## Module 1: C# & .NET Fundamentals

### Lesson 1.1: Project Setup
**What**: Set up a Blazor Web App (or ASP.NET Core API if you want pure API first).  

**How**:
```bash
dotnet new webapi -o MyBudgetApp
cd MyBudgetApp
dotnet run
```

**Why**: You need a running app to iterate on. ASP.NET Core gives you DI, controllers, and middleware out of the box.

---

### Lesson 1.2: C# Basics Refresher (OOP)
**What**: Practice with classes, interfaces, records.  

**How**:
```csharp
public record Transaction(string Description, decimal Amount, DateTime Date);
public interface ITransactionProvider
{
    IEnumerable<Transaction> GetTransactions();
}
```

**Why**: Records are great for immutable domain models. Interfaces are crucial for SOLID (Dependency Inversion).

---

## Module 2: SOLID Principles with Domain Design

### Lesson 2.1: Single Responsibility Principle
**What**: Create `Transaction` as a domain entity.  

**How**: Put it in `MyBudgetApp.Core`.  

**Code**:
```csharp
public class Transaction
{
    public string Description { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }

    public Transaction(string description, decimal amount, DateTime date)
    {
        Description = description;
        Amount = amount;
        Date = date;
    }
}
```

**Why**: The class does *one thing* — represent a transaction. Not fetching it, not calculating budgets.

---

### Lesson 2.2: Open/Closed Principle
**What**: Add `ITransactionProvider`.  

**How**: Define in Core, implement later.  

**Code**:
```csharp
public interface ITransactionProvider
{
    IEnumerable<Transaction> GetTransactions();
}
```

**Why**: The app is open to new providers (Plaid, CSV, Mock) without modifying existing logic.

---

## Module 3: Dependency Injection

### Lesson 3.1: Registering Services
**What**: Create `BudgetService` that depends on `ITransactionProvider`.  

**How**:
```csharp
public class BudgetService
{
    private readonly ITransactionProvider _provider;
    public BudgetService(ITransactionProvider provider) => _provider = provider;

    public decimal GetTotalExpenses()
    {
        return _provider.GetTransactions()
                        .Where(t => t.Amount < 0)
                        .Sum(t => t.Amount);
    }
}
```

**Why**: `BudgetService` doesn’t care *where* transactions come from. This makes testing easier and follows **Dependency Inversion**.

---

### Lesson 3.2: Wire Up in Program.cs
```csharp
builder.Services.AddScoped<ITransactionProvider, MockTransactionProvider>();
builder.Services.AddScoped<BudgetService>();
```

**Why**: DI lets ASP.NET Core manage lifetimes, avoiding manual instantiation.

---

## Module 4: Test-Driven Development

### Lesson 4.1: First Test (Red)
**What**: Write test before implementing logic.  

**How** (xUnit + Moq):
```csharp
public class BudgetServiceTests
{
    [Fact]
    public void GetTotalExpenses_ShouldReturnSumOfNegatives()
    {
        var mockProvider = new Mock<ITransactionProvider>();
        mockProvider.Setup(p => p.GetTransactions()).Returns(new[]
        {
            new Transaction("Coffee", -5m, DateTime.Today),
            new Transaction("Salary", 1000m, DateTime.Today)
        });

        var service = new BudgetService(mockProvider.Object);

        Assert.Equal(-5m, service.GetTotalExpenses());
    }
}
```

**Why**: TDD ensures code matches requirements and stays testable.

---

### Lesson 4.2: Implement (Green)
We already wrote `GetTotalExpenses` to pass the test.  

---

### Lesson 4.3: Refactor
- Extract logic, rename methods, but keep tests passing.  

**Why**: Prevents regression and keeps code clean.

---

## Module 5: Infrastructure Integration

### Lesson 5.1: Plaid Transaction Provider
**What**: Implement `PlaidTransactionProvider` in `Infrastructure`.  

**How**: Use Plaid SDK to fetch transactions, map to domain.  

**Why**: This follows SRP (Plaid provider only fetches transactions) and DIP (BudgetService doesn’t know about Plaid).

---

### Lesson 5.2: Swap Providers Easily
- In dev: use `MockTransactionProvider`  
- In prod: use `PlaidTransactionProvider`  

**Why**: DI + interfaces → swap without changing business logic.

---

## Module 6: Application Services

### Lesson 6.1: Budget Summary
**What**: Expand `BudgetService` to calculate net balance.  

**Code**:
```csharp
public record BudgetSummary(decimal TotalIncome, decimal TotalExpenses, decimal Net);

public class BudgetService
{
    private readonly ITransactionProvider _provider;

    public BudgetService(ITransactionProvider provider) => _provider = provider;

    public BudgetSummary CalculateSummary()
    {
        var txns = _provider.GetTransactions();
        var income = txns.Where(t => t.Amount > 0).Sum(t => t.Amount);
        var expenses = txns.Where(t => t.Amount < 0).Sum(t => t.Amount);
        return new BudgetSummary(income, expenses, income + expenses);
    }
}
```

**Why**: Business logic stays pure and testable.

---

## Module 7: Web API Layer

### Lesson 7.1: Expose Controller
**What**: Create `BudgetController`.  

**How**:
```csharp
[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly BudgetService _budgetService;
    public BudgetController(BudgetService budgetService) => _budgetService = budgetService;

    [HttpGet("summary")]
    public ActionResult<BudgetSummary> Get() => _budgetService.CalculateSummary();
}
```

**Why**: The API is thin — delegates to services, no business logic.

---

## Module 8: Beyond the Basics
- Add **logging** (SRP: separate concern)  
- Add **database persistence** (via EF Core Repository pattern)  
- Add **authentication** (per-user budgets)  
- Add **frontend UI in Blazor**  

---

# 🎯 Learning Outcome
By the end, you’ll:
- Understand **C# + .NET basics**  
- Apply **SOLID** in a real project  
- Use **Dependency Injection** effectively  
- Follow **TDD workflow**  
- Build a **real budgeting web app** connected to Plaid
