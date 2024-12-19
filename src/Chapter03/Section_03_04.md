# 3.4 Records

Is a data definition facility like a tuple but identifies components with labels instead of position.

Unlike a tuples, records must be defined before it is used:

```fsharp
type Person =
 { age : int; birthday : int * int;
   name : string; sex: string }
```

The keyword `type` indicates that this is a `type declaration`. The `{ }` braces indicate it's a record.

The distinct identifiers are called `record labels` label the components in the type.

Values of type `Person` are created as:

```fsharp
let john = { name = "John"; age = 29;
             sex = "M"; birthday = (2,11) }

val john: Person = { age = 29
                     birthday = (2, 11)
                     name = "John"
                     sex = "M" }
```

The following bindings are created:

$john \mapsto \{ age \mapsto 29, birthday \mapsto (2,11), name \mapsto "John", sex \mapsto "M" \space \}$

Records create local environments. It contains a local binding from label to value.

Individual components can be accessed with dot `.` notation.

```fsharp
let bday = john.birthday
// val bday: int * int = (2, 11)

let sex = john.sex
// val sex: string = "M"
```

## Equality and ordering

Equality of two records with the same type is defined component wise by the equality of each values assigned to the label, so the ordering of components is not important.

```fsharp
john = { name = "John"; age = 29;
         sex = "M"; birthday = (2,11) }
// val it: bool = true
```

Ordering of records is based on lexicographical ordering using the ordering of the labels in the record type declaration

```fsharp
type T1 = {a:int; b:string }
let v1 = {a=1; b="abd"}
let v2 = {a=2; b="ab"}

v1<v2
// val it: bool = true

type T2 = {b:string; a:int}
let v1' = {T2.a=1; b="abc"}
let v2' = {T2.a=2; b="ab"}

v1'>v2'
// val it: bool = true
```

`v1` is smaller than `v2` because the label `a` occurs first in the record type `T1` and `v1.a=1` is smaller than `v2.a=2` while `v1'` is larger than `v2` because the label `b` occurs first in the record type `T2` and it's value is larger.

## Record patterns

A `record pattern` is used to decompose a record into its fields. The pattern:

$$
\space \{ \space name = x; \space age = y; \space sex = s; \space birthday =(d,m) \space \}
$$

Generates bindings for `x, y, s, d` and `m` when matched against a person record.

```fsharp
let sue = { name = "Sue"; age = 19; sex="F";
            birthday = (24, 12) }

let {name = x; age = y; sex = s; birthday = (d,m)} = sue

// val y: int = 19
// val x: string = "Sue"
// val s: string = "F"
// val m: int = 12
// val d: int = 24
```

Records patterns are used in defining functions on records. The declaration
of a function $age$ where the argument is a record of type $Person$:

```fsharp
let age { age = a; name = _; sex = _; birthday = _ } = a
// val age: Person -> int

let isYoungLady { age = a; sex = x; name = _; birthday = _ } =
    a < 25 && s = "F"
// val isYoungLady: Person -> bool

age john
// val it: int = 29

isYoungLady john
// val it: bool = false

isYoungLady sue
// val it: bool = true
```

The type of the above functions can be inferred from the context since `name`, `age`, and so
on are labels of the record type `Person` only.
