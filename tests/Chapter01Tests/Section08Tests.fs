namespace Chapter01

open System
open Xunit
open Swensen.Unquote

open Section08

module EuclidsAlgorithm =

    [<Fact>]
    let ``test the GCD function``() =
        test <@ gcd(12, 27) = 3 @>
        test <@ gcd(36, 116) = 4 @>
        test <@ gcd(0, 0) = 0 @>
        test <@ gcd(1, 1) = 1 @>
        test <@ gcd(1, 7) = 1 @>
