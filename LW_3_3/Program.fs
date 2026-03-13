open System
open System.IO // для работы с файлами и каталогами

let rec readDirectory () =
    let path = 
        Console.ReadLine()

    if Directory.Exists(path) then
        path
    else
        printfn "Каталог не существует. Введите снова:"
        readDirectory()

let rec readFileName () =
    let name = 
        Console.ReadLine()

    if String.IsNullOrWhiteSpace(name) then
        printfn "Ошибка. Введите имя файла:"
        readFileName()
    else
        name

let fileExistsInDirectory dirPath fileName =
    Directory.EnumerateFiles(dirPath)  // последов. всех файлов
    |> Seq.exists (fun path -> 
        Path.GetFileName(path) = fileName)

[<EntryPoint>]
let main argv =

    printfn "Введите путь к каталогу:"
    let dirPath =
        readDirectory()

    printfn "Введите имя файла для поиска:"
    let fileName =
        readFileName()

    if fileExistsInDirectory dirPath fileName then
        printfn "Файл \"%s\" найден." fileName
    else
        printfn "Файл \"%s\" не найден." fileName

    0
