import { CommonModule } from '@angular/common';
import { Component, input } from '@angular/core';
import { dummyInstructor, Instructor } from '../../models/instructor.model';

@Component({
  selector: 'app-instructor-bio',
  imports: [CommonModule],
  templateUrl: './instructor-bio.component.html',
  styleUrl: './instructor-bio.component.css'
})
export class InstructorBioComponent {

  instructorId=input<number>();
  instructor!:Instructor;

  ngOnInit() {
    console.log("Instructor ID: ", this.instructorId());
    this.instructor = dummyInstructor;
    console.log("Instructor: ", this.instructor);
  }


}
