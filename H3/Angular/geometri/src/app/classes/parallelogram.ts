import { Shape } from "./shape";
export class Parallelogram extends Shape {
    constructor(public length: number, public width: number, public height: number) {
        super("Parallelogram");
    }
    getArea(): number {
        return this.length * this.height;
    }
    getPerimeter(): number {
        return 2 * (this.length + this.width);
    }
}