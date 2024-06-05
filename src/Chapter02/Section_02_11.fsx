// 2.11 Function application operators |> and <|

// arg |> fct  means `fct arg`
// fct <| arg  means `fct arg`

(|>)
// val it: ('a -> ('a -> 'b) -> 'b)

(<|)
// val it: (('a -> 'b) -> 'a -> 'b)

// • The operator |> allows you to write the argument to the left of the function.
// • The operators |> and <| have lower precedence than the arithmetic operators.
