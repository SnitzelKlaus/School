import { Shape } from "./shape";
export class Square extends Shape {
    constructor(public length: number) {
        super("Square");
    }
    getArea(): number {
        return this.length * this.length;
    }
    getPerimeter(): number {
        return 4 * this.length;
    }
}