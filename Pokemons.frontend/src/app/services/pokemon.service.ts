import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PokemonSummary} from "../contracts/pokemon-summary";
import {Pokemon} from "../contracts/pokemon";

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  private baseURL = "http://localhost:5043/pokemons";

  constructor(private httpClient: HttpClient) { }

  getPokemonList(): Observable<PokemonSummary[]>{
    return this.httpClient.get<PokemonSummary[]>(this.baseURL);
  }

  getPokemon(id: number): Observable<Pokemon>{
    return this.httpClient.get<Pokemon>(this.baseURL + '/' + id);
  }
}
