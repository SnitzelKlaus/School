import { Shape } from "./shape";
export class Square extends Shape {
    constructor(public width: number) {
        super("Square");
    }
    getArea(): number {
        return this.width * this.width;
    }
    getPerimeter(): number {
        return 4 * this.width;
    }
}