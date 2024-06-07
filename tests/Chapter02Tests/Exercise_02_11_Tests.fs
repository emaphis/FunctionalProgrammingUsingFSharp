
module Chapter02.Exercise_02_11_Tests
open System
open Xunit
open Swensen.Unquote

open Chapter02.Exercise_02_11

[<Fact>]
let ``Test exercise 2_11 VAT and unVAT functions`` () =
    let vat0 = VAT 0 1.0
    let vat1 = VAT 10 100.0
    Assert.Equal(vat0, 1.0)
    Assert.Equal(vat1, 110.0)
    
    let unVat0 = unVAT 0 vat0
    let unVat1 = unVAT 10 vat1
    Assert.Equal(unVat0, 1.0, 0.001)
    Assert.Equal(unVat1, 100.0, 0.001)
