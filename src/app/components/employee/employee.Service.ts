import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { map, share } from 'rxjs/operators';
import { ConfigService } from 'src/app/app-config.service';
import { IInfoEmployee } from '../shared/Components/i-info-employee';
import { IEmployeeResponse } from '../shared/Components/models/i-employeeResponse';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  api: any;
  empObj: any;

  constructor(
    private http: HttpClient,
    private configService: ConfigService
  ) {

  }

  getEmployee(codSolicitud : string): Observable<Array<IInfoEmployee>> {

    return this.http.get<Array<IInfoEmployee>>("http://localhost:59213/api/Employees/getEmployee?idEmployee="+codSolicitud).pipe(
      map((res: any) => JSON.parse(res.data['Data'])),
      share(),
    );
  }

  getAllEmployees(): Observable<Array<IInfoEmployee>> {

    return this.http.get<Array<IInfoEmployee>>("http://localhost:59213/api/Employees/getAllEmployees").pipe(
      map((res: any) => JSON.parse(res.data['Data'])),
      share(),
    );
  }

}
