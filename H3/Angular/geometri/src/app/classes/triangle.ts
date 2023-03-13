import { Shape } from "./shape";
export class Triangle extends Shape {
    constructor(public base: number, public height: number) {
        super("Triangle");
    }
    getArea(): number {
        return 0.5 * this.base * this.height;
    }
    getPerimeter(): number {
        return this.base + this.height + Math.sqrt(Math.pow(this.base, 2) + Math.pow(this.height, 2));
    }
}