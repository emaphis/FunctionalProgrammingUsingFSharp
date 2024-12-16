module Chapter03.Exercise_03_02_Tests

open Xunit
open Swensen.Unquote

open Chapter03.Exercise_03_02


[<Fact>]
let ``Test Exercise 3.2: normalize`` () =
   test <@ normalize (0, 0, 11)  = (0, 0, 11)  @>
   test <@ normalize (0, 0, 12)  = (0, 1, 0) @>
   test <@ normalize (0, 0, 13)  = (0, 1, 1) @>
   test <@ normalize (0, 0, 24)  = (0, 2, 0) @>
   test <@ normalize (0, 19, 0)  = (0, 19, 0) @>
   test <@ normalize (0, 20, 0)  = (1, 0, 0) @>
   test <@ normalize (0, 21, 0)  = (1, 1, 0) @>
   test <@ normalize (1, 19, 12) = (2, 0, 0) @>
   test <@ normalize (0, 0, 24)  = (0, 2, 0) @>
   test <@ normalize (0, 38,24)  = (2, 0, 0) @>

   test <@ normalize (0, 1, -12)   = (0, 0, 0) @>
   test <@ normalize (1,-20,1)     = (0, 0, 1) @>
   test <@ normalize (2, -39, -12) = (0, 0, 0) @>
   

[<Fact>]
let ``Test Exercise 3.2 +. operator`` () =
   test <@ (10, 10, 0) +. (10, 10, 1) = (21, 0, 1) @>
   test <@ (0, 0, 0) +. (0, 0, 0)     = (0, 0, 0) @>
   test <@ (1, 1, 1) +. (1, 1, 1)     = (2, 2, 2) @>
   test <@ (0, 0, 11) +. (0, 0, 1)    = (0, 1, 0) @>
   test <@ (0, 37, 23) +. (0, 1, 1)   = (2, 0, 0) @>
   test <@ (1, 18, 11) +. (1, 1, 1)   = (3, 0, 0) @>


[<Fact>]
let ``Test Exercise 3.2 -. operator``() =
   test <@ (1, 1, 1) -. (0, 0, 0)   = (1, 1, 1) @>
   test <@ (1, 1, 1) -. (1, 1, 1)   = (0, 0, 0) @>
   test <@ (1, 0, 1) -. (0, 5, 11)  = (0, 14, 2) @>
   test <@ (1, 0, 0) -. (0, 12, 19) = (0, 6, 5) @>


[<Fact>]
let ``Test Exercise 3.2: normalizeR`` () =
   test <@ normalizeR { Pounds = 0; Shillings = 0; Pence = 11 } = { Pounds = 0; Shillings = 0; Pence = 11 } @>
   test <@ normalizeR { Pounds = 0; Shillings  = 0; Pence = 12 } = { Pounds = 0; Shillings = 1; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 0; Pence = 13 } = { Pounds = 0; Shillings = 1; Pence = 1 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 0; Pence = 24 } = {  Pounds =0; Shillings = 2; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 19; Pence = 0 } = { Pounds = 0; Shillings = 19; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 20; Pence = 0 } = { Pounds = 1; Shillings = 0; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 21; Pence = 0 } = { Pounds = 1; Shillings = 1; Pence = 0 } @>
   test <@ normalizeR { Pounds = 1; Shillings = 19; Pence = 12 } = { Pounds = 2; Shillings = 0; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 0; Pence = 24 } = { Pounds = 0; Shillings = 2; Pence = 0 } @>
   test <@ normalizeR { Pounds = 0; Shillings = 38; Pence = 24 } = { Pounds = 2; Shillings = 0; Pence = 0 } @>

   test <@ normalizeR { Pounds = 0; Shillings = 1; Pence = -12 } = { Pounds = 0; Shillings = 0; Pence = 0 } @>
   test <@ normalizeR { Pounds = 1; Shillings = -20; Pence = 1 } = { Pounds =  0; Shillings = 0; Pence = 1 } @>
   test <@ normalizeR { Pounds = 2; Shillings = -39; Pence = -12 } = { Pounds = 0; Shillings = 0; Pence =  0 } @>
