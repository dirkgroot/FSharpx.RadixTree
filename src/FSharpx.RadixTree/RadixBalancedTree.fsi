namespace FSharpx.RadixTree

[<Measure>] type lvl
[<Measure>] type pos
[<Measure>] type items

type Node<'T> =
    | None
    | Branch of Node<'T> array
    | Leaf of 'T array

[<Class>]
type RadixBalancedTree<'T> = class end

module RadixBalancedTree =
    /// Returns an empty tree 5 bits for the radix (see <see cref="radixBits" />),
    /// resulting in a branching factor of 2^5 = 32.
    val empty<'T> : RadixBalancedTree<'T>

    /// Returns an empty tree using the supplied number of <see cref="radixBits" />,
    /// resulting in a branching factor of 2^(radixBits tree).
    val emptyWithRadixBits: int -> RadixBalancedTree<'T>

    /// Returns the number of bits needed to represent the radix.
    val radixBits: RadixBalancedTree<_> -> int

    /// Returns the radix of the tree. The radix is calculated as follows:
    /// <c>(1 <<< radixBits) - 1</c>
    val radix: RadixBalancedTree<_> -> int

    /// Returns the number of items in the tree.
    val length: RadixBalancedTree<_> -> int<items>

    /// Returns the depth of the tree.
    val depth: RadixBalancedTree<_> -> int<lvl>

    /// Returns the root node of the tree.
    val root: RadixBalancedTree<'T> -> Node<'T>

    /// Returns the start index of the tree.
    val startIndex: RadixBalancedTree<_> -> int<pos>

    /// Returns the start index of the tree.
    val endIndex: RadixBalancedTree<_> -> int<pos>

    /// Returns a new tree with the supplied value added to the back.
    val append: 'T -> RadixBalancedTree<'T> -> RadixBalancedTree<'T>
