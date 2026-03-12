open System

let readLinesSequence (count: int) : seq<string> =
    seq {
        for _ in 1 .. count do
            yield Console.ReadLine() // считывает строку и добавляет её как следующий элемент
    }

let countEven (acc: int) (line: string) =
    if line.Length % 2 = 0 then 
        acc + 1
    else 
        acc

let countEvenLength (lines: seq<string>) : int =
    Seq.fold countEven 0 lines // проходит по каждому элементу и копит результат с помощью acc

[<EntryPoint>]
let main argv =

    printfn "Введите количество строк:"
    let count = 
        int (Console.ReadLine())

    printfn "Введите строки:"

    let lines : seq<string> = 
        readLinesSequence count

    let result = 
        countEvenLength lines

    printfn "Количество строк с чётной длиной: %d" result

    0