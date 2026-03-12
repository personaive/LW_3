open System
open System.IO // классы и функции для работы с файлами и каталогами

let fileExistsInDirectory dirPath fileName =
    Directory.EnumerateFiles(dirPath)  // последовательность всех файлов
    |> Seq.exists (fun path -> Path.GetFileName(path) = fileName) // есть ли совпадение

[<EntryPoint>]
let main argv =

    printfn "Введите путь к каталогу:"
    let dirPath = 
        Console.ReadLine()

    printfn "Введите имя файла для поиска:"
    let fileName = 
        Console.ReadLine()

    if fileExistsInDirectory dirPath fileName then
        printfn "Файл \"%s\" найден." fileName
    else
        printfn "Файл \"%s\" не найден." fileName

    0