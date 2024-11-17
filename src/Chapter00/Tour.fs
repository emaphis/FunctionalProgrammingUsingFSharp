// Sample that will demonstrate various F# features.

namespace Tour

// For more information see:
//      https://fsharp.org
//      https://learn.microsoft.com/dotnet/fsharp/
//
// This tutorial:
//      https://learn.microsoft.com/dotnet/fsharp/tour
//

// Open namespace wusing `open` keyword
open System

/// Modules are the primary way to organize functions and values in F#. This module contains some
/// basic values involving basic numeric values computed in a few diferent ways.
///
/// https://learn.microsoft.com/dotnet/fsharp/language-reference/modules
module IntegersAndNumbers =

    /// This is a simple integer.
    let sampleInteger = 176

    /// This is a ssample floating point number.
    let sampleDouble = 4.1


    /// This computed a new number by some arithmetic.  Numeric types are converted using
    /// functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// This is a list of the numbers from 0 to 99
    let sampleNumbers = [ 0 .. 99 ]

    /// This is a list of all the tuples containing all the numbers from 0 to 99 and thier squares.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // The next line prints a list that includes tup;es, using an interpolated string.
    printfn $"The table of squares from 0 to 99 is:\n{sampleTableOfSquares}"


/// The values are immutable by default. They cannot be changed
/// in the course of a program's execution unless explicitly marked as 'mutable'
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Binding a value to a name via 'let' makes it immutable.
    ///
    /// The second line of code compiles, but 'number' from that point onward will hsadow the previous definition
    /// There is no way to access the previous definiton of 'number' due to shadowing.
    let number = 2
    //let number = 3  // compilation error

    /// A mutable binding. This is requred to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2

    printfn $"'otherNumber' is {otherNumber}"

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this. Outside binding values via 'let', '=' is used to test equality
    otherNumber <- otherNumber + 1

    printfn $"'otherNumber' changed to {otherNumber}"


/// Much of F# programming consists of defining functions that transform input data to produce
/// useful results.
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/
module BasicFunctions =

    /// You use 'let' to define a function. This one accepts an integer argument and return an integer
    /// Parentheses are optional for function arguements, except for when you use an explicit type annotations
    let sampleFunction1 x = x * x + 3

    /// Apply the function, naming the function return result using 'let'.
    /// The variable type is inferred from the function return type.
    let result1 = sampleFunction1 4573

    // This line uses '%d' to print the result as an integer. This is type-safe.
    // If 'result1' were not of type 'int', then the line would fail to compile.
    printfn $"The result of squaring the integer 4573 and adding 3 is %d{result1}"

    /// When needed, annotate the type of a parameter name using '(argument:type)'. Parentheses are required.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn $"The result of applying the 2nd sample function to (7 + 4) is %d{result2}"

    /// Conditionals use if/then/elif/else.
    ///
    /// Note that F# uses white space indentation-aware syntax, similar to languages like Python.
    let sampleFunction3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // This line uses '%f' to print the result as a float.  As with '%d' above, this is type-safe.
    printfn $"The result of applying the 3rd sample function to (6.5 + 4.5) is %f{result3}"


/// Booleans are fundamental data types in F#.  Here are some examples of Booleans and conditional logic.
///
/// See:
///     https://learn.microsoft.com/dotnet/fsharp/language-reference/primitive-types
///     https://learn.microsoft.com/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Booleans values are 'true' and 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Operators on booleans are 'not', '&&' and '||'
    let boolean3 = not boolean1 && (boolean2 || false)

    // This line uses '%b'to print a boolean value.  This is type-safe.
    printfn $"The expression 'not boolean1 && (boolean2 || false)' is %b{boolean3}"


/// Strings are fundamental data types in F#.  Hare some examples of Strings and basic String manipulation
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/string
module StringManipulation =

    /// Strings use doulbe quotes.
    let string1 = "Hello"
    let string2 = "world"

    /// Strings can also use '@' to create a verbatim string literal.
    let string3 = @"C:\Program files\"

    /// String concatenation is normally done with the '+' operator.
    let helloWorld = string1 + " " + string2


    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" helloWorld

    /// Substrings use the indexer notation.  This line extracts the first 7 characters as a substring.
    /// Note that like many languages, Strings are zero-indexed in F#,
    let substring = helloWorld[0..6]
    printfn $"{substring}"


/// Tuples are simple combinations of data values into a combine value.
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/tuples
module Tuples =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple
    ///
    /// F# Type Inference will automatically generalize the functo to hava a genereic type,
    /// meaning that it will work with any type
    let swapElems (a, b) = (b, a)

    let elems1 = swapElems(1, 2)
    printfn $"Ther result of swapping (1, 2) is {elems1}"

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertable with object tuples (often calle reference tuples).
    ///
    /// The second line below will fail to compile because of this.  Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Although you can
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    let sampleTuple2 = convertFromStructTuple sampleStructTuple
    printfn $"Struct Tuple: {sampleStructTuple}\nReference tuple made from the Struct Tuple: {sampleTuple2}"


