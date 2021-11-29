import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from "./components/views/index/index.component";
import { HomeUsuarioComponent } from "./components/views/usuario/home-usuario/home-usuario.component";
import { CadastrarUsuarioComponent } from './components/views/usuario/cadastrar-usuario/cadastrar-usuario.component';

const routes: Routes = [
  {
    path: "",
    component: IndexComponent,
  },
  {
      path: "usuario/home",
      component: HomeUsuarioComponent,
  },
  {
    path: "usuario/cadastrar",
    component: CadastrarUsuarioComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
