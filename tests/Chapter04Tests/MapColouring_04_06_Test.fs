module Chapter04Tests.MapColouring_04_06_Test

open Xunit
open Swensen.Unquote

open Chapter04.MapColouring_04_06


[<Fact>]
let ``Test CashRegister 4.6 MapColouring`` () =

    // Example - Colouring problem with 4 countries
    let exMap : Map = [("a", "b"); ("c", "d"); ("d", "a")]

    // should produce the example colouring
    let exColouring = [["c"; "a"]; ["b"; "d"]]

    test <@ canBeExtendBy exMap ["c"] "a" = true @>
    test <@ canBeExtendBy exMap ["a"; "c"] "b" = false @>

    test <@ extColouring exMap [] "a" = [["a"]] @>
    test <@ extColouring exMap [["c"]] "a" = [["a"; "c"]] @>
    test <@ extColouring exMap [["b"]] "a"  = [["b"]; ["a"]] @>

    test <@ colMap exMap = exColouring  @>
