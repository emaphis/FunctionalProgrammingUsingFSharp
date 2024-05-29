// Swensen.Unquote exples
// Unquote can be run from `*.fsx` scripts and the `fsi` REPL
// See: <https://github.com/SwensenSoftware/unquote/wiki/UserGuide>

#r "nuget: Unquote"

open Swensen.Unquote


// Should succeede
test <@ (1+2)/3 = 1 @>

// Should fail
test <@ (1+2)/3 = 2 @>
// Test failed:
// (1 + 2) / 3 = 2
// 3 / 3 = 2
// 1 = 2
// false


// Exceptions:

// General exception testing
raises<exn> <@ (null:string).Length @>

// More specific
raises<System.NullReferenceException> <@ (null:string).Length @>

// Fails
raises<System.ArgumentException> <@ (null:string).Length @>;;
// Expected exception of type 'ArgumentException', but 'NullReferenceException' was raised instead
// null.Length


// raisesWith:

raisesWith<System.NullReferenceException> <@ (null:string).Length @> (fun e -> <@ e.ToString() = null @>);;
// The expected exception was raised, but the exception assertion failed:
// Exception Assertion:
// System.NullReferenceException: Object reference not set to an instance of an object.


// Operators

(=!)
// val it: ('a -> 'a -> unit) when 'a: equality

// Fails
[1;2;3;4] =! [4;3;2;1]

// Succeeds
[1;2;3;4] =! [1;2;3;4]

// Also see:
// <! >! <=! >=! <>! raises<'a when 'a :> exn>


// Operators used in the implementation of `Unquote`
// Could be usefull if you are experimenting with `F#` syntax

decompile
// val it: (Quotations.Expr -> string) = <fun:it@54-24>

decompile <@ (1+2)/3 @>
// val it: string = "(1 + 2) / 3"

eval
// val it: (Quotations.Expr<'a> -> 'a)

eval <@ "Hello World".Length + 20 @>
// val it: int = 31

evalRaw<int> <@@ "Hello World".Length + 20 @@>
// val it: int = 31

reduce
// val it: (Quotations.Expr -> Quotations.Expr) = <fun:it@69-26>

<@ (1+2)/3 @> |> reduce
// val it: Quotations.Expr = Call (None, op_Division, [Value (3), Value (3)])

<@ (1+2)/3 @> |> reduce |> decompile
// val it: string = "3 / 3"

reduceFully
// val it: (Quotations.Expr -> Quotations.Expr list) = <fun:it@78-27>

<@ (1+2)/3 @> |> reduceFully |> List.map decompile
// val it: string list = ["(1 + 2) / 3"; "3 / 3"; "1"]

isReduced
// val it: (Quotations.Expr -> bool) = <fun:it@84-29>

<@ (1+2)/3 @> |> isReduced  // false
<@ 1 @> |> isReduced  // true

unquote
// val it: (Quotations.Expr -> UnquotedExpression) = <fun:it@90-30>

unquote <@ (1+2)/3 @>
// val it: UnquotedExpression =
// (1 + 2) / 3
// 3 / 3
// 1
