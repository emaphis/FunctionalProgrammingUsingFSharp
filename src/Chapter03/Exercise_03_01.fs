module Chapter03.Exercise_03_01

(*
    Exercise 3.1

    A time of day can be represented as a triple (hours, minutes, f) where f is either AM or PM
    – or as a record. Declare a function to test whether one time of day comes before another. For
    example,(11,59,"AM") comes before (1,15,"PM"). Make solutions with triples as well
    as with records. Declare the functions in infix notation.
*)

// should sort in proper order
type Meridian = AM | PM


// Time as a triple

/// check if time1 is less than time2 with times represented as triples: hours * minutes * meridian
let lessthanT time1 time2 =
    let (hour1, minute1, meridian1) = time1
    let (hour2, minute2, meridian2) = time2
    (meridian1, hour1, minute1) < (meridian2, hour2, minute2)

let time1 = (11, 59, AM)
let time2 = (1, 15, PM)

let bool1 = lessthanT time1 time2
let bool2 = not (lessthanT time2 time2)


// Time as a record

type Time =
    {
        Hours : int
        Minutes : int
        Meridian : Meridian
    }


/// check if time1 is less than time2, with Time represented as a record
let lessthanR (time1: Time) (time2: Time) =
    lessthanT (time1.Hours, time1.Minutes, time1.Meridian) (time2.Hours, time2.Minutes, time2.Meridian)
   

/// Create a Time record from a time triple
let time (hours, minutes, meridian) =
    { Hours = hours; Minutes = minutes; Meridian = meridian}


let time3 = time time1
let time4 = time time2

let bool3 = lessthanR time3 time4
let bool4 = not(lessthanR time4 time3)


/// Check if time1 is less than time2
let (<.) time1 time2 = lessthanR time1 time2


let bool5 = time3 <. time4
let bool6 = not(time4 <. time3)
