module Chapter03.Section_03_07_Tests_A

open Xunit
open Swensen.Unquote

open Chapter03.Section_03_07_A


[<Fact>]
let ``Test Example 3.7, mkQ``() =
    raises<QDiv> <@ mkQ(3, 0) @>
    test <@ mkQ(2, -3) = (2, -3) @>
    test <@ mkQ(5, -10) = (5, -10) @>
 

let q1 = mkQ(2, -3)
let q2 = mkQ(5, -10)
let q3 = q1 .+. q2  //(-35, 30)
let q4 = q2 .*. q3  // (-175, -300)
let q5 = q4 ./. q3  //  (-5250, 10500)


[<Fact>]
let ``Test Example 3.7, operators``() =
    test <@ q1 .+. q2 = (-35, 30) @>
    test <@ q1 .-. q2 = (-5, 30) @>
    test <@ q2 .*. q3 = (-175, -300) @>
    test <@ q4 ./. q3 = (-5250, 10500) @>
    test <@ q1 .=. q1 = true  @>
    test <@ q1 .=. q2 = false @>


[<Fact>]
let ``Text Example 3.7a gcd`` () =
    test <@ gcd(0, 5) = 5 @>
    test <@ gcd(3,5) = 1 @>
    test <@ gcd(3, 15) = 3 @>


[<Fact>]
let ``Test Example 3.7, toString``() =
    test <@ toString q1 = "-2/3" @>
    test <@ toString q4 = "7/12" @>
    test <@ toString q5 = "-1/2" @>
    