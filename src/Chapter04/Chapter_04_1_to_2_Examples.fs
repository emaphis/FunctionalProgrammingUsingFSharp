module Chapter04.Chapter_04_1_to_2_Examples

// Examples from sections 4.1 to 4.2 - List examples

// Lists as values:

let xs = [2;3;2];;
//val xs: int list = [2; 3; 2]

let ys = ["Big"; "Mac"];;
//val ys: string list = ["Big"; "Mac"]

let ps = [("b",2);("c",3);("e",5)];;
// val ps: (string * int) list = [("b", 2); ("c", 3); ("e", 5)]

// list of records
type P = {name: string; age: int}

let rs = [{name = "Brown"; age = 25}; {name = "Cook"; age = 45}];;
//val rs: P list = [{ name = "Brown" age = 25 }; { name = "Cook"  age = 45 }]

// list of functions

let fs =  [sin; cos];;
// al fs: (float -> float) list = [<fun:fs@23>; <fun:fs@23-1>]

// Lists can be components of other objects

let p2 = ("bce", [2;3;5]);;
//val p2: string * int list = ("bce", [2; 3; 5])


// The type constructor of `list`

// all the elements of a list must have the same type.
//let lst1 = ["a";1];;
//error FS0001: All elements of a list must be implicitly convertible to the type of the first element, which here is 'string'. This element has type 'int'.


// Equality of lists.
// Lists must be the same type and the same length and the elements in the same order.

let eq1 = [2;3;2] = [2;3];;
//val eq1: bool = false

let eq2 = [2;3;2] = [2;3;3];;
//val eq2: bool = false

// Liats of functions can't be compared
//let eq3 = [sin; cos] = [];;
// Error FS0001: The type '('a -> 'a)' does not support the 'equality' constraint because it is a function type


// Ordering of lists.
// Lists of the same type are ordered lexicographically

// 1 The list xs is a proper prefix of ys

let eq3 = [1; 2; 3] < [1; 2; 3; 4];;
//val eq3: bool = true

let eq4 = ['1'; '2'; '3'] < ['1'; '2'; '3'; '4'];;
//val eq4: bool = true

// the empty list is smaller than any non-empty list:
let eq5 =  [] < [1; 2; 3];;
//val eq5: bool = true

let eq6 = [] < [[]; [(true,2)]];;
//val eq6: bool = true


// The lists agree on the first k elements and xk+1 <yk+1.

let eq7 = [1; 2; 3; 0; 9; 10] < [1; 2; 3; 4];;
//val eq7: bool = tru

let eq8 = ["research"; "articles"] < ["research"; "books"];;
// val eq8: bool = true

// Other relation operators

let eq9 = [1; 1; 6; 10] >= [1; 2];;
//val eq9: bool = false

// Dotnet's `compare operator
let cmp0 = compare [1; 1; 6; 10] [1; 2];;
//val cmp0: int = -1

let cmp1 = compare [1;2] [1; 1; 6; 10];;
//val cmp1: int = 1


//////////////////////////////
//  4.2 Construction and decomposition of lists

// The `cons` operator

let x1 = 2::[3;4;5];;
//val x1: int list = [2; 3; 4; 5]

let y1 = ""::[];;
//val y1: string list = [""]

// the :: operator associates right.
let z1 =  2::3::[4;5];;
//val z1: int list = [2; 3; 4; 5]


// List patterns

 let x2 :: xs2 = [1;2;3];;
//warning FS0025: Incomplete pattern matches on this expression. For example, the value '[]' may indicate a case not covered by the pattern(s).
//val xs2: int list = [2; 3]
//val x2: int = 1

//let [n0, n1; n2] = [(1,true); (2,false); (3, false)];;

let m0::m1::ms = [1.1; 2.2; 3.3; 4.4; 5.5];;
//val ms: float list = [3.3; 4.4; 5.5]
//val m1: float = 2.2
//val m0: float = 1.1

let (o1, o2)::os = [(1,[1]); (2, [2]); (3, [3]); (4,[4])];;
//val os: (int * int list) list = [(2, [2]); (3, [3]); (4, [4])]
//val o2: int list = [1]
//val o1: int = 1


// Simple list expressions - Range expressions
 let lst0 = [ -3 .. 5 ];;
 //val lst0: int list = [-3; -2; -1; 0; 1; 2; 3; 4; 5]
 
 let lst1 = [ 2.4 .. 3.0 ** 1.7 ];;
//val lst1: float list = [2.4; 3.4; 4.4; 5.4; 6.4]

// where:
let flt0 = 3.0 ** 1.7;;
//val flt0: float = 6.47300784

//[b .. s .. e]
let lst2 = [6 .. -1 .. 2];;
//val lst2: int list = [6; 5; 4; 3; 2]

// 0,π/2,π,3/2π,2π
let lst3 = [0.0 .. System.Math.PI/2.0 .. 2.0*System.Math.PI];;
//val lst3: float list = [0.0; 1.570796327; 3.141592654; 4.71238898; 6.283185307]

//let lst4 = [0 .. 0 .. 0];;
//System.ArgumentException: The step of a range cannot be zero. (Parameter 'step')
