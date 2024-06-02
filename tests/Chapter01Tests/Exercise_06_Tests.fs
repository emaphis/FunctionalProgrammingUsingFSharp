namespace Chapter01.Exercises

open System
open Xunit
open Swensen.Unquote

open Chapter01.Exercise_06

module Exercise_06 =

    [<Fact>]
    let ``test the sum(m,n) function``() =
        test <@ sum(0,0) = 0 @>
        test <@ sum(0,1) = 1 @>
        test <@ sum(1,0) = 1 @>
        test <@ sum(1,1) = 3 @>
        test <@ sum(1,2) = 6 @>
        test <@ sum(2,1) = 5 @>
        test <@ sum(2,2) = 9 @>
        test <@ sum(2,3) = 14 @>
        test <@ sum(2,5) = 27 @>
        test <@ sum(3,2) = 12 @>
        test <@ sum(3,3) = 18 @>
        test <@ sum(4,1) = 9 @>
        test <@ sum(4,2) = 15 @>
        test <@ sum(5,3) = 26 @>
        test <@ sum(5,5) = 45 @>
