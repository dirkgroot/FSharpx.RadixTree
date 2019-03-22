# FSharpx.RadixTree
This is an attempt to practice F# by (perhaps) creating something useful in the process.

My objective is to create a general-purpose implementation of a Relaxed Radix Balanced tree, based on the 
[original paper by P. Bagwell and T. Rompf](https://infoscience.epfl.ch/record/169879/files/RMTrees.pdf).

Learning and practicing will be my primary goal with this, so I may never actually finish it. What do I want to
practice/learn, you might ask:
* Better understand the F# language itself (syntax, library);
* Test Driven Development with F#:
  * xUnit;
  * FsUnit;
  * ...
* Performance measurement: When I've got a first version working, I'd like to do some tests to see how it performs;
* Probably more...

## Some background
To my surprise, F# does not have any built-in immutable collections which support (near) O(1) get/nth operations and 
appending/slicing. Inspired by [this issue](https://github.com/fsprojects/FSharpx.Collections/issues/72)
on FSharpx.Collections (which has been inactive since july 2018), I figured that creating an RRB tree in F# might be a 
nice learning experience.

So far, I'm having lots of fun :).
