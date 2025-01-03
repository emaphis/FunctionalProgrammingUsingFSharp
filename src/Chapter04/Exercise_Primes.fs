module Chapter04.Exercise_Primes

(*
   Prime numbers package
   Exercises from Hansen and Rischel's SML textbook.
   Updated Exercises 2.7 and completed exercises 5.4 and 5.5.
*)

let notDivisible(den, num) = num % den <> 0


/// Returns `true` if num is not divisible by any of the integers
/// in the range fst -> lst inclusive
let rec testRange(fst, lst, num) =
    fst > lst || notDivisible(fst, num) && testRange(fst+1, lst, num)


/// Returns true if number is prime
let isPrime num = num > 1 && testRange(2, num - 1, num)


/// Given a number find next prime.
let rec nextPrime num =
    let next = num + 1
    if isPrime next then next
    else nextPrime next



/// Reverse a list
let reverse xs =
    let rec loop xs aux =
        match xs with
        | [] -> aux
        | x::xs -> loop xs (x::aux)
    loop xs []


(*
Exercise 5.4
    Declare an F#L function pr: int -> int list such that pr n is the list of
    the first n prime numbers. (Use solutions of Exercise 2.7.)
*)


/// Produce a list of the first `n` prime numbers
let pr n =
    let rec loop  count list next =
        match count with
        | cnt when cnt = n -> reverse (next::list)
        | _ ->  loop  (count + 1) (next::list) (nextPrime next)

    loop 1 [] 2 ;;

(*
pr 1 = [2]
pr 2 = [2; 3]
pr 5 = [2; 3; 5; 7; 11]
*)


(*
Exercise 5.5
    Declaration SF# function `pr': int * int -> int list` so that `pr'(m,n)` is
    the list of the prime numbers between m and n.
*)

let pr' m n =
    let rec loop list next =
        match next with
        | nxt when nxt >= (n+1) -> reverse list
        | _ ->  loop  (next::list) (nextPrime next)

    loop [] (nextPrime (m-1)) ;;

(*
pr' 1 1 = []
pr' 1 2 = [2]
pr' 2 3 = [2;3]
pr' 4 14 = [5; 7; 11; 13]
pr' 6 23 = [7; 11; 13; 17; 19; 23]
*)
