"use strict";
// Problem 1: User Profile Data Handling using TypeScript Basics
// Variable Declaration with explicit types
const userName = "John";
const email = "john@example.com";
let age = 25;
const isSubscribed = true;
// Type Inference — TypeScript infers these types automatically
const appVersion = "1.0.0"; // inferred as string
const maxLoginAttempts = 5; // inferred as number
// Template Literal — formatted user profile message
const profileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log(profileMessage);
// Operators
// Increment age by 1
age += 1;
console.log(`Updated Age: ${age}`);
// Check eligibility for premium plan (age > 18 AND subscribed)
const isPremiumEligible = age > 18 && isSubscribed;
console.log(`Is ${userName} eligible for Premium Plan: ${isPremiumEligible}`);
// Comparison operators
const isAdult = age >= 18;
console.log(`Is ${userName} an adult: ${isAdult}`);
// Logical NOT operator
const isNotSubscribed = !isSubscribed;
console.log(`Is ${userName} NOT subscribed: ${isNotSubscribed}`);
// Summary output
console.log("\n--- User Profile Summary ---");
console.log(`Name: ${userName}`);
console.log(`Age: ${age}`);
console.log(`Email: ${email}`);
console.log(`Subscribed: ${isSubscribed}`);
console.log(`App Version (inferred): ${appVersion}`);
console.log(`Max Login Attempts (inferred): ${maxLoginAttempts}`);
console.log(`Premium Eligible: ${isPremiumEligible}`);
