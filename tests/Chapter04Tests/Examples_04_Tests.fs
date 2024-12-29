module Chapter04.Examples_04_Tests

open Xunit
open Swensen.Unquote

open Chapter04.Examples_04

[<Fact>]
let ``Test Example 4.1: remove`` () =
    test <@ remove (1, []) = [] @>
    test <@ remove (1, [1; 1]) = [] @>
    test <@ remove (1, [1; 2; 1]) = [2] @>
    test <@ remove (2, [1; 2; 1]) = [1; 1] @>
    test <@ remove("a", ["a"; "abc"; "A"; "a"]) = ["abc"; "A"] @>

[<Fact>]
let ``Test Example 4.1: removeDub`` () =
    test <@ removeDub [] = [] @>
    test <@ removeDub [1] = [1] @>
    test <@ removeDub [1;1] = [1] @>
    test <@ removeDub [1;1;2;1] = [1;2] @>
    test <@ removeDub [1;2;2;1;4;1;5] = [1; 2; 4; 5]@>


let cdregTest =
    [ { Title="tl"; Artist="a1"; Company="cl";
        Year=93; Songs = [ "sl"; "s2"; "s3"; "s4";  "sS"] };
      { Title="t2"; Artist="a2"; Company="c2";
        Year=91; Songs=[ "s6"; "s7";  "s8"; "s9" ] }; 
      { Title="t3"; Artist="a1"; Company="c2";
        Year=94; Songs= [ "s10"; "s11"; "s12" ] }
    ]


//[<Fact>]
let ``Test Example 4.2: titles`` () =
    test <@ titles("al", cdregTest) = ["tl"; "t3"] @>
    test <@ titles("a2", cdregTest)  = ["t2"] @>
    test <@ titles("a3", cdregTest) = [] @>

