namespace Examples


(*
    Swenson.Unquote examples
*)


open System
open Xunit
open Swensen.Unquote


module UnquoteTests =

    [<Fact>]
    let ``My test`` () =
        Assert.True(true)

    [<Fact>]
    let ``simple test``() =
        test <@ (1+2)/3 = 1 @>


    [<Fact>]
    let ``demo Unquote xUnite support``() =
        test <@ ([3; 2; 1; 0] |> List.map ((+) 1)) = [4; 3; 2; 1] @>

    [<Fact>]
    let ``testing general exceptions``() =
        raises<exn> <@ (null:string).Length @>

    [<Fact>]
    let ``testing specific exceptions``() =
        raises<System.NullReferenceException> <@ (null:string).Length @>
