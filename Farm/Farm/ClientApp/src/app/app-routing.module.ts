import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimalsComponent } from './components/animals/animals.component';

const routes: Routes = [
  { path: "", redirectTo: "animals", pathMatch: "full" },
  { path: "animals", component: AnimalsComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
