import { Component } from '@angular/core';
import { Shape } from 'src/app/classes/shape';
import { Parallelogram } from 'src/app/classes/parallelogram';
import { Rectangle } from 'src/app/classes/rectangle';
import { Square } from 'src/app/classes/square';
import { Trapez } from 'src/app/classes/trapez';
import { Triangle } from 'src/app/classes/triangle';
import { Circle } from 'src/app/classes/circle';
import { EverythingShape } from 'src/app/classes/everythingShape';

@Component({
  selector: 'app-geometry',
  templateUrl: './geometry.component.html',
  styleUrls: ['./geometry.component.css']
})

export class GeometryComponent {
  title = 'Geometry';

  //selectedShape: Parallelogram | Rectangle | Square | Trapez | Triangle | Circle | undefined;
  selectedShape: EverythingShape | undefined;

  shapes: Shape[] = [
    new Parallelogram(0, 0, 0),
    new Rectangle(0, 0),
    new Square(0),
    new Trapez(0, 0, 0, 0),
    new Triangle(0, 0),
    new Circle(0)
  ];
}
