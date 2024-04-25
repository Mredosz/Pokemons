import {Component, Input, OnInit} from '@angular/core';
import {PokemonSummary} from "../../contracts/pokemon-summary";
import {PokemonService} from "../../services/pokemon.service";
import {ActivatedRoute, Router} from "@angular/router";
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.component.html',
  styleUrl: './pokemon-list.component.css'
})
export class PokemonListComponent implements OnInit {

  pokemons: PokemonSummary[];

  constructor(private pokemonService: PokemonService, private router: Router) {
  }

  ngOnInit(): void {
    this.getPokemonList();
    this.refreshPageOnce();
  }

  private getPokemonList() {
    this.pokemonService.getPokemonList().subscribe({
      next: p => this.pokemons = p,
      error: err => console.log(err)
    })
  }

  refreshPageOnce(): void {
    if (typeof(Storage) !== "undefined") {
      if (!localStorage.getItem(`alreadyRefreshed`)) {
        localStorage.setItem(`alreadyRefreshed`, 'true');
        window.location.reload();
      } else {
        localStorage.removeItem(`alreadyRefreshed`);
      }
    }
  }

  pokemonDetails(id: number) {
    this.router.navigate(['/pokemon', id]);
  }
}
