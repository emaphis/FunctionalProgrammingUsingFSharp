# 3.6 Locally declared identifiers

For functions and variables only useful for the definition of a function it's convenient to declare identifiers locally.

The expression $b \cdot b - 4.0 \cdot a \cdot c$ is evaluated and declared three times in `solve`. This is bad from a readability and efficiency view.

Declare a local identifier for `discrimanent`.

```fsharp
let solve (a, b, c) =
    let disc = b*b - 4.0 * a * c
    if disc < 0.0 || a = 0.0
    then  failwith "discriminant is negative or a=0.0"
    else
        ((-b + sqrt disc) / (2.0 * a),
         (-b - sqrt disc) / (2.0 * a))

// val solve: a: float * b: float * c: float -> float * float
```

The `sqrt disc` is calculated twice so fold it into it's own declaration `sqrtD`

```fsharp
let solve (a, b, c) =
    let disc = b*b - 4.0 * a * c
    if disc < 0.0 || a = 0.0
    then  failwith "discriminant is negative or a=0.0"
    else 
        let sqrtD = sqrt disc
        ((-b + sqrtD) / (2.0 * a), (-b - sqrtD) / (2.0 * a))

// val solve: a: float * b: float * c: float -> float * float
```
