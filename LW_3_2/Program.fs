open System

let rec readCount () =
    let input = 
        Console.ReadLine()

    let success, number = 
        Int32.TryParse input

    if success && number > 0 then
        number
    else
        printfn "Ошибка. Введите натуральное число:"
        readCount()

let readLinesSequence (count: int) : seq<string> =
    seq {
        for _ in 1 .. count do
            yield Console.ReadLine()
    }

let countEven (acc: int) (line: string) =
    if line.Length % 2 = 0 then 
        acc + 1
    else 
        acc

let countEvenLength (lines: seq<string>) : int =
    Seq.fold countEven 0 lines 

[<EntryPoint>]
let main argv =

    printfn "Введите количество строк:"
    let count =
        readCount()

    printfn "Введите строки:"

    let lines : seq<string> =
        readLinesSequence count

    let result =
        countEvenLength lines

    printfn "Количество строк с чётной длиной: %d" result

    0
