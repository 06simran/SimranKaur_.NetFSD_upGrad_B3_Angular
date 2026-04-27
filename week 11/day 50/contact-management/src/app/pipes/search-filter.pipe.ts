import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../models/contact.model';

@Pipe({
  name: 'searchFilter',
  standalone: true,
  pure: false
})
export class SearchFilterPipe implements PipeTransform {
  transform(contacts: Contact[], searchTerm: string): Contact[] {
    if (!contacts || !searchTerm || searchTerm.trim() === '') {
      return contacts;
    }
    const term = searchTerm.toLowerCase().trim();
    return contacts.filter(contact =>
      contact.name.toLowerCase().includes(term) ||
      contact.email.toLowerCase().includes(term)
    );
  }
}
