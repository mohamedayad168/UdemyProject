import { CommonModule } from '@angular/common';
import { Component, input } from '@angular/core';
import { dummyInstructor, Instructor } from '../../models/instructor.model';
import { InstructorServiceService } from '../../services/instructor-service.service';

@Component({
  selector: 'app-instructor-bio',
  imports: [CommonModule],
  templateUrl: './instructor-bio.component.html',
  styleUrl: './instructor-bio.component.css'
})
export class InstructorBioComponent {

  instructorId=input<number>();
  instructor!:Instructor;
  instructorService:InstructorServiceService;
  constructor(instructorService:InstructorServiceService) {
    this.instructorService=instructorService;

  }


  ngOnInit() {
    const instructorId = this.instructorId();
    if (instructorId === undefined) {
      console.error("Instructor ID is undefined.");
      this.instructor = dummyInstructor;
      return;
    }
    this.instructorService.getInstructorById(instructorId).subscribe((data:Instructor) => {
      if(data){
        this.instructor=data;
      }
      else{
        console.error("No data received for instructor.");
        this.instructor = dummyInstructor;
        // route to a 404 page or show an error message
      }
    });
  }


}
