import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AnimalService {
  constructor(private _httpClient: HttpClient) { }

  private _address = "api/animal";

  getAll() {
    return this._httpClient.get<string[]>(this._address);
  }

  create(animal: string) {
    return this._httpClient.post(this._address, { name: animal });
  }

  delete(animal: string) {
    return this._httpClient.delete(`${this._address}/${animal}`);
  }
}
