// 1. This prevents the "Redeclare block-scoped variable" error
export {}; 

// 2. Defining an Interface (The Blueprint)
interface Course {
    name: string;
    duration: string;
}

// 3. Creating a Class (OOP Concepts)
class Student {
    // Encapsulation: private property
    private grades: number[] = [];

    constructor(
        public uname: string, 
        public age: number, 
        public enrolled: boolean
    ) {}

    // Method to work with Arrays
    addGrade(newGrade: number): void {
        this.grades.push(newGrade);
        console.log(`Added grade ${newGrade} for ${this.uname}`);
    }

    // Method using ES6 Template Literals
    getStudentSummary(): string {
        const average = this.grades.length > 0 
            ? this.grades.reduce((a, b) => a + b) / this.grades.length 
            : 0;
            
        return `Student: ${this.uname} | Age: ${this.age} | Avg Grade: ${average}`;
    }
}

// 4. Working with the Code
const myStudent = new Student("Scott", 25, true);

// Using Arrays
myStudent.addGrade(85);
myStudent.addGrade(92);
myStudent.addGrade(78);

// 5. Array of Objects
let myCourses: Course[] = [
    { name: "TypeScript Basics", duration: "2 Hours" },
    { name: "Angular Fundamentals", duration: "5 Hours" }
];

// Final Output
console.log("---------------------------------");
console.log(myStudent.getStudentSummary());
console.log("Enrolled Courses:");
myCourses.forEach(c => console.log(`- ${c.name} (${c.duration})`));
console.log("---------------------------------");