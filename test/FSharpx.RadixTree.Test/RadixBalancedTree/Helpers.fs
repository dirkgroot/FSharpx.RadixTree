[<AutoOpen>]
module FSharpx.RadixTree.Test.RadixBalancedTree.Helpers

open FSharpx.RadixTree

let isAnEmptyNode = function
    | None -> true
    | Branch _ -> false
    | Leaf _ -> false

let isALeafNode = function
    | None -> false
    | Branch _ -> false
    | Leaf _ -> true

let getLeafNodeItems node =
    match node with
    | Leaf items -> items
    | _ -> invalidArg "leafNode" "Only Leaf nodes are supported"
