import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
interface Section {
  title: string;
  subtitle: string;
  paragraphs: string[];
  helpText: string;
  image: string;
}

@Component({
  selector: 'app-cometeachwithus',
  imports: [CommonModule,ButtonModule],
  templateUrl: './cometeachwithus.component.html',
  styleUrl: './cometeachwithus.component.css'
})

export class CometeachwithusComponent {
  reasons = [
    'Share your knowledge with eager learners',
    'Flexible teaching schedule',
    'Competitive compensation',
    'Join a community of experts',
    'Make a real difference in people\'s lives'
  ];
  
  selectedSection: Section;
  
  sections: Section[] = [
    {
      title: 'Plan Curriculum',
      subtitle: 'Create Your Course Content',
      paragraphs: [
        "You start with your passion and knowledge. Then",
        "choose a promising topic with the help of ourMarketplace Insights tool.",
        "The way that you teach — what you bring to it — is up to you.."
      ],
      helpText: 'We offer plenty of resources on how to create.',
      image: 'assets/image/plan-your-curriculum-2x-v3.webp'
    },
    {
      title: 'Record Videos',
      subtitle: 'Produce Engaging Content',
      paragraphs: [
        "Use our recommended recording setup or your own equipment.",
        "Record directly in our platform or upload your videos.",
        "Edit and polish your content with our simple tools."
      ],
      helpText: 'Get free access to our video production guides and checklists.',
      image: 'assets/image/record-your-video-2x-v3.webp'
    },
    {
      title: 'Launch Course',
      subtitle: 'Publish and Promote',
      paragraphs: [
        "Set your pricing and enrollment options.",
        "Preview how your course will appear to students.",
        "Launch with our marketing support."
      ],
      helpText: 'We handle all the technical setup and provide promotional materials.',
      image: 'assets/image/launch-your-course-2x-v3.webp'
    }
  ];

  constructor(private router: Router) {
      this.selectedSection = this.sections[0];
    }

navigateToGetStarted() {
  this.router.navigate(['/get-started']);
}

  selectSection(section: Section) {
    this.selectedSection = section;
  }

}

