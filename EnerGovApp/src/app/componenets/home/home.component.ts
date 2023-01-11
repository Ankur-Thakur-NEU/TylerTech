import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/common/employee';
import { EmployeeService } from 'src/app/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  displayedColumns: string[] = ['employeeId', 'lastName', 'firstName'];
  colorControl = new FormControl('primary' as ThemePalette);
  dataSource: Employee[] = [];

  constructor(private service: EmployeeService,
    private router: Router) {
  }

  getEmployeeForManager(managerId: any): void {
    this.service.getAllById(managerId).subscribe((value) => {
      this.dataSource = value as Employee[];
    });
  }

  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
  }
}
