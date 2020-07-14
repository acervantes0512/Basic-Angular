import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.Service';
import { Observable } from 'rxjs';
import { IInfoEmployee } from '../shared/Components/i-info-employee';


@Component({
  selector: 'app-home',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {

  employeeRequest$: Observable<Array<IInfoEmployee>>;
  conversion:any;
  rta:Array<IInfoEmployee> = new Array<IInfoEmployee>();

  constructor(
    private employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
  }

  getAllEmployees(){
    
    
    
    this.employeeRequest$ = this.employeeService.getAllEmployees()
      this.employeeRequest$.subscribe(
        (datos) => {

          if(datos == null){
            this.rta = new Array<IInfoEmployee>();
          } else
          {
            this.rta = datos;
          }
      }, 
      (err) => {
        console.log(err['error']);
      }

    );
    }

    getEmployee(codEmp:string){
      this.employeeRequest$ = this.employeeService.getEmployee(codEmp)
        this.employeeRequest$.subscribe(
          (datos) => {

            if(datos == null){
              this.rta = new Array<IInfoEmployee>();
            } else
            {
              this.rta = datos;
            }

        }, 
        (err) => {
          console.log(err['error']);
        }
  
      );
    }

    clickButton(data){
      
      if(data.idEmpleado == ""){
        this.getAllEmployees();
      }else
      {
        this.getEmployee(data.idEmpleado);
      }

    }

}


