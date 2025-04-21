import { HttpClient } from '@angular/common/http';
import { Component, inject, input, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../../../../environments/environment';

export interface IKeysConfig {
  key: string;
  label: string;
  type: 'money' | 'text' | 'date' | 'image' | 'tag' | 'rating' | 'status';
  tags?: { label: string; value: any; color: string; bgColor: string }[];
  statuses?: { label: string; value: any; color: string; bgColor: string }[];
}

@Component({
  selector: 'app-record-details',
  imports: [],
  templateUrl: './record-details.component.html',
  styleUrl: './record-details.component.scss',
})
export class RecordDetailsComponent {
  item = signal<any>({});
  
  KeysConfig = input.required<IKeysConfig[]>();
  apiRoute = input.required<string>();

  activatedRoute = inject(ActivatedRoute);
  httpClient = inject(HttpClient);

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      const id = params['id'];
      this.httpClient
        .get(`${environment.apiUrl}/${this.apiRoute()}/${id}`)
        .subscribe({
          next: (data) => {
            console.log(data);
            this.item.set(data);
          },
          error: (err) => {
            console.error(err);
          },
        });
    });

  }
}
