namespace Chapter01

open System
open Xunit
open Swensen.Unquote

open Section03

module LambdaTests =

    [<Fact>]
    let ``assert cr``() =
        Assert.Equal( 3.141592654, cr 1.0, 0.0001)

    
    [<Fact>]
    let ``assert area``() =
        Assert.Equal( area1, area2, 0.0001)

    [<Fact>]
    let ``assert circleArea1``() =
        let expected = 12.56637061
        Assert.Equal( expected, (circleArea 2.0), 0.0001)


    [<Fact>]
    let ``assert circleArea 0``() =
        let expected = 0.0
        Assert.Equal( expected, (circleArea 0.0), 0.0001)


    [<Fact>]
    let ``assert circleArea 2.0``() =
        let expected = 12.56637061
        Assert.Equal( expected, (circleArea 2.0), 0.0001)


module LambdasWithPatterns =

    [<Fact>]
    let ``assert Frebfuary``() =
        test <@ daysOfMonth 2 = 28 @>

    
    [<Fact>]
    let ``assert April``() =
        test <@ daysOfMonth 4 = 30 @>

    [<Fact>]
    let ``assert October``() =
        test <@ daysOfMonth 10 = 31 @>

