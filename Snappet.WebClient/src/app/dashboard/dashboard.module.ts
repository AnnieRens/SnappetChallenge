import {RouterModule, Routes} from '@angular/router';
import {ClassWorkProgressComponent} from './class-work-progress/class-work-progress.component';
import {NgModule} from '@angular/core';
import {ClassWorkProgressService} from './services/class-work-progress.service';
import {CommonModule} from '@angular/common';

const routes: Routes = [
  {
    path: '',
    component: ClassWorkProgressComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  declarations: [
    ClassWorkProgressComponent
  ],
  exports: [RouterModule],
  providers: [ClassWorkProgressService]
})
export class DashboardModule {
}
