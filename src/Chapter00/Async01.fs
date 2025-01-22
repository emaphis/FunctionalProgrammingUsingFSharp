// Async examples

open System
open System.IO

let owl () =
  async {
    Threading.Thread.Sleep 2000
    return "Owl"
  }

let devOwl =
  async {
    printf "Dev"
    let! owl1 = owl()
    printfn "$A" owl1
  }

Async.Start devOwl
Threading.Thread.Sleep 1000
printfn "rommsen"



[<EntryPoint>]
let main argv =
    Directory.SetCurrentDirectory($"C:\\temp\\")
    let path = "Hello.txt"
    //printTotalFileBytesUsingAsync path
   // |> Async.RunSynchronously

    Console.Read() |> ignore
    0
