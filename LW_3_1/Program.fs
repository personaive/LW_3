open System

let rec readCount () =
    let input = 
        Console.ReadLine()

    let success, number = 
        Int32.TryParse input

    if success && number >= 0 then
        number
    else
        printfn "Ошибка. Введите натуральное число:"
        readCount()

let rec readFloat () =
    let input = 
        Console.ReadLine()

    let success, number = 
        Double.TryParse input

    if success then
        number
    else
        printfn "Ошибка. Введите вещественное число:"
        readFloat()

let truncateNumber (x: float) : int =
    int x

[<EntryPoint>]
let main argv =

    printfn "Введите количество элементов последовательности:"
    let count =
        readCount()

    printfn "Введите вещественные числа:"

    let floatSequence =
        seq { for _ in 1 .. count ->
                readFloat() }
        |> Seq.cache

    printfn "Вещественные числа:"
    floatSequence |> Seq.iter (printf "%.2f ") // %.2f для 
    printfn ""                                 // чисел float

    let intSequence =
        floatSequence |> Seq.map truncateNumber

    printfn "Целые числа (без дробной части):"
    intSequence |> Seq.iter (printf "%d ")
    printfn ""

    0
