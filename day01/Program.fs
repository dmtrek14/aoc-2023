open System.Text.RegularExpressions

let GetAndSumCalibrationValues(filepath: string) =
    let mutable total = 0
    System.IO.File.ReadLines(filepath)
    |> Seq.iter ( fun s1 ->
        let filtered = Regex.Replace(s1, "[^0-9]", "")
        let first = filtered[0]
        let last = filtered |> Seq.last
        let combinedChars = (first.ToString() + last.ToString())
        let num = combinedChars |> int
        printfn $"{num}"
        total <- total + num
    )
    printfn $"{total}"
    total


GetAndSumCalibrationValues "./data/input.txt"
