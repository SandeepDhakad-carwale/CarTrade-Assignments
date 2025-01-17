import { expect } from "vitest";
import sum from "../utils/sum";

test("sum test",()=>{
    const a=3;
    const b=2;
    const res=sum(a,b);
    expect(res).toBe(a+b);
})