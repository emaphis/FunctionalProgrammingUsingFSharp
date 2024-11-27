module Chapter03.Exercise_03_01_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_01
open Exercise_03_01

let time1 = (11, 59, AM)
let time2 = (1, 15, PM)

[<Fact>]
let ``Test Exercise 3.1: time as a triple`` () =
   test <@ lessthanT time1 time2 = true  @>
   test <@ not (lessthanT time2 time2) = true  @>

let time3 = time time1
let time4 = time time2

[<Fact>]
let ``Test Exercise 3.1, Time record``() =
    test <@ lessthanR time3 time4 = true @>
    test <@ not(lessthanR time4 time3) = true @>
 
[<Fact>]
let ``Test Exercise 3.1, LT operator``() =
    test <@ time3 <. time4 = true @>
    test <@ not(time4 <. time3) = true @>
