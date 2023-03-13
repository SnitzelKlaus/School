import { Shape } from "./shape";
export class Rectangle extends Shape {
    constructor(public length: number, public width: number) {
        super("Rectangle");
    }
    getArea(): number {
        return this.length * this.width;
    }
    getPerimeter(): number {
        return 2 * (this.length + this.width);
    }
}
