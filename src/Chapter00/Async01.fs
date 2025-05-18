// Async examples

open System
open System.IO

type User = User of Guid

type Post = {
    Content : string
    NumberOViews : int
}

// Get the top three posts.

let user username : User option =
    // replace with fancy query logic
    Guid.NewGuid()
    |> User
    |> Some
    
let postsOfUser (user: User option) : Post list =
    match user with
    | Some user ->
        // Find all posts for the user.
        [
            { Content = "Post 1"; NumberOViews = 10 }
            { Content = "Post 2"; NumberOViews = 0 }
            { Content = "Post 3"; NumberOViews = 5 }
            { Content = "Post 4"; NumberOViews = 42 }
        ]
    | None -> []


let top3 posts =
    posts
    |> List.sortByDescending (fun post -> post.NumberOViews)
    |> List.take 3


let contents posts =
    posts
    |> List.map (fun post -> post.Content)


let topPostsOfOwl =
    user "dev-owl"
    |> postsOfUser
    |> top3
    |> contents



// Asynchronous query.


let userAsync (username: string) : Async<User option> =
    async {
        return
            Guid.NewGuid()
            |> User
            |> Some
    }

let postsOfUserAsync (user: User option) : Async<Post list> =
    async {
        match user with
        | Some user ->
            // Find all posts for the user.
            return [
                { Content = "Post 1"; NumberOViews = 10 }
                { Content = "Post 2"; NumberOViews = 0 }
                { Content = "Post 3"; NumberOViews = 5 }
                { Content = "Post 4"; NumberOViews = 42 }
            ]
        | None -> return []
    }

let bind1 binder value =
    async {
        let! value = value
        return! binder value
    }

let map1 mapper asnc =
    async {
        let! value = asnc
        return value |> mapper
    }

let toUpper (strings: string list) =
    strings
    |> List.map (fun s -> s.ToUpper())


let topPostsOfOwlAsync =
    userAsync "dev-owl"
    |> bind1 postsOfUserAsync
    |> map1 top3
    |> map1 contents
    |> map1 toUpper
    |> Async.RunSynchronously
