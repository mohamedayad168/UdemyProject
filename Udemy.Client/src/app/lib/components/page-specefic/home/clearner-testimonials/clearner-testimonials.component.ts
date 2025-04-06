import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

interface Testimonial {
  name: string;
  review: string;
  rating: number;
}
@Component({
  selector: 'app-clearner-testimonials',
  imports: [CommonModule],
  templateUrl: './clearner-testimonials.component.html',
  styleUrl: './clearner-testimonials.component.css'
})
export class ClearnerTestimonialsComponent {

  testimonials: Testimonial[] = [
    { name: 'John Doe', review: 'Great course! Learned a lot and enjoyed every minute.', rating: 5 },
    { name: 'Jane Smith', review: 'Very informative and well-paced. Highly recommended!', rating: 4 },
    { name: 'Carlos Gomez', review: 'Helped me get a new job! Fantastic content.', rating: 5 }
  ];
}


