module Chapter02.Exercise_02_10

(*
    Exercise 2.10
    Consider the following declaration:

        let test(c,e) = if c then e else 0;;
    
    1. What is the type of test?
    2. What is the result of evaluating test(false, fact(-1))?
    3. Compare this with the result of evaluating
        
        if false then fact -1 else 0
*)

// 1. What is the type of test?
// test: bool * int -> int.

// 2. What is the result of evaluating:
// test(false, fact(-1))?

// test(false, fact(-1))
// -> if false then fact(-1) else 0
// -> "StackOverflowException"  due to eager evaluation.

// 3. Compare this with the result of evaluating
//  if false then fact -1 else 0
// -> 0


let testIt(c, e) = if c then e else 0

// val testIt: c: bool * e: int -> int
