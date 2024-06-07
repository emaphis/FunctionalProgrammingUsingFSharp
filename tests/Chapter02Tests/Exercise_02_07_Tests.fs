module Chapter02.Exercise_02_07_Tests

open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_07

[<Fact>]
let ``Test exercise 2_7 testNotDivisible function function`` () =
    test <@ notDivisible(2,3) = true @>
    test <@ notDivisible(3,9) = false @>
    test <@ notDivisible(2,4) = false @>
    test <@ notDivisible(3, 7) = true @>
    

[<Fact>]
let ``Test exercise 2_7 testRange function``() =
    test <@ testRange(2,10, 11) = true @>
    test <@ testRange(2,11, 11) = false @>

[<Fact>]
let ``Test exercise 2_7 prime function``() =
    test <@ prime(3) = true @>
    test <@ prime(4) = false @>
    test <@ prime(5) = true @>
    test <@ prime(6) = false @>
    test <@ prime(35) = false @>
    test <@ prime(37) = true @>

[<Fact>]
let ``Test exercise 2_7 nextPrime``() =    
    test <@ nextPrime(5) = 7 @>
    test <@ nextPrime(11) = 13 @>
    test <@ nextPrime (18) = 19 @>
    test <@ nextPrime(35) = 37 @>
