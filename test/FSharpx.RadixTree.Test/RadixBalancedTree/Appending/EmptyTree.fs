module FSharpx.RadixTree.Test.RadixBalancedTree.Appending.``Appending to an empty tree``

open Xunit
open FsUnit.Xunit
open FSharpx.RadixTree
open FSharpx.RadixTree.Test.RadixBalancedTree.Helpers

[<Fact>]
let ``Creates a new tree with the same radix as the original``() =
    let empty = RadixBalancedTree.empty
    let appended = RadixBalancedTree.append 1 empty

    appended |> should not' (be sameAs empty)
    RadixBalancedTree.radixBits appended |> should equal (RadixBalancedTree.radixBits empty)

[<Fact>]
let ``The new tree has a new leaf node as the root``() =
    RadixBalancedTree.empty |> RadixBalancedTree.append 1
    |> RadixBalancedTree.root |> isALeafNode |> should be True

[<Fact>]
let ``The new leaf node contains [radix] items``() =
    let appended = RadixBalancedTree.emptyWithRadixBits 1 |> RadixBalancedTree.append 1
    let rootNodeItems = RadixBalancedTree.root appended |> getLeafNodeItems

    rootNodeItems.Length |> should equal 2

[<Fact>]
let ``The first element of the new leaf node contains the appended item``() =
    let rootNodeItems = RadixBalancedTree.empty |> RadixBalancedTree.append 1
                        |> RadixBalancedTree.root |> getLeafNodeItems

    rootNodeItems.[0] |> should equal 1
