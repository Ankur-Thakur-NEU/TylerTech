import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppError } from './common/app-error';
import { NotFoundError } from './common/not-found-error';
import { BadInput } from './common/bad-input-error';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = "https://localhost:7192/api/";

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(`${this.url}Employee`).pipe(
      catchError(this.handleError)
    );
  }

  getAllById(managerId: number) {
    return this.http.get(`${this.url}Employee/${managerId}`).pipe(
      catchError(this.handleError)
    );
  }

  getAllRoles() {
    return this.http.get(`${this.url}Employee/getAllRoles`).pipe(
      catchError(this.handleError)
    );
  }

  create(employee: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post(`${this.url}Employee`, employee, httpOptions).pipe(
      catchError(this.handleError));
  }


  private handleError(error: Response) {
    if (error.status === 400)
      return throwError(new BadInput(error.json()));

    if (error.status === 404)
      return throwError(new NotFoundError());

    return throwError(new AppError(error));
  }

}
