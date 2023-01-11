import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AddemployeeComponent } from './componenets/addemployee/addemployee.component';
import { HomeComponent } from './componenets/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'AddEmployee', component: AddemployeeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
