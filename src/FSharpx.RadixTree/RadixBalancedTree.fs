namespace FSharpx.RadixTree

open System

[<Measure>] type lvl
[<Measure>] type pos
[<Measure>] type items

type Node<'T> =
    | None
    | Branch of Node<'T> array
    | Leaf of 'T array

type RadixBalancedTree<'T>(radixBits: int, depth: int<lvl>, endIndex: int<pos>, root: Node<'T>) =
    let radix = 1 <<< radixBits

    member this.RadixBits = radixBits
    member this.Radix = radix

    member this.Root: Node<'T> = root
    member this.Depth = depth
    member this.StartIndex = 0<pos>
    member this.EndIndex = endIndex

    member this.Append newValue =
        let values =
            match root with
            | None -> Array.zeroCreate radix
            | Branch _ -> raise (new NotImplementedException())
            | Leaf items -> Array.copy items

        values.[int endIndex] <- newValue
        RadixBalancedTree<'T>(radixBits, 1<lvl>, endIndex + 1<pos>, Leaf values)

module RadixBalancedTree =
    [<Literal>]
    let DefaultRadixBits = 5

    let empty<'T> = RadixBalancedTree<'T>(DefaultRadixBits, 0<lvl>, 0<pos>, None)
    let emptyWithRadixBits<'T> (radixBits: int) = RadixBalancedTree<'T>(radixBits, 0<lvl>, 0<pos>, None)

    let radixBits (t: RadixBalancedTree<_>) = t.RadixBits
    let radix (t: RadixBalancedTree<_>) = t.Radix
    let length (t: RadixBalancedTree<_>) = (t.EndIndex - t.StartIndex) * 1<items/pos>
    let depth (t: RadixBalancedTree<_>) = t.Depth
    let root (t: RadixBalancedTree<_>) = t.Root
    let startIndex (t: RadixBalancedTree<_>) = t.StartIndex
    let endIndex (t: RadixBalancedTree<_>) = t.EndIndex

    let append (newValue: 'T) (t: RadixBalancedTree<'T>) = t.Append newValue
