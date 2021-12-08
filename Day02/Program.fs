open System
open System.IO

let (|Int|_|) str =
   match Int32.TryParse(str:string) with
   | (true,int) -> Some(int)
   | _ -> None

let parseCommand (command: string) =
    match command.Split [|' '|] |> Array.toList with
    | direction :: Int amount :: _ -> (direction, amount)
    | _ -> failwith "unexpected command"
    
let followCommandPart1 (horizontal_position, depth) command =
    match command with
    | ("forward", amount) -> (horizontal_position + amount, depth)
    | ("down", amount) -> (horizontal_position, depth + amount)
    | ("up", amount) -> (horizontal_position, depth - amount)
    | _ -> failwith "unexpected command"
    
let followCommandPart2 (horizontal_position, depth, aim) command =
    match command with
    | ("forward", amount) -> (horizontal_position + amount, depth + (aim * amount), aim)
    | ("down", amount) -> (horizontal_position, depth, aim + amount)
    | ("up", amount) -> (horizontal_position, depth, aim - amount)
    | _ -> failwith "unexpected command"
    
let commands =
    File.ReadAllLines("input.txt")
    |> Array.map (parseCommand)
    
let (horizontal_position_1, depth_1) =
    Array.fold followCommandPart1 (0, 0) commands
    
printfn "Part 1"
printfn $"end position: %i{horizontal_position_1} %i{depth_1}"
printfn $"product: %i{horizontal_position_1 * depth_1}"
printfn ""

let (horizontal_position_2, depth_2, aim_2) =
    Array.fold followCommandPart2 (0, 0, 0) commands
    
printfn "Part 2"
printfn $"end position: %i{horizontal_position_2} %i{depth_2} %i{aim_2}"
printfn $"product: %i{horizontal_position_2 * depth_2}"