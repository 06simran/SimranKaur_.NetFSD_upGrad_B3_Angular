// Problem 1: User Profile Data Handling using TypeScript Basics

// Variable Declaration
const userName: string = "John";
const email: string = "john@example.com";
let age: number = 25;
const isSubscribed: boolean = true;

// Type Inference 
const appVersion = "1.0.0";      // inferred as string
const maxLoginAttempts = 5;      // inferred as number

// Template Literal 
const profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log(profileMessage);

// Operators

// Increment age by 1
age += 1;
console.log(`Updated Age: ${age}`);

// Check eligibility for premium plan (age > 18 AND subscribed)
const isPremiumEligible: boolean = age > 18 && isSubscribed;
console.log(`Is ${userName} eligible for Premium Plan: ${isPremiumEligible}`);

// Comparison operators
const isAdult: boolean = age >= 18;
console.log(`Is ${userName} an adult: ${isAdult}`);

// Logical NOT operator
const isNotSubscribed: boolean = !isSubscribed;
console.log(`Is ${userName} NOT subscribed: ${isNotSubscribed}`);


console.log("\n--- User Profile Summary ---");
console.log(`Name: ${userName}`);
console.log(`Age: ${age}`);
console.log(`Email: ${email}`);
console.log(`Subscribed: ${isSubscribed}`);
console.log(`App Version (inferred): ${appVersion}`);
console.log(`Max Login Attempts (inferred): ${maxLoginAttempts}`);
console.log(`Premium Eligible: ${isPremiumEligible}`);
