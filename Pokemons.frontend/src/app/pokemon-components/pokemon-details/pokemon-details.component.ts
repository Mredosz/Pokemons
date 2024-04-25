import { Component, OnInit} from '@angular/core';
import {Pokemon} from "../../contracts/pokemon";
import {ActivatedRoute, Router} from "@angular/router";
import {PokemonService} from "../../services/pokemon.service";
import {Colors} from "../../contracts/colors";

@Component({
  selector: 'app-pokemon-details',
  templateUrl: './pokemon-details.component.html',
  styleUrl: './pokemon-details.component.css'
})
export class PokemonDetailsComponent implements OnInit {

  id: number;
  pokemon: Pokemon;
  statsColor : Colors[] = [
    {name: 'hp', color: '#FD0000'},
    {name: 'attack', color: '#F1802E'},
    {name: 'defense', color: '#F8D030'},
    {name: 'special-attack', color: '#6890EB'},
    {name: 'special-defense', color: '#75C853'},
    {name: 'speed', color: '#F6588B'},
  ];
  typesColor : Colors[] = [
    {name: 'fighting', color: '#CE416B'},
    {name: 'flying', color: '#8FA9DE'},
    {name: 'poison', color: '#AA6BC8'},
    {name: 'ground', color: '#D97845'},
    {name: 'rock', color: '#C5B78C'},
    {name: 'bug', color: '#91C12F'},
    {name: 'ghost', color: '#5269AD'},
    {name: 'steel', color: '#5A8EA2'},
    {name: 'fire', color: '#FF9D55'},
    {name: 'water', color: '#5090D6'},
    {name: 'grass', color: '#63BC5A'},
    {name: 'electric', color: '#F4D23C'},
    {name: 'psychic', color: '#FA7179'},
    {name: 'ice', color: '#73CEC0'},
    {name: 'dragon', color: '#0B6DC3'},
    {name: 'dark', color: '#5A5465'},
    {name: 'fairy', color: '#EC8FE6'},
    {name: 'normal', color: '#929DA3'},
  ]


  constructor( private route: ActivatedRoute, private pokemonService: PokemonService, private router: Router) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get('id'))
      this.getPokemonDetails(this.id);
      this.refreshPageOnce();
    });
  }

  getPokemonDetails(id: number): void {
    this.pokemon = new Pokemon();
    this.pokemonService.getPokemon(id)
      .subscribe(pokemon => this.pokemon = pokemon);
  }

  refreshPageOnce(): void {
    if (typeof(Storage) !== "undefined") {
      if (!localStorage.getItem(`alreadyRefreshed-${this.id}`)) {
        localStorage.setItem(`alreadyRefreshed-${this.id}`, 'true');
        window.location.reload();
      } else {
        localStorage.removeItem(`alreadyRefreshed-${this.id}`);
      }
    }
  }

  pokemonList() {
    this.router.navigate(['/pokemons']);
  }
}
