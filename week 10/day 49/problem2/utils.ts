// utils.ts

import { Student } from "./student.model";

export function formatName(name: string): string {
  return name
    .trim()
    .split(" ")
    .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
    .join(" ");
}

export function calculateAverage(students: Student[]): number {
  if (students.length === 0) return 0;
  const total = students.reduce((sum, s) => sum + s.marks, 0);
  return parseFloat((total / students.length).toFixed(2));
}
