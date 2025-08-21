# BankSystem

## Description

**BankSystem** is an object-oriented C# program that simulates simple banking operations for a single account. It demonstrates key object-oriented and programming techniques:

### Applied Techniques & Design Concepts

- **Object-Oriented Design:**  
  - The `Account` class encapsulates account data (name, balance) and provides methods for deposit, withdrawal, printing account details, and input validation.
  - The `BankSystem` class contains the application logic and user interface, including the main loop for menu-driven interaction.

- **Encapsulation:**  
  - Account details are stored as private instance variables, accessible only through class methods and properties.

- **Constructor Initialization:**  
  - The `Account` object is initialized with a name and starting balance.

- **Input Validation:**  
  - Methods guard against invalid or out-of-range input, using both custom validation and built-in parsing methods.

- **Menu-Driven Interface:**  
  - Uses an enumeration for menu options and a loop to repeatedly prompt the user for actions (withdraw, deposit, print balance, quit).

- **Transaction Methods:**  
  - Deposit and withdrawal logic is encapsulated within the `Account` class, including checks for negative amounts and insufficient funds.
  - All amounts are formatted for display in US currency style.

- **Exception Handling:**  
  - Robust handling for invalid input and transaction errors, preventing crashes or invalid states.

### Demonstrated Operations

- Withdraw funds from the account.
- Deposit funds into the account.
- Print current account details.
- Quit the program.

The sample implementation operates on a single hardcoded account (`Jim` with a starting balance of `$100.10`), but the structure allows easy extension to manage multiple accounts.

---

## Instructions

To run the **BankSystem** program in **Microsoft Visual Studio 2022**, follow these steps:

1. **Clone or Download the Repository**
   - Download as ZIP or use Git:
     ```
     git clone https://github.com/rainool/BankSystem.git
     ```

2. **Open in Visual Studio 2022**
   - Launch Visual Studio.
   - Go to `File` > `Open` > `Project/Solution`.
   - Navigate to the folder containing `Account.cs` and `BankSystem.cs`.
   - Open the folder as a project, or create a new C# Console Application and add both files to the project.

3. **Add Source Files to Project**
   - Ensure both files are included in the `BankSystem` namespace.

4. **Set Startup Object**
   - Confirm `BankSystem.cs` includes the correct `Main` method and is set as the startup file.

5. **Build and Run**
   - Press `Ctrl + F5` (or click `Start Without Debugging`) to compile and run.
   - Interact with the console-based menu to deposit, withdraw, print account details, or quit.

### Requirements

- **Microsoft Visual Studio 2022**
- **.NET 6.0 or later** (recommended)

---

## License

This project is open source and available under the MIT License.

---

Feel free to modify or extend the system to support multiple accounts, transaction history, or additional banking features!
