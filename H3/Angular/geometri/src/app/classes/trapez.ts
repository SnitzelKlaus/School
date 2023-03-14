import { Shape } from "./shape";
export class Trapez extends Shape {
    constructor(public sideA: number, public sideB: number, public sideC: number, public sideD: number) {
        super("Trapez");
    }
    getArea(): number {
        let s: number = (this.sideA + this.sideB - this.sideC + this.sideD) / 2;
        let h: number = Math.sqrt((s - this.sideA) * (s - this.sideB) * (s - this.sideC) * (s - this.sideD));
        
        return ((this.sideA + this.sideC) / 2) * h;
    }
    getPerimeter(): number {
        return this.sideA + this.sideB + this.sideC + this.sideD;
    }
}