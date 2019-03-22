namespace FSharpx.RadixTree.Test.RadixBalancedTree

open Xunit
open FsUnit.Xunit
open FSharpx.RadixTree

module ``Appending to an empty tree`` =
    [<Fact>]
    let ``Yields a new tree with the same radix as the original``() =
        let empty = RadixBalancedTree.empty<int>
        let appended = RadixBalancedTree.append 1 empty

        appended |> should not' (be sameAs empty)
        RadixBalancedTree.radixBits appended |> should equal (RadixBalancedTree.radixBits empty)

    [<Fact>]
    let ``Creates a new tree with a new leaf node as the root``() =
        RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1
        |> RadixBalancedTree.root |> isALeafNode |> should be True

    [<Fact>]
    let ``The new leaf node contains [radix] items``() =
        let appended = RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1
        let rootNodeItems = RadixBalancedTree.root appended |> getLeafNodeItems

        rootNodeItems.Length |> should equal (RadixBalancedTree.radix appended)

    [<Fact>]
    let ``The first element of the new leaf node contains the appended item``() =
        let rootNodeItems = RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1
                            |> RadixBalancedTree.root |> getLeafNodeItems

        rootNodeItems.[0] |> should equal 1

    [<Fact>]
    let ``The start and end index of the new tree should correctly it's content``() =
        let appended = RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1

        RadixBalancedTree.startIndex appended |> should equal 0<pos>
        RadixBalancedTree.endIndex appended |> should equal 1<pos>

    [<Fact>]
    let ``The depth of the new tree should be 1``() =
        RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1
        |> RadixBalancedTree.depth
        |> should equal 1<lvl>

    [<Fact>]
    let ``The length of the new tree should be 1``() =
        RadixBalancedTree.empty<int> |> RadixBalancedTree.append 1
        |> RadixBalancedTree.length
        |> should equal 1<lvl>
