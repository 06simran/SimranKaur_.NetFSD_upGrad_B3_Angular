"use strict";
// Problem 3: Employee Management Module using TypeScript Classes
// Base Class: Employee
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    // Getter for salary
    getSalary() {
        return this.salary;
    }
    // Setter for salary with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Invalid salary: Salary must be greater than 0.");
        }
    }
    // Method to display employee details
    displayDetails() {
        console.log(`Employee ID   : ${this.id}`);
        console.log(`Employee Name : ${this.name}`);
        console.log(`Salary        : $${this.getSalary()}`);
    }
}
// Derived Class: Manager (inherits from Employee)
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary); // Call base class constructor
        this.teamSize = teamSize;
    }
    // Method Overriding — override displayDetails()
    displayDetails() {
        super.displayDetails(); // Include employee details from base class
        console.log(`Team Size     : ${this.teamSize}`);
        console.log(`Role          : Manager`);
    }
}
// Object Creation and Method Calls
console.log("=== Employee Management System ===\n");
// Create an Employee object
const emp = new Employee(101, "Alice Johnson", 50000);
console.log("--- Employee Details ---");
emp.displayDetails();
// Use setter — valid salary update
console.log("\nUpdating salary to $55000...");
emp.setSalary(55000);
console.log(`Updated Salary: $${emp.getSalary()}`);
// Use setter — invalid salary update
console.log("\nAttempting to set invalid salary (-500)...");
emp.setSalary(-500);
console.log(`Salary after invalid attempt: $${emp.getSalary()}`);
// Create a Manager object
const mgr = new Manager(201, "Bob Smith", 90000, 8);
console.log("\n--- Manager Details ---");
mgr.displayDetails();
// Update manager's salary using setter
console.log("\nUpdating manager's salary to $95000...");
mgr.setSalary(95000);
console.log(`Updated Manager Salary: $${mgr.getSalary()}`);
