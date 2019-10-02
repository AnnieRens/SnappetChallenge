import {RouterModule, Routes} from '@angular/router';
import {ClassWorkProgressComponent} from './components/class-work-progress/class-work-progress.component';
import {NgModule} from '@angular/core';
import {ClassWorkProgressService} from './services/class-work-progress.service';
import {CommonModule} from '@angular/common';
import { DashboardHeaderComponent } from './components/dashboard-header/dashboard-header.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  declarations: [
    ClassWorkProgressComponent,
    DashboardHeaderComponent,
    DashboardComponent
  ],
  exports: [RouterModule],
  providers: [ClassWorkProgressService]
})
export class DashboardModule {
}
