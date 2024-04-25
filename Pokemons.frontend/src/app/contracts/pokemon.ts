import {PokemonSummary} from "./pokemon-summary";
import {Stats} from "./stats";

export class Pokemon extends PokemonSummary{
  weight: number;
  height: number;
  generation: string;
  types: string[];
  stats: Stats[];
  abilities: string[];
}
