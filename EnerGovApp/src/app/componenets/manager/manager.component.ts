import { Component, EventEmitter, forwardRef, Output } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Employee } from 'src/app/common/employee';
import { EmployeeService } from 'src/app/employee.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css'],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => ManagerComponent),
    multi: true
  }]
})
export class ManagerComponent implements ControlValueAccessor {

  @Output() managerId = new EventEmitter<number>();
  colorControl = new FormControl('primary' as any);
  managers: Employee[] = [];

  constructor(private service: EmployeeService) {
    this.service.getAll()
    .subscribe(posts => this.managers = posts as Employee[]);

    this.colorControl.valueChanges.subscribe((value) => {
      this._onChange(value);
      this._onTouched();
      this.managerId.emit(value);
    })
  }

  public writeValue(obj: any): void {
      
  }

  private _onChange = (value: any) => undefined;
  public registerOnChange(fn: any): void {
      this._onChange = fn;
  }

  private _onTouched = () => undefined;
  public registerOnTouched(fn: any): void {
      this._onTouched = fn;
  }
}
