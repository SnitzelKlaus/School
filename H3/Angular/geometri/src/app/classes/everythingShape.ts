import { Shape } from "./shape";
export class EverythingShape extends Shape {
    constructor(public radius: number, public height: number, public width: number, public length: number, public base: number, public sideA: number, public sideB: number, public sideC: number, public sideD: number) {
        super("EverythingShape");
    }
    getArea(): number {
        let s: number = (this.sideA + this.sideB - this.sideC + this.sideD) / 2;
        let h: number = Math.sqrt((s - this.sideA) * (s - this.sideB) * (s - this.sideC) * (s - this.sideD));
        
        return ((this.sideA + this.sideC) / 2) * h + this.height * this.width + this.radius * this.radius * Math.PI + this.length * this.base;
    }
    getPerimeter(): number {
        return this.sideA + this.sideB + this.sideC + this.sideD + this.height + this.width + this.radius + this.length + this.base;
    }
}
