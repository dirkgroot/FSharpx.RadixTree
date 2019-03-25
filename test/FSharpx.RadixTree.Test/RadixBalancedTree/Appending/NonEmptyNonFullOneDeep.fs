module FSharpx.RadixTree.Test.RadixBalancedTree.Appending.``Appending to a non-empty non-full 1-depth tree``

open Xunit
open FsUnit.Xunit
open FSharpx.RadixTree
open FSharpx.RadixTree.Test.RadixBalancedTree.Helpers

[<Fact>]
let ``Creates a new tree with the same radix as the original``() =
    let original = RadixBalancedTree.empty |> RadixBalancedTree.append 1
    let appended = original |> RadixBalancedTree.append 2

    appended |> should not' (be sameAs original)
    RadixBalancedTree.radixBits appended |> should equal (RadixBalancedTree.radixBits original)

[<Fact>]
let ``The new tree has a new leaf node as the root``() =
    let original = RadixBalancedTree.empty |> RadixBalancedTree.append 1
    let appended = original |> RadixBalancedTree.append 2

    RadixBalancedTree.root appended |> should not' (be sameAs (RadixBalancedTree.root original))

[<Fact>]
let ``The new leaf node has the new item appended``() =
    let empty = RadixBalancedTree.emptyWithRadixBits 2
    let oneItem = empty |> RadixBalancedTree.append 1
    let twoItems = oneItem |> RadixBalancedTree.append 2
    let threeItems = twoItems |> RadixBalancedTree.append 3
    let fourItems = threeItems |> RadixBalancedTree.append 4

    oneItem |> RadixBalancedTree.root |> getLeafNodeItems |> should equal [| 1; 0; 0; 0 |]
    twoItems |> RadixBalancedTree.root |> getLeafNodeItems |> should equal [| 1; 2; 0; 0 |]
    threeItems |> RadixBalancedTree.root |> getLeafNodeItems |> should equal [| 1; 2; 3; 0 |]
    fourItems |> RadixBalancedTree.root |> getLeafNodeItems |> should equal [| 1; 2; 3; 4 |]

[<Fact>]
let ``The new leaf node has an updated endIndex``() =
    let tree = RadixBalancedTree.empty |> RadixBalancedTree.append 1

    RadixBalancedTree.startIndex tree |> should equal 0<pos>
    RadixBalancedTree.endIndex tree |> should equal 1<pos>
