open System
open System.IO

let measurements =
    File.ReadAllLines("input.txt")
    |> Array.map Int32.Parse

let partOne =
    measurements
    |> Array.pairwise
    |> Array.map (fun data ->
        match data with
        | (a, b) when a < b -> 1
        | (a, b) when a >= b -> 0
        | _ -> 0)
    |> Array.sum

printfn $"Part 1: %i{partOne}"

let partTwo =
    measurements
    |> Array.windowed 3
    |> Array.map (fun data -> data.[0] + data.[1] + data.[2])
    |> Array.pairwise
    |> Array.map (fun data ->
        match data with
        | (a, b) when a < b -> 1
        | (a, b) when a >= b -> 0
        | _ -> 0)
    |> Array.sum

printfn $"Part 2: %i{partTwo}"