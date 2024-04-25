import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PokemonListComponent} from "./pokemon-components/pokemon-list/pokemon-list.component";
import {PokemonDetailsComponent} from "./pokemon-components/pokemon-details/pokemon-details.component";

const routes: Routes = [
  {path: 'pokemons', component: PokemonListComponent, title: 'Pokemon list'},
  {path: 'pokemon/:id', component: PokemonDetailsComponent, title: 'Pokemon details'},
  {path: '', component: PokemonListComponent, pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
