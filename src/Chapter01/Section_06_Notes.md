# Section 1.6  Types and type checking

Type checking in F# is an integral process in software development. The compiler will reject expressions that don't type check properly.

Type consideration for function application $f(e)$ is a special case of the general type rule for function application:

$$
\boxed{\text{if } f \text{ has type } \tau_1 \rarr \tau_2 \text{ and } e \text{ has type } \tau_1\\
 \text{ then } f(e) \text{ has type } \tau_2.}
$$

Using the notation $e : \tau $ to assert that the expression $e$ has type $\tau$ , this rule can be
presented more succinctly as follows:

$$
\boxed{\text{if } f : \tau_1 \rarr \tau_2 \text { and } e : \tau_1\\
\text{ then } f(e) : τ2.}
$$
