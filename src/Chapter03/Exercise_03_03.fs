module Chapter03.Exercise_03_03

(*
Exercise 3.3
  The set of complex numbers is the set of pairs of real numbers. Complex numbers behave almost
  like real numbers if addition and multiplication are defined by:

        (a,b) + (c,d) = (a+c, b+d)
        (a,b) * (c,d) = (ac−bd, bc+ad)

  1. Declare suitable infix functions for addition and multiplication of complex numbers.

  2. The inverse of (a,b) with regard to addition, that is,−(a,b), is (−a,−b), and the inverse of
     (a,b) with regard to multiplication, that is, 1/(a,b), is (a/(a2+b2), −b/(a2+b2)) (provided
     that 'a'  and 'b' are not both zero). Declare infix functions for subtraction and division of complex
     numbers.

  3. Use let-expressions in the declaration of the division of complex numbers in order to avoid
     repeated evaluation of identical subexpressions.
*)

// 1. Add and multiply

type Complex = float * float

let addComplex (cmpx1: Complex) (cmpx2: Complex) : Complex =
    let a, b = cmpx1
    let c, d = cmpx2
    (a + c, b + d)

let multComplex (cmpx1: Complex) (cmpx2: Complex) : Complex =
    let a, b = cmpx1
    let c, d = cmpx2
    (a * c - b * d, b * c + a * d)


let ( +. ) cmpx1 cmpx2 = addComplex cmpx1 cmpx2

let ( *. ) cmpx1 cmpx2 = multComplex cmpx1 cmpx2


// 2. Subract and divide
// 3. Use 'let' to abstract common subexpressions

let subtractComplex (cmpx1: Complex) (cmpx2: Complex): Complex =
    let a, b = cmpx1
    let c, d = cmpx2
    (a - c, b - d)

let divideComplex (cmpx1: Complex) (cmpx2: Complex): Complex =
    let a, b = cmpx1
    let c, d = cmpx2
    let div = (c * c + d * d)
    ((a * c + b * d) / div, ((b * c - a * d) / div))

let ( -. ) cmpx1 cmpx2 = subtractComplex cmpx1 cmpx2

let ( /. ) cmpx1 cmpx2 = divideComplex cmpx1 cmpx2
