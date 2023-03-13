import { Component } from '@angular/core';
import { Shape } from 'src/app/classes/shape';
import { Parallelogram } from 'src/app/classes/parallelogram';
import { Rectangle } from 'src/app/classes/rectangle';
import { Square } from 'src/app/classes/square';
import { Trapez } from 'src/app/classes/trapez';
import { Triangle } from 'src/app/classes/triangle';

@Component({
  selector: 'app-geometry',
  templateUrl: './geometry.component.html',
  styleUrls: ['./geometry.component.css']
})

export class GeometryComponent {
  title = 'Geometry';

  width: number = 0;
  height: number = 0;
  length: number = 0;
  base: number = 0;
  sideA: number = 0;
  sideB: number = 0;
  sideC: number = 0;
  sideD: number = 0;

  selectedShape: Parallelogram | Rectangle | Square | Trapez | Triangle | undefined;

  shapes: Shape[] = [
    new Parallelogram(0, 0, 0),
    new Rectangle(0, 0),
    new Square(0),
    new Trapez(0, 0, 0, 0),
    new Triangle(0, 0)
  ];

  onSelect(shape: Parallelogram | Rectangle | Square | Trapez | Triangle): void {
    this.selectedShape = shape;
  }

  onCalculate(): void {
    if (this.selectedShape instanceof Parallelogram) {
      this.selectedShape.length = this.length;
      this.selectedShape.height = this.height;
      this.selectedShape.width = this.width;
    } else if (this.selectedShape instanceof Rectangle) {
      this.selectedShape.length = this.length;
      this.selectedShape.width = this.width;
    } else if (this.selectedShape instanceof Square) {
      this.selectedShape.length = this.length;
    } else if (this.selectedShape instanceof Trapez) {
      this.selectedShape.a = this.sideA;
      this.selectedShape.b = this.sideB;
      this.selectedShape.c = this.sideC;
      this.selectedShape.d = this.sideD;
    } else if (this.selectedShape instanceof Triangle) {
      this.selectedShape.base = this.base;
      this.selectedShape.height = this.height;
    }
  }
}
