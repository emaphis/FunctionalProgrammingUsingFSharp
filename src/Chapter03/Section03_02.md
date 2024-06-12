# 3.2 Polymorphism

Consider the function `swap` interchanging compentents of a pair.

```fsharp
let swap (x,y) = (y,x);;
// val swap: x: 'a * y: 'b -> 'b * 'a

swap('a', "ab");;
// val it: string * char = ("ab", 'a')

swap ((1,3),("ab",true));;
// val it: (string * bool) * (int * int) = (("ab", true), (1, 3))
```

Swap has two different type variables $'a$ $'b$.  Type variables cans stand in for many types in polymorphic functions

`fst` and `sdn` are two built in functions that operate on tuples.

$$
fst : \space 'a \space * \space 'b \space -> \space 'a \quad \text{  and  } \quad snd : \space 'a \space * \space -> \space 'b
$$

they select the first and second components, for example:

```fsharp
fst((1,"a",true), "xyz");;
// val it: int * string * bool = (1, "a", true)

snd('z', ("abc", 3.0));;
// val it: string * float = ("abc", 3.0)
```
