import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-congratulation',
  imports: [],
  templateUrl: './congratulation.component.html',
  styleUrl: './congratulation.component.css'
})
export class CongratulationComponent {
  constructor(private router: Router) {}

  gotocreationcourse() {
    this.router.navigate(['/createcourse/FGCOURSE']);

}
}