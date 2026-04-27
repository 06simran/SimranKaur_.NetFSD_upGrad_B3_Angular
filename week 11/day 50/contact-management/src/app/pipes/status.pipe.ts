import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusLabel',
  standalone: true,
  pure: true
})
export class StatusPipe implements PipeTransform {
  transform(isActive: boolean): string {
    return isActive ? 'Active' : 'Inactive';
  }
}
