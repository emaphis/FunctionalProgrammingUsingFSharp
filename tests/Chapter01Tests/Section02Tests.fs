namespace Chapter01

open System
open Xunit
open Swensen.Unquote

open Section02

module Section02Tests =

    [<Fact>]
    let ``assert pi``() =
        Assert.Equal( 3.141592654, pi, 0.0001)

    [<Fact>]
    let ``assert circleArea1 and pi``() =
        Assert.Equal( pi, (circleArea1 1.0), 0.0001)

    [<Fact>]
    let ``assert circleArea1``() =
        let expected = 12.56637061
        Assert.Equal( expected, (circleArea1 2.0), 0.0001)


    [<Fact>]
    let ``assert circleArea 0``() =
        let expected = 0.0
        Assert.Equal( expected, (circleArea 0.0), 0.0001)


    [<Fact>]
    let ``assert circleArea 2.0``() =
        let expected = 12.56637061
        Assert.Equal( expected, (circleArea 2.0), 0.0001)
