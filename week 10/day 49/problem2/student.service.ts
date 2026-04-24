// student.service.ts

import { Student } from "./student.model";
import { PASS_MARKS } from "./constants";

export function getGrade(marks: number): string {
  if (marks >= 90) return "A";
  if (marks >= 75) return "B";
  if (marks >= 60) return "C";
  if (marks >= PASS_MARKS) return "D";
  return "F";
}

export function getTopper(students: Student[]): Student {
  if (students.length === 0) {
    throw new Error("No students provided.");
  }
  return students.reduce((top, s) => (s.marks > top.marks ? s : top));
}
