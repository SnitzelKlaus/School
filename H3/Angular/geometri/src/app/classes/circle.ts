import { Shape } from "./shape";
export class Circle extends Shape {
    constructor(public radius: number) {
        super("Circle");
    }
    getArea(): number {
        return Math.PI * this.radius * this.radius;
    }
    getPerimeter(): number {
        return 2 * Math.PI * this.radius;
    }
}