import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from './restaurant.model';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class RestaurantService {
    constructor(private httpClient: HttpClient) {

    }

    searchByText(text: string): Observable<Restaurant[]> {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Access-Control-Allow-Origin', '*');

        return this.httpClient.get<Restaurant[]>(environment.apiUrl + `/restaurant?text=${text}` , { headers });
    }
}