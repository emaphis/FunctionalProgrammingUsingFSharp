module Chapter01.Exercise_08

(*
   Exercise 1.7
   Consider the declarations:

        let a = 5;;
        let f a = a + 1;;
        let g b = (f b) + a;;

    Find the environment obtained from these declarations and write the evaluations of the expres
    sions f 3 and g 3.
 *)

 let a = 5
 let f a = a + 1
 let g b = (f b) + a

 // env1 =  | a  -> 5
 //         | f  -> fun a = a + 1
 //         | g  -> fun b = f b + 5

// f 3
// 3 + 1
// 4

// g 3
// (f 3) + 5
// 3 + 1 + 5
//  8
