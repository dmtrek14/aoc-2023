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


//GetAndSumCalibrationValues "./data/input.txt"


let GetAndSumCalibrationValuesPartTwo(filepath: string) =
    let mutable totalPartTwo = 0
    let numberWordRegex = new Regex("\W*((?i)(one|two|three|four|five|six|seven|eight|nine|zero)|[0-9](?-i))\W*")
    let numberWordRegexLast = new Regex("\W*((?i)(one|two|three|four|five|six|seven|eight|nine|zero)|[0-9](?-i))\W*", RegexOptions.RightToLeft)
    System.IO.File.ReadLines(filepath)
    |> Seq.iter( fun s2 ->
        //printfn $"{s2}"
        //find matches to the regex, then take first and last, then convert to numbers and sum
        let firstMatch = numberWordRegex.Match(s2)
        let lastMatch = numberWordRegexLast.Match(s2)
        let first = firstMatch.Value
        let last = lastMatch.Value
        let mutable firstMutated = ""
        if first = "one" then firstMutated <- "1"
        elif first = "two" then firstMutated <- "2"
        elif first = "three" then firstMutated <- "3"
        elif first = "four" then firstMutated <- "4"
        elif first = "five" then firstMutated <- "5"
        elif first = "six" then firstMutated <- "6"
        elif first = "seven" then firstMutated <- "7"
        elif first = "eight" then firstMutated <- "8"
        elif first = "nine" then firstMutated <- "9"
        elif first = "zero" then firstMutated <- "0"
        else firstMutated <- first

        let mutable lastMutated = ""
        if last = "one" then lastMutated <- "1"
        elif last = "two" then lastMutated <- "2"
        elif last = "three" then lastMutated <- "3"
        elif last = "four" then lastMutated <- "4"
        elif last = "five" then lastMutated <- "5"
        elif last = "six" then lastMutated <- "6"
        elif last = "seven" then lastMutated <- "7"
        elif last = "eight" then lastMutated <- "8"
        elif last = "nine" then lastMutated <- "9"
        elif last = "zero" then lastMutated <- "0"
        else lastMutated <- last

        let combined = (firstMutated.ToString() + lastMutated.ToString())
        let num = combined |> int
        printfn $"{num}"
        totalPartTwo <- totalPartTwo + num
    )
    printfn $"{totalPartTwo}"
    totalPartTwo

GetAndSumCalibrationValuesPartTwo "./data/input_part2.txt"
