// footer.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent {
  footerSections = [
    {
      title: 'About',
      links: [
        { text: 'About us', url: '/about' },
        { text: 'Careers', url: '/careers' },
        { text: 'Contact us', url: '/contact' }
      ]
    },
    {
      title: 'Discover',
      links: [
        { text: 'Get the app', url: '/mobile' },
        { text: 'Teach on Udemy', url: '/teaching' },
        { text: 'Plans and Pricing', url: '/pricing' }
      ]
    },
    {
      title: 'Udemy for Business',
      links: [
        { text: 'Udemy Business', url: '/business' }
      ]
    },
    {
      title: 'Legal & Accessibility',
      links: [
        { text: 'Accessibility statement', url: '/accessibility' },
        { text: 'Privacy policy', url: '/privacy' },
        { text: 'Sitemap', url: '/sitemap' }
      ]
    }
  ];

  currentYear = new Date().getFullYear();
}