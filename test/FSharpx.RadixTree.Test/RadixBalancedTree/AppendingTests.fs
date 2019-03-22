namespace FSharpx.RadixTree.Test.RadixBalancedTree

open Xunit
open FsUnit.Xunit
open FSharpx.RadixTree

module ``Appending to an empty tree`` =
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

    [<Fact>]
    let ``The start and end index of the new tree should correctly it's content``() =
        let appended = RadixBalancedTree.empty |> RadixBalancedTree.append 1

        RadixBalancedTree.startIndex appended |> should equal 0<pos>
        RadixBalancedTree.endIndex appended |> should equal 1<pos>

    [<Fact>]
    let ``The depth of the new tree should be 1``() =
        RadixBalancedTree.empty |> RadixBalancedTree.append 1
        |> RadixBalancedTree.depth
        |> should equal 1<lvl>

    [<Fact>]
    let ``The length of the new tree should be 1``() =
        RadixBalancedTree.empty |> RadixBalancedTree.append 1
        |> RadixBalancedTree.length
        |> should equal 1<items>

module ``Appending to a non-empty non-full 1-depth tree`` =
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
