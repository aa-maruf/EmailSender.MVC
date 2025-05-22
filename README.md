# ASP.NET Core MVC - User Registration with Email Notification

This ASP.NET Core MVC web application allows users to register with their name, email, and password. After registration, user data is saved to a SQL database, and a congratulatory email is sent to the provided email address.

---

## 🚀 Features

- User registration form (Name, Email, Password)
- Data stored using Entity Framework Core (EF Core)
- Sends a welcome email using Gmail SMTP

---

## 🛠 Installation & Setup

### Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- Visual Studio 2022 / Visual Studio Code
- SQL Server or SQLite
- Gmail account with [App Password](https://support.google.com/accounts/answer/185833)

### Required NuGet Packages

Install via terminal or NuGet Package Manager:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
````

---

### 🔧 Setup Steps

1. **Clone the repository**

   ```bash
   git clone https://github.com/aa-maruf/EmailSender.MVC.git
   cd EmailSender.MVC
   ```

2. **Configure Gmail App Password**

   Google blocks direct SMTP logins with your normal password. To send emails using Gmail SMTP:

   * Enable **2-Step Verification** in your Google Account:
     👉 [myaccount.google.com/security](https://myaccount.google.com/security)

   * Go to **App Passwords**, select *Mail*, and name it (e.g., `ASP.NET App`).

   * Google will generate a 16-digit app password (e.g., `abcd efgh ijkl mnop`).

   * Set it as an environment variable in your system:

     ```bash
     setx gmail_pass "your-app-password"
     ```

3. **Update `EmailSender.cs`**

   Replace the placeholder email with your Gmail:

   ```csharp
   var username = "your_email@gmail.com";
   var fromEmail = "your_email@gmail.com";
   ```

4. **Run EF Core Migrations**

   In the **Package Manager Console**:

   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```

5. **Run the application**

   ```bash
   dotnet run
   ```

---

## 📂 Project Structure

* `Controllers/UserController.cs` – Handles form submission and email sending
* `Models/User.cs` – User model for EF Core
* `Data/EmployeeDBContext.cs` – EF Core database context
* `Service/EmailSender.cs` – Sends congratulatory emails
* `Views/User/Create.cshtml` – Registration form UI
* `Views/User/Index.cshtml` – Displays list of registered users

---

## 📧 Sample Email

```html
<h2>Congratulations, Alice!</h2>
<p>Your account has been created successfully.</p>
```

---


