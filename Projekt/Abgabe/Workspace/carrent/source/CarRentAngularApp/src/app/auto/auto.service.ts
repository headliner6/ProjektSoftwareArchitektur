import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

export interface Car {

}

@Injectable()
export class CarService {
    constructor(private http:HttpClient) {}

    // getAllCars(): Observable<Car[]> {
    //     return this.http.get<Car>('https://localhost:44395/api/Car');
    // }
}