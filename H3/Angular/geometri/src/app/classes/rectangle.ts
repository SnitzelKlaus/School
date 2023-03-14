import { Shape } from "./shape";
export class Rectangle extends Shape {
    constructor(public height: number, public width: number) {
        super("Rectangle");
    }
    getArea(): number {
        return this.height * this.width;
    }
    getPerimeter(): number {
        return 2 * (this.height + this.width);
    }
}
