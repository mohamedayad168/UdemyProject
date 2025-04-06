import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

interface Feature {
  id: number;
  icon: string;
  title: string;
  description: string;
  details: string;
  linkText: string;
}
@Component({
  selector: 'app-hands-on-training',
  imports: [CommonModule],
  templateUrl: './hands-on-training.component.html',
  styleUrl: './hands-on-training.component.css'
})
export class HandsOnTrainingComponent {selectedFeature: Feature | null = null;

  features: Feature[] = [
    {
      id: 1,
      icon: '⭐',
      title: 'Hands-on training',
      description: 'Upskill effectively with AI-powered coding exercises, practice tests, and quizzes.',
      details: 'AI-powered exercises and hands-on practice to sharpen your skills in real-world scenarios.',
      linkText: 'Explore courses'
    },
    {
      id: 2,
      icon: '📄',
      title: 'Certification prep',
      description: 'Prep for industry-recognized certifications by solving real-world challenges and earn badges along the way.',
      details: 'Certification-focused content to help you gain industry-recognized qualifications with practical challenges.',
      linkText: 'Explore courses'
    },
    {
      id: 3,
      icon: '📊',
      title: 'Insights and analytics',
      description: 'Enterprise Plan - Fast-track goals with advanced insights plus a dedicated customer success team to help drive effective learning.',
      details: 'Advanced analytics to track progress and insights to improve learning outcomes for your organization.',
      linkText: 'Find out more'
    },
    {
      id: 4,
      icon: '⚙️',
      title: 'Customizable content',
      description: 'Enterprise Plan - Create tailored learning paths for team and organization goals and even host your own content and resources.',
      details: 'Flexible content customization for your team’s unique training requirements, including hosting your own content.',
      linkText: 'Find out more'
    }
  ];

  selectFeature(feature: Feature) {
    this.selectedFeature = feature;
  }
}