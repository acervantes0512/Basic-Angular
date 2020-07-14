import { RouterModule, Routes } from "@angular/router";
import { EmployeeComponent } from './components/employee/employee.component';

// en este arreglo van todas las rutas
const APP_ROUTES: Routes = [
    { path: 'home', component: EmployeeComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, {useHash:true});