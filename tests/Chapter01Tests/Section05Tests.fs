namespace Chapter01

open System
open Xunit
open Swensen.Unquote

open Section05

module PowerFunctionTests =

    [<Fact>]
    let ``test the power function``() =
        test <@ power (1.0, 0) = 1.0 @>
        test <@ power (0.0, 1) = 0.0 @>
        test <@ power (0.0, 0) = 1.0 @>
        test <@ power (1.0, 1) = 1.0 @>
        let a = (2.0, 3)
        test <@ power a = 8.0 @>
        let b = (4.0, 2)
        test <@ power b = 16.0 @>