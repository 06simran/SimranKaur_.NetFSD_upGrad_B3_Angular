// app.ts

import { Student } from "./student.model";
import { getGrade, getTopper } from "./student.service";
import { formatName, calculateAverage } from "./utils";
import { PASS_MARKS } from "./constants";

const students: Student[] = [
  { id: 1, name: "alice johnson",  marks: 92 },
  { id: 2, name: "bob smith",      marks: 38 },
  { id: 3, name: "charlie brown",  marks: 75 },
  { id: 4, name: "diana prince",   marks: 61 },
  { id: 5, name: "edward norton",  marks: 85 },
];

console.log("==================================================");
console.log("       STUDENT MANAGEMENT UTILITY");
console.log("==================================================");

console.log("\nPass Marks Threshold:", PASS_MARKS);

console.log("\nStudent Report:");
console.log("--------------------------------------------------");

students.forEach((student) => {
  const formattedName = formatName(student.name);
  const grade = getGrade(student.marks);
  const status = student.marks >= PASS_MARKS ? "Pass" : "Fail";

  console.log(
    `ID: ${student.id} | Name: ${formattedName.padEnd(18)} | Marks: ${String(student.marks).padStart(3)} | Grade: ${grade} | ${status}`
  );
});

console.log("\nClass Average Marks:", calculateAverage(students));

const topper = getTopper(students);
console.log("Class Topper       :", formatName(topper.name), `(Marks: ${topper.marks})`);
console.log("==================================================");
