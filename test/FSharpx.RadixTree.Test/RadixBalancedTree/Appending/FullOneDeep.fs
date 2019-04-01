module FSharpx.RadixTree.Test.RadixBalancedTree.Appending.``Appending to a full 1-depth tree``

open FSharpx.RadixTree
open FSharpx.RadixTree.Test.RadixBalancedTree
open FsUnit
open Xunit

let createFull =
    RadixBalancedTree.emptyWithRadixBits 1
    |> RadixBalancedTree.append 1
    |> RadixBalancedTree.append 2 

[<Fact>]
let ``Creates a new tree with the same radix as the original and an updated endIndex``() =
    let full = createFull
    let appended = RadixBalancedTree.append 3 full

    appended |> should not' (be sameAs full)
    RadixBalancedTree.radix appended |> should equal (RadixBalancedTree.radix full)
    RadixBalancedTree.endIndex appended |> should equal 3

[<Fact>]
let ``Creates a new tree with a branch root``() =
    let full = createFull
    let appended = RadixBalancedTree.append 3 full

    RadixBalancedTree.root appended |> isABranchNode |> should be True

[<Fact>]
let ``The first element of the new branch root points to the root of the full tree``() =
    let full = createFull
    let appended = RadixBalancedTree.append 3 full

    let appendedRootItems = getBranchNodeItems (RadixBalancedTree.root appended)

    appendedRootItems.[0] |> should be (sameAs (RadixBalancedTree.root full))

[<Fact>]
let ``The second element of the new branch root is a new leaf with the appended value as its first element``() =
    let full = createFull
    let appended = RadixBalancedTree.append 3 full

    let appendedRootItems = getBranchNodeItems (RadixBalancedTree.root appended)
    let appendedLeafItems = getLeafNodeItems appendedRootItems.[1] 

    appendedLeafItems.Length |> should equal (RadixBalancedTree.radix appended)
    appendedLeafItems.[0] |> should equal 3
