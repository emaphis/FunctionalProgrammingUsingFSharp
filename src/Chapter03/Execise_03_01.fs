module Chapter03.Execise_03_01

(*
    Exercise 3.1

    A time of day can be represented as a triple (hours, minutes, f) where f is either AM or PM
    – or as a record. Declare a function to test whether one time of day comes before another. For
    example,(11,59,"AM") comes before (1,15,"PM"). Make solutions with triples as well
    as with records. Declare the functions in infix notation.
*)

// should sort in proper order
type Meridian = AM | PM


/// check if time1 is less than time2
let lessthan1 time1 time2 =
    let (hour1, minute1, meridian1) = time1
    let (hour2, minute2, meridian2) = time2
    (meridian1, hour1, minute1) < (meridian2, hour2, minute2)


let bool1 = lessthan1 (11,59,AM) (1,15,PM)
let bool2 = not(lessthan1 (1,15,PM) (11,59,AM))


type time =
    {
        hours : int
        minutes : int
        meridian : Meridian
    }


/// check if time1 is less than time2
let lessthan2 (time1: time) (time2: time) =
    lessthan1 (time1.hours, time1.minutes, time1.meridian) (time2.hours, time2.minutes, time2.meridian)


let time1 = { hours = 11; minutes = 59; meridian = AM }
let time2 = { hours = 1; minutes = 15; meridian = PM }


let bool3 = lessthan2 time1 time2
let bool4 = not(lessthan2 time2 time1)


/// Check if time1 is less than time2
let (<.) time1 time2 = lessthan2 time1 time2


let bool5 = time1 <. time2
let bool6 = not(time2 <. time1)
