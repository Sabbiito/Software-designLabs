# Money Class - Principles of Programming

## Overview
This project demonstrates the implementation of a `Money` class in C#, which follows multiple programming principles.

## Programming Principles Demonstrated

### 1. DRY (Don't Repeat Yourself)
The code avoids redundancy by using methods such as `SetMoney` to encapsulate logic, ensuring it is reused throughout the class.
- [`SetMoney` method - Lines 12-18](./Money.cs#L12-L18)

### 2. KISS (Keep It Simple, Stupid)
The code is kept simple and readable by using clear variable names, structured methods, and straightforward logic.
- [`Money` class - Lines 3-22](./Money.cs#L3-L22)

### 3. SOLID Principles
#### **S - Single Responsibility Principle (SRP)**
Each class has a single responsibility. The `Money` class manages money-related operations, while `Program` handles user interaction.
- [`Money` class - Lines 3-22](./Money.cs#L3-L22)
- [`Program` class - Lines 24-47](./Money.cs#L24-L47)

#### **O - Open/Closed Principle (OCP)**
The `Money` class is open for extension but closed for modification. If new currency formatting rules are needed, they can be added without altering existing code.
- [`Money` class - Lines 3-22](./Money.cs#L3-L22)

#### **L - Liskov Substitution Principle (LSP)**
Not explicitly implemented, but if subclasses of `Money` were created, they should be able to replace `Money` without breaking the program.

#### **I - Interface Segregation Principle (ISP)**
Not directly applied, but could be introduced by splitting methods into interfaces if needed.

#### **D - Dependency Inversion Principle (DIP)**
Dependency injection is not used here, but structuring classes to depend on abstractions instead of concrete implementations is a best practice.

### 4. YAGNI (You Ain't Gonna Need It)
The code avoids adding unnecessary functionality. It only implements essential operations like setting, validating, and displaying money values.
- [`Money` class - Lines 3-22](./Money.cs#L3-L22)

### 5. Composition Over Inheritance
Instead of using inheritance unnecessarily, the class `Money` encapsulates behavior internally.
- [`Money` class - Lines 3-22](./Money.cs#L3-L22)

### 6. Program to Interfaces, Not Implementations
Although interfaces are not explicitly used here, the `Money` class could be extended by implementing an interface for flexibility.

### 7. Fail Fast
The `SetMoney` method immediately throws an exception if invalid values (negative numbers) are passed.
- [`SetMoney` method - Lines 12-18](./Money.cs#L12-L18)

## How to Run
1. Compile and run the `Money.cs` file.
2. Enter values when prompted.
3. Observe the output.

## Author
[Христюк Максим ІПЗ 23-2]
