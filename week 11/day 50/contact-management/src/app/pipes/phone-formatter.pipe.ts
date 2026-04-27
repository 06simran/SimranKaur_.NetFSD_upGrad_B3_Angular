import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneFormatter',
  standalone: true,
  pure: true
})
export class PhoneFormatterPipe implements PipeTransform {
  transform(phone: string): string {
    if (!phone) return '';
    const cleaned = phone.replace(/\D/g, '');
    if (cleaned.length === 10) {
      return `${cleaned.slice(0, 3)}-${cleaned.slice(3, 6)}-${cleaned.slice(6)}`;
    }
    return phone;
  }
}
