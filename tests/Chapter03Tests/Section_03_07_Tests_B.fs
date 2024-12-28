module Chapter03.Section_03_07_Tests_B

open Xunit
open Swensen.Unquote

open Chapter03.Section_03_07_B

[<Fact>]
let ``Test Example 3.7b: Rational number gcd`` () =
    test <@ gcd(0, 5) = 5 @>
    test <@ gcd(3, 5) = 1 @>
    test <@ gcd(3, 15) = 3 @>


[<Fact>]
let ``Test Example 3.7b: Rational number canc`` () =
   test <@ canc(2, 2) = (1, 1)  @>
   test <@ canc(-2, 2) = (-1, 1)  @>
   test <@ canc(1, 1) = (1, 1) @>
   test <@ canc(1, 2) = (1, 2) @>
   test <@ canc(-5, 10) = (-1, 2) @>
   test <@ canc(3, 12) = (1, 4) @>
   test <@ canc(12, 4) = (3, 1) @>


[<Fact>]
let ``Test Example 3.7, mkQ``() =
    test <@ mkQ(5, 10) = (1,2) @>
    test <@ mkQ(2, -3) = (-2, 3) @>
    raises<QDiv> <@ mkQ(5, 0) @>
 
 
let q1 = mkQ(2, -3) // (-2, 3)
let q2 = mkQ(5, 10) // (1, 2)
let q3 = q1 .+. q2  // (-1, 6))
let q4 = q2 .*. q3  // (-1, 12)

[<Fact>]
let ``Test Example 3.7, operators``() =
    test <@ q1 .+. q2 = (-1, 6) @>
    test <@ q1 .-. q2 = (-7, 6) @>
    test <@ q2 .*. q3 = (-1, 12) @>
    test <@ q4 ./. q3 = (1, 2) @>
    test <@ q1 .=. q2 = false @>
    test <@ q1 .=. (-2, 3) = true @>


[<Fact>]
let ``Test Example 3.7, toString``() =
    test <@ toString q3 = "-1/6" @>
