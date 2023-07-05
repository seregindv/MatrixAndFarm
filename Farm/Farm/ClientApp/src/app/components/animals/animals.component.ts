import { Component, OnInit } from '@angular/core';
import { AnimalService } from 'src/app/services/animal.service';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.css']
})
export class AnimalsComponent implements OnInit {
  constructor(private _animalService: AnimalService) { }

  animals: string[] = [];
  statusText = '';

  addAnimal() {
    this.resetStatus();
    const name = prompt("Enter animal name");
    if (!name) {
      return;
    }
    this._animalService.create(name).subscribe({
      next: () => this.refresh(),
      error: err => this.setError(err.status === 409 ? 'Animal already exists' : 'Error adding animal')
    });
  }

  deleteAnimal(name: string) {
    this.resetStatus();
    this._animalService.delete(name).subscribe({
      next: () => this.refresh(),
      error: err => {
        if (err.status === 404) {
          this.refresh();
        } else {
          this.setError('Error deleting animal');
        }
      }
    });
  }

  ngOnInit(): void {
    this.refresh();
  }

  private refresh() {
    this.resetStatus();
    this._animalService.getAll().subscribe({
      next: animals => this.animals = animals.sort((a, b) => (a || '').localeCompare(b)),
      error: () => this.setError('Error loading animals')
    });
  }

  private resetStatus() {
    this.statusText = '';
  }

  private setError(text: string) {
    this.statusText = text;
  }
}