/// The F# pipe operators ('|>', '<|', etc.) and F# composition operators ('>>', '<<')
/// are used extensively when processing data.  These operators are themselves functions
/// which make use of Partial Application.
///
/// See:
///     https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/#function-composition-and-pipelining
///     https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelineAndCompostion =

    /// Squares a value
    let square x = x * x

    /// Adds 1 to a value
    let addOne x = x + 1

    /// Tests if an integer value is odd via modulo.
    ///
    /// '<>' is a binary comparison operator that means "not equal to".
    let isOdd x = x % 2 <> 0

    /// A list of 5 numbers.  More on lists later.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Given a list of integers, it filtrs out the even numbers,
    /// squares the resulting odds, and adds 1 to the squared odds.
    let squaredOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map  square odds
        let result = List.map addOne squares
        result

    let values1 = squaredOddValuesAndAddOne numbers
    printfn $"processing {numbers} through 'squareOddValuesAndAddOne' produces {values1}"

    /// You can shorten 'squareOddValuesAndAddOnePipeline' by moving the second `List.map` call
    /// into the first, using a Lambda Function.
    ///
    /// Note that pipelines are also being used inside the lambda function.  F# pipe operators
    /// can be used for single values as well.  This makes them very powerful for processing data.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map (fun x -> x |> square |> addOne)

    let values2 = squareOddValuesAndAddOneShorterPipeline numbers
    printfn $"processing {numbers} through 'squareOddValuesAndAddOneShorterPipeline' produce: {values2}"

    /// Lastly, you can eliminate the need to explicitly take 'values' in as a parameter by using '>>'
    /// to compose the two core operations: filtering out even numbers, then squaring and adding one.
    /// Likewise, the 'fun x -> ...' bit of the lambda expression is also not needed, because 'x' is simply
    /// being defined in that scope so that it can be passed to a functional pipeline.  Thus, '>>' can be used
    /// there as well.
    ///
    /// The result of 'squareOddValuesAndAddOneComposition' is itself another function which takes a
    /// list of integers as its input.  If you execute 'squareOddValuesAndAddOneComposition' with a list
    /// of integers, you'll notice that it produces the same results as previous functions.
    ///
    /// This is using what is known as function composition.  This is possible because functions in F#
    /// use Partial Application and the input and output types of each data processing operation match
    /// the signatures of the functions we're using.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    let values3 = squareOddValuesAndAddOneComposition numbers
    printfn $"processing {numbers} through 'squareOddValuesAndAddOneComposition' produces: {values3}"


/// Lists are ordered, immutable, single-linked lists.  They are eager in their evaluation.
///
/// This module shows various ways to generate lists and process lists with some functions
/// in the 'List' module in the F# Core Library
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/lists
module Lists =

    /// Lists are define using { ... }. This is an empty list.
    let list1 = [ ]

    /// This is a list with 3 elements. ';' is used to separate element on the same line
    let list2 = [ 1; 2; 3 ]

    /// You can also separate elements by placing them on their own lines.
    let list3 = [
        1
        2
        3
    ]

    /// This is a list of integers from 1 to 1000
    let numberList = [ 1 .. 1000 ]

    /// Lists can also be generated by computations. This is a list containing
    /// all the days of the year.
    ///
    /// 'yield' is used for on-demand evaluation. More on this later in Sequences.
    let daysList =
        [ for month in 1 .. 12 do
            for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                yield System.DateTime(2017, month, day) ]

    // Print the first 5 elements of 'daysList' using 'List.take'.
    printfn $"The first 5 days of 2017 are: {daysList |> List.take 5}"

    /// Computations can include conditionals.  This is a list containing the tuples
    /// which are the coordinates of the black squares on a chess board.
    let blackSquares =
        [ for i in 0 .. 7 do
            for j in 0 .. 7 do
                if (i+j) % 2 = 1 then
                    yield (i, j) ]

    printfn $"Coordinates of black squares: {blackSquares}"

    /// Lists can be transformed using 'List.map' and other functional programming combinators.
    /// This definition produces a new list by squaring the numbers in numberList, using the pipeline
    /// operator to pass an argument to List.map
    let squares =
        numberList
        |> List.map (fun x -> x * x)

    printfn $"The squares of numbers form 1 to a 1000: {squares}"

    /// There are many other list combinations. The following cumputes the sum of the squares of the
    /// numbers divisible by 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn $"The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d{sumOfSquares}"


