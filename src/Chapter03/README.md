# Chapter 3 - Tuples, records and tagged values

Compound values created with tuples, records and tagged values (discriminated unions). Are formed by combining values of other types.

Tuples are used in expressing "functions of several variables."

The components of Records are identified by special identifiers called labels.

Tagged values are used when we group together values of different kinds to form a single set of values.

Tuples, records and tagged values are treated as “first-class citizens” in F#: Meaning that they can be used in any expression.

    3 Tuples, records and tagged values 43
    3.1 Tuples 43
    3.2 Polymorphism 48
    3.3 Example: Geometric vectors 48
    3.4 Records
    3.5 Example: Quadratic equations 52
    3.6 Locally declared identifiers 54
    3.7 Example: Rational numbers. Invariants 56
    3.8 Tagged values. Constructors 58
    3.9 Enumeration types 62
    3.10 Exceptions 63
    3.11 Partial functions. The option type