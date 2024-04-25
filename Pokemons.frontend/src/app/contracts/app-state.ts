import {Status} from "../enums/status";

export interface AppState<T> {
  status: Status;
  appData?: T;
}
