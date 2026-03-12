open System

let truncateNumber (x: float) : int =
    int x

[<EntryPoint>]
let main argv =

    printfn "Введите количество элементов последовательности:"
    let count =
        int (Console.ReadLine())

    printfn "Введите вещественные числа:"
    let floatSequence =
        seq { for _ in 1 .. count ->
                float (Console.ReadLine()) }


    let intSequence =
        floatSequence |> Seq.map truncateNumber

    printfn "Последовательность без дробной части:"

    intSequence |> Seq.iter (printf "%d ") // проходит по каждому элементу и выполняет действие,
    printfn ""                             // но не создаёт новую последовательность.

    0