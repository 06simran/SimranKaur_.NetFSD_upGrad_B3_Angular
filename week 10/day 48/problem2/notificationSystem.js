"use strict";
// Problem 2: User Notification System using TypeScript Functions
// 1. Function with Required Parameters
function getWelcomeMessage(name) {
    return `Welcome, ${name}! We're glad to have you here.`;
}
// 2. Optional Parameters
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `User: ${name}, Age: ${age}`;
    }
    return `User: ${name} (Age not provided)`;
}
// 3. Default Parameters
function getSubscriptionStatus(name, isSubscribed = false) {
    if (isSubscribed) {
        return `${name} is currently subscribed to the premium plan.`;
    }
    return `${name} is not subscribed. Upgrade to premium for more benefits!`;
}
// 4. Return Types — function returning boolean
function isEligibleForPremium(age) {
    return age > 18;
}
// 5. Arrow Functions — rewriting getWelcomeMessage as arrow function
const getWelcomeMessageArrow = (name) => `Welcome, ${name}! We're glad to have you here.`;
// Arrow version of isEligibleForPremium
const checkPremiumEligibility = (age) => age > 18 ? true : false;
// 6. Lexical 'this' — NotificationService using arrow function
const NotificationService = {
    appName: "MyAngularApp",
    // Arrow function preserves 'this' from the enclosing context
    sendNotification: function (message) {
        const format = (msg) => `[${this.appName}] Notification: ${msg}`;
        console.log(format(message));
    },
    greetUser: function (name) {
        // Arrow function inside method captures 'this' correctly
        const greet = () => `Hello from ${this.appName}, ${name}!`;
        console.log(greet());
    }
};
// 7. Execution — Call all functions and print outputs
console.log("--- Notification System Output ---\n");
// Required parameter
console.log(getWelcomeMessage("Alice"));
// Optional parameter — with and without age
console.log(getUserInfo("Bob", 30));
console.log(getUserInfo("Charlie"));
// Default parameter — with and without isSubscribed
console.log(getSubscriptionStatus("Diana", true));
console.log(getSubscriptionStatus("Eve"));
// Boolean return type
console.log(`Is user aged 20 eligible for premium: ${isEligibleForPremium(20)}`);
console.log(`Is user aged 16 eligible for premium: ${isEligibleForPremium(16)}`);
// Arrow function versions
console.log(getWelcomeMessageArrow("Frank"));
console.log(`Arrow premium check for age 22: ${checkPremiumEligibility(22)}`);
// Lexical this in NotificationService
NotificationService.sendNotification("Your account has been updated.");
NotificationService.greetUser("Grace");
