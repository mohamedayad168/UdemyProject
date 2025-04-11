import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-firstpageaftercreate',
  imports: [],
  templateUrl: './firstpageaftercreate.component.html',
  styleUrl: './firstpageaftercreate.component.css'
})
export class FirstpageaftercreateComponent {
  hoveredOption: string = '';
  selectedOption: string = '';

  constructor(private router: Router) {}

  selectOption(option: string) {
    this.selectedOption = option;
    
   
    if (option === 'course') {
      this.router.navigate(['/createcourse/entercoursetitel']);
    } else if (option === 'practice-test') {
      this.router.navigate(['/practice-test-creation']);
    }
  }
}


