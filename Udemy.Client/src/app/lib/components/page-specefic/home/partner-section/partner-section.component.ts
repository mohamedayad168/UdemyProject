import { CommonModule } from '@angular/common';
import { Component ,OnInit} from '@angular/core';

@Component({
  selector: 'app-partner-section',
  imports: [CommonModule],
  templateUrl: './partner-section.component.html',
  styleUrl: './partner-section.component.css'
})
export class PartnerSectionComponent  implements OnInit {
  logos: string[] = [
  'assets/logos/volkswagen_logo.svg',
  'assets/logos/samsung_logo.svg',
  'assets/logos/hewlett_packard_enterprise_logo.svg',
  'assets/logos/cisco_logo.svg',
  'assets/logos/vimeo_logo_resized-2.svg',
  'assets/logos/procter_gamble_logo.svg',
  'assets/logos/citi_logo.svg',
  'assets/logos/ericsson_logo.svg' ];

  constructor() {}

  ngOnInit(): void {}

}
