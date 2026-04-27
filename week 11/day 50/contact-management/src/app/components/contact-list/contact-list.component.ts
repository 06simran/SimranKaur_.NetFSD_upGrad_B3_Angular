import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Contact } from '../../models/contact.model';
import { PhoneFormatterPipe } from '../../pipes/phone-formatter.pipe';
import { StatusPipe } from '../../pipes/status.pipe';
import { SearchFilterPipe } from '../../pipes/search-filter.pipe';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, FormsModule, PhoneFormatterPipe, StatusPipe, SearchFilterPipe],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {
  searchTerm: string = '';
  showAll: boolean = false;

  contacts: Contact[] = [
  { id: 1,  name: 'rahul sharma',    email: 'rahul.sharma@gmail.com',    phone: '9876543210', isActive: true  },
  { id: 2,  name: 'priya singh',     email: 'priya.singh@gmail.com',     phone: '8765432109', isActive: false },
  { id: 3,  name: 'amit verma',      email: 'amit.verma@gmail.com',      phone: '7654321098', isActive: true  },
  { id: 4,  name: 'neha gupta',      email: 'neha.gupta@gmail.com',      phone: '6543210987', isActive: true  },
  { id: 5,  name: 'vikram patel',    email: 'vikram.patel@gmail.com',    phone: '5432109876', isActive: false },
  { id: 6,  name: 'sneha joshi',     email: 'sneha.joshi@gmail.com',     phone: '4321098765', isActive: true  },
  { id: 7,  name: 'arjun mehta',     email: 'arjun.mehta@gmail.com',     phone: '3210987654', isActive: false },
  { id: 8,  name: 'pooja yadav',     email: 'pooja.yadav@gmail.com',     phone: '2109876543', isActive: true  },
  { id: 9,  name: 'rohit kumar',     email: 'rohit.kumar@gmail.com',     phone: '9988776655', isActive: true  },
  { id: 10, name: 'divya nair',      email: 'divya.nair@gmail.com',      phone: '8877665544', isActive: false },
  { id: 11, name: 'karan malhotra',  email: 'karan.malhotra@gmail.com',  phone: '7766554433', isActive: true  },
  { id: 12, name: 'ananya reddy',    email: 'ananya.reddy@gmail.com',    phone: '6655443322', isActive: false }
];

  get displayLimit(): number {
    return this.showAll ? this.contacts.length : 5;
  }

  toggleStatus(contact: Contact): void {
    contact.isActive = !contact.isActive;
  }

  toggleShowMore(): void {
    this.showAll = !this.showAll;
  }

  get activeCount(): number {
    return this.contacts.filter(c => c.isActive).length;
  }

  get inactiveCount(): number {
    return this.contacts.filter(c => !c.isActive).length;
  }
}
