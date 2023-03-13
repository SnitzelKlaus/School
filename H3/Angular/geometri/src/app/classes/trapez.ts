import { Shape } from "./shape";
export class Trapez extends Shape {
    constructor(public a: number, public b: number, public c: number, public d: number) {
        super("Trapez");
    }
    getArea(): number {
        let s: number = (this.a + this.b - this.c + this.d) / 2;
        let h: number = Math.sqrt((s - this.a) * (s - this.b) * (s - this.c) * (s - this.d));
        
        return ((this.a + this.c) / 2) * h;
    }
    getPerimeter(): number {
        return this.a + this.b + this.c + this.d;
    }
}