import { HttpClient } from '@angular/common/http';
import { Component, inject, input, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { environment } from '../../../../environments/environment';
import { NgIf } from '@angular/common';
import { ButtonModule } from 'primeng/button';

export interface IKeysConfig {
  key?: string;
  label: string;
  type?:
    | 'money'
    | 'text'
    | 'date'
    | 'image'
    | 'tag'
    | 'rating'
    | 'status'
    | 'video'
    | 'array'
    | 'link';
  tags?: { label: string; value: any; color: string; bgColor: string }[];
  statuses?: { label: string; value: any; color: string; bgColor: string }[];
  items?: IKeysConfig[];
  value?: any;
  route?: string;
}

@Component({
  selector: 'app-record-details',
  imports: [NgIf, RouterLink, ButtonModule],
  templateUrl: './record-details.component.html',
  styleUrl: './record-details.component.scss',
})
export class RecordDetailsComponent {
  item = signal<any>({});

  KeysConfig = input.required<IKeysConfig[]>();
  apiRoute = input.required<string>();

  sideBarConfig = input<{ title: string; items: IKeysConfig[] } | null>(null);

  activatedRoute = inject(ActivatedRoute);
  httpClient = inject(HttpClient);
  router = inject(Router);

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      const id = params['id'];
      this.httpClient
        .get(`${environment.apiUrl}/${this.apiRoute()}`)
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

  handleNavigation(KeyConfig: IKeysConfig) {
    //get value from key like {key.key}

    let keys = KeyConfig.key?.split('.') ?? [];
    let value = this.item();

    for (var key of keys) {
      console.log('key', key);
      console.log('pre value', value);
      value = value[key];
      console.log('next value', value);
    }

    //route like tttt/:id/tttt

    let newRoute;
    if (KeyConfig.route!.includes(':')) {
      newRoute = KeyConfig.route?.replace(`:${KeyConfig.key}`, `${value}`);
    }else{
      newRoute = KeyConfig.route + `/${value}`;
    }

    this.router.navigate([newRoute]);
  }
}
