[<AutoOpen>]
module FSharpx.RadixTree.Test.RadixBalancedTree.Helpers

open FSharpx.RadixTree

let isAnEmptyNode = function
    | None -> true
    | _ -> false

let isALeafNode = function
    | Leaf _ -> true
    | _ -> false

let isABranchNode = function
    | Branch _ -> true
    | _ -> false

let getLeafNodeItems node =
    match node with
    | Leaf items -> items
    | _ -> invalidArg "node" "Only Leaf nodes are supported"

let getBranchNodeItems node =
    match node with
    | Branch items -> items
    | _ -> invalidArg "node" "Only Branch nodes are supported"
