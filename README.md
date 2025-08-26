# Bank System Console Application

This is a simple bank system implemented as a C# console application using the .NET Framework. The project allows users to interact with two bank accounts, performing deposits, withdrawals, and transfers between them. The application is designed for educational purposes, demonstrating core Object Oriented Programming (OOP) concepts.

## Features

- **Deposit money** into an account
- **Withdraw money** from an account
- **Transfer money** between two accounts
- **View account details**
- **Undo (rollback) transactions** immediately after execution

## Object Oriented Programming Concepts Demonstrated

- **Encapsulation**
  - Data and transaction logic are encapsulated within classes (`Account`, `DepositTransaction`, `WithdrawTransaction`, `TransferTransaction`).
- **Abstraction**
  - Complex banking operations are abstracted into simple methods (`Execute`, `Rollback`, `Print`).
- **Modularity**
  - Each transaction type is implemented as a separate class, promoting code organization and reuse.
- **Composition**
  - `TransferTransaction` is composed of both a `DepositTransaction` and `WithdrawTransaction`.
- **Information Hiding**
  - Fields within classes are marked as `private` and exposed via properties and methods.
- **Constructors**
  - Objects are initialized with constructors that set up their internal state.

## Usage Instructions

### Requirements

- Microsoft Visual Studio 2022
- .NET Framework (C# Console Application)

### How to Run

1. **Clone or Download** the project files and open the solution in Visual Studio 2022.
2. **Build and Run** the project. The console UI will appear.

### Program Flow

- On startup, two account holders are created:
  - `Jim` with a starting balance of `$1025.80`
  - `Oscar` with a starting balance of `$550.20`
- You will be repeatedly presented with a menu of options:
  - Withdraw
  - Deposit
  - Print (view account details)
  - Transfer (between Jim and Oscar)
  - Quit

### How to Interact

- **Withdraw/Deposit:** Enter the amount when prompted. You can immediately choose to reverse the transaction.
- **Transfer:** Enter the amount to transfer from Jim's account to Oscar's account. You can immediately choose to reverse the transaction.
- **Print:** Displays the current account's balance and details.
- **Quit:** Exits the program.

### Example: Creating Account Holders

Account holders are created in the `Main` function as follows:

```csharp
Account jimCBA = new Account("Jim", 1025.80);
Account oscarNAB = new Account("Oscar", 550.20);
```

### Limitations

- **Only two account holders** are supported (`Jim` and `Oscar`). The system is not designed for dynamic account creation or for handling more than two accounts.
- Transfers are only possible between these two accounts.
- Account names and initial balances are hardcoded in the `Main` function.
- The application is designed for console interaction; there is no graphical user interface.
- Transaction reversal (rollback) can only be performed immediately after execution and only once per transaction.
- No persistent storage: All data is kept in memory and lost when the program ends.

## File Structure

- `Account.cs` – Defines the account class and its methods
- `DepositTransaction.cs` – Handles deposit transactions
- `WithdrawTransaction.cs` – Handles withdrawal transactions
- `TransferTransaction.cs` – Handles transfers between accounts
- `BankSystem.cs` – Main program logic and menu interface

---

Feel free to use and modify this project as a learning tool for C# and Object Oriented Programming!
