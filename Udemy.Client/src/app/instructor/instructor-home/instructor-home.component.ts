import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../lib/services/account.service';

@Component({
  selector: 'app-instructor-home',
  imports: [RouterLink],
  templateUrl: './instructor-home.component.html',
  styleUrl: './instructor-home.component.css'
})
export class InstructorHomeComponent {
  constructor(private router: Router) {}


  goToCourseCreate(){
    this.router.navigate(['/createcourse/FGCOURSE']);
  }
  goToCourseUPdate(){
    this.router.navigate(["instructors/:id/courses"])
  }
}