/// Arrays are fixed-size, mutalbe collections of elements of the same type.
///
/// Although they are similar to Lists (they support enumeration and have similar combinators for data processing).
/// they are generally faster and support fast random access.  This comes at the cost of being less safe by being mutable.
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/arrays
module Arrays =

    /// This is the empty array.  Note taht the syntax is similar to that of lists, bur uses '[| ... |]' instead
    let array1 = [| |]

    /// Arrays are specified using the same range of contructs as lists.
    let array2 = [| "Hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// This is an array of numbers from 1 to 1000
    let array3 = [| 1 .. 1000 |]

    /// Thiis an array containing only the words "hello" and "world"
    let array4 =
        [|  for word in array2 do
                if word.Contains("l") then
                    yield word |]

    /// This is an array initialized by index and containing the even numbers from 0. to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Sub-arrays are extracted using slicing notation.
    let evenNumbersSlice = evenNumbers[0 .. 500]

    // You can loop over arrays and lists using 'for' loops
    for word in array4 do
        printfn $"word: {word}"


    // You can modify the contents of an array element by using the left arrow assignment operator.
    //
    // Note that in this case, similar to lists, array2 is not mutated by Array.filter.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn $"The sum of the lengths of the words in Array 2 is: %d{sumOfLengthsOfWords}"


/// Sequences are a logical series of elements, all of the same type.  These are a more general type than Lists or Arrays.
///
/// Sequences are evaluated on-demand and are re-evaluated each time they are iterated.
/// An F# sequence is an alias for a .NET System.Collections.Generic.IEnumerable<'T>
///
/// Sequence processing functions can be applied to Lists and Arrays as well.
///
/// See:  https://learn.microsoft.com/dotnet/fsharp/language-reference/sequences
module Sequences =

    /// This is the empty sequence.
    let seq1 = Seq.empty

    /// This is a sequence of values.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// This is an on-demand sequence from 1 to 1000.
    let numberSeq = seq { 1 .. 1000 }

    /// This a sequence producing the words "hello" and "world"
    let seq3 =
        seq { for word in seq2 do
                if word.Contains"l" then
                    yield word }

    /// This is a sequence producing the even numbers up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This examples uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// This example show the first 1000 elements of the random walk
    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList


/// Recursive functions can call themselves.  In F#, functions are only recursive
/// when declared using the 'let rec'.
///
/// Recursion is the preferred way to process sequences or collections inF#.
///
/// See:  https://learn.microsoft.com/dotnet/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions =

    /// This example shows a recursive function that computes the factorial of an
    /// integer.  It uses 'let rec' to define a recursive function.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    printfn $"Factorial of 6 is: %d{factorial 6}"

    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 300 620}"

    /// This example computes the sum of a list of integers using recursion.
    ///
    /// '::' is used to split a list inot the head and tail of the list,
    /// the head being the first element and the tail being the reso of the list.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    let oneThroughTen = [ 1; 2; 3; 4; 5; 6; 7; 8; 9; 10 ]

    let sum1 = sumList oneThroughTen
    printfn $"The sum of the list of 1 through 10 is {sum1}"

    /// This makes 'sumList' tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An opproach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let sum2 = sumListTailRecursive oneThroughTen
    printfn $"The sum of the list of 1 through 10 is {sum2}"


/// Records are an aggregate of named values, with optional members (such as methods).
/// They are immutable and have structural equality semantix.
///
/// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/records
module RecordTypes =

    /// This example shows how to define a new record type.
    type ContactCard =
        { Name      : string
          Phone     : string
          Verified  : bool }

    /// This example shows how to instantiate a record type.
    let contact1 =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false }

    /// You can also do this on the same line with ';' separators.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// This example shows how to use "copy-and-update" on record values. It creates
    /// a new record value that is a copy of contact1, but has different values for
    /// the 'Phone' and 'Verified' fields.
    ///
    /// See: https://learn.microsoft.com/dotnet/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0122"
            Verified = true }

    /// This example shows how to write a function that processes a record value.
    /// It converts a 'ContactCard' object to a string.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn $"Alf's Contact Card: {showContactCard contact1}"

    /// This is an example of a Record with a member
    type ContactCardAlternate =
        { Name      : string
          Phone     : string
          Address   : string
          Verified  : bool }

        /// Members can implement object-oriented members.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified) " else " ") + this.Address

    let contactAlternate =
        { Name = "Alf"
          Phone = "(206) 555-0157"
          Verified = false
          Address = "111 Alf Street" }

    // Members are accessed via the '.' operator on an instantiated typel
    printfn $"Alfs' alternative contact card is {contactAlternate.PrintedContactCard}"

    /// Records can also be represented as structs via the 'Struct' attribute.
    /// This is helpful in situations where the performance of structs outweighs
    /// the flexibility of reference types.
    [<Struct>]
    type ContactCardStruct =
        { Name      : string
          Phone     : string
          Verified  : bool }
