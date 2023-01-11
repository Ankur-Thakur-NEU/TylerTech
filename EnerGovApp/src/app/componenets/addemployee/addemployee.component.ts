import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/employee.service';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';


export interface Role {
  id: number,
  name: string
}

@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  styleUrls: ['./addemployee.component.css']
})
export class AddemployeeComponent implements OnInit {
  employeeForm: FormGroup;
  submitted = false;

  roles: Role[] = [];

  
  constructor(private fb: FormBuilder,
    private service: EmployeeService,
    private router: Router,
    private _snackBar: MatSnackBar) {
    this.employeeForm = this.fb.group({
      managerId: new FormControl('', [Validators.required]),
      employeeId: new FormControl('', [Validators.required,Validators.pattern("^[0-9]*$")]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      roles: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit() {
    this.service.getAllRoles()
    .subscribe(posts => this.roles = posts as Role[]);
  }

  get employeeFormControl() { return this.employeeForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.employeeForm.valid) {
      this.service.create(JSON.stringify(this.employeeForm.value))
      .subscribe(employee => {
        this.employeeForm.reset();
        const addedEmployee = employee as any;
        // alert(`Employee with ID ${addedEmployee.employeeId} saved`);
        this.openSnackBar();
        this.goToHomePage();
      });
    }
  }

  goToHomePage(){
    this.router.navigate([``]);
  }

  onCancel() {
    this.employeeForm.reset();
  }

  getManagerId(managerId: any): void {
    this.employeeFormControl['managerId'].setValue(managerId);
  }

  openSnackBar() {
    this._snackBar.openFromComponent(SnackBarComponent, {
      duration: 5000,
    });
  }
}
