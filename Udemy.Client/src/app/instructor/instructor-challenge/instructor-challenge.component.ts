import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-instructor-challenge',
  imports: [],
  templateUrl: './instructor-challenge.component.html',
  styleUrl: './instructor-challenge.component.css'
})
export class InstructorChallengeComponent {
  constructor(private router: Router) {}

  goToCongratulation() {
    this.router.navigate(['instructor/congratulation']);
  }

}
