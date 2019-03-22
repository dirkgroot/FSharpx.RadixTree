[<AutoOpen>]
module FSharpx.RadixTree.Test.RadixBalancedTree.Helpers

open System
open FSharpx.RadixTree

let isAnEmptyNode = function
    | None -> true
    | Branch _ -> false
    | Leaf _ -> false

let isALeafNode = function
    | None -> false
    | Branch _ -> false
    | Leaf _ -> true

let getLeafNodeItems = function
    | None -> raise (new ArgumentException())
    | Branch _ -> raise (new ArgumentException())
    | Leaf items -> items
