module Chapter03.Section_03_07_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter03.Section_03_07

[<Fact>]
let ``Test Example 3.7: Rational number canc`` () =
   test <@ canc(2, 2) = (1, 1)  @>
   test <@ canc(-2, 2) = (-1, 1)  @>
   test <@ canc(1, 1) = (1, 1) @>
   test <@ canc(3, 12) = (1, 4) @>
   test <@ canc(12, 4) = (3, 1) @>

[<Fact>]
let ``Test Example 3.7, mkQ``() =
    test <@ mkQ(5,10) = (1,2) @>
    test <@ mkQ(2, -3) = (-2,3) @>
    raises<System.Exception> <@ mkQ(5, 0) @>
 
 
[<Fact>]
let ``Test Example 3.7, toString``() =
    let rat = (-1, 3)
    test <@ toString rat = "-1/3" @>


[<Fact>]
let ``Test Example 3.7, operators``() =
    let rat1 = (1, 2)
    let rat2 = (2, 3)
    let rat3 = (1, 1)
    test <@ rat1 .+. rat2 = (7, 6) @>
    test <@ rat1 .-. rat2 = (-1, 6) @>
    test <@ rat1 .*. rat3 = (1, 2) @>
    test <@ rat1 ./. rat2 = (3, 4) @>
    test <@ rat1 ./. rat3 = (1, 2) @>
    test <@ rat1 .=. rat2 = false @>
    test <@ rat1 .=. (1, 2) = true @>
