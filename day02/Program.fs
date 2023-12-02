﻿open System.Text.RegularExpressions


let checkPossibleGamesPartOne (filepath: string) =
    let red = 12
    let green = 13
    let blue = 14
    let mutable gameIdsAdded = 0
    let gameNumRegex = new Regex("\d+(?=:)")
    let gamesRegex = new Regex("(?<=\: ).*")
    let blueRegex = new Regex("\d+ blue")
    let redRegex = new Regex("\d+ red")
    let greenRegex = new Regex("\d+ green")
    let digitRegex = new Regex("\d+")
    System.IO.File.ReadLines(filepath)
    |> Seq.iter ( fun s1 ->
        let game = gameNumRegex.Match(s1)
        let gameId = game.Value |> int
        let gameCubes = gamesRegex.Match(s1)
        let blues = blueRegex.Matches(s1)
        let mutable possibleMeter = 0
        let mutable impossibleMeter = 0

        for b in blues do
            let blueDigits = digitRegex.Matches(b.Value)
            for bd in blueDigits do
                let bdInt = bd.Value |> int
                if bdInt > blue then
                   impossibleMeter <- impossibleMeter + 1
                else
                    possibleMeter <- possibleMeter + 1

        let reds = redRegex.Matches(s1)
        for r in reds do
            let redDigits = digitRegex.Matches(r.Value)
            for rd in redDigits do
                let rdInt = rd.Value |> int
                if rdInt > red then
                    impossibleMeter <- impossibleMeter + 1
                else
                    possibleMeter <- possibleMeter + 1

        let greens = greenRegex.Matches(s1)
        for g in greens do
            let greenDigits = digitRegex.Matches(g.Value)
            for gd in greenDigits do
                let gdInt = gd.Value |> int
                if gdInt > green then
                    impossibleMeter <- impossibleMeter + 1
                else
                    possibleMeter <- possibleMeter + 1

        printfn $"Game {gameId} - possible meter = {possibleMeter}, impossible meter = {impossibleMeter}"

        if possibleMeter > 0 && impossibleMeter = 0 then
            gameIdsAdded <- gameIdsAdded + gameId

        printfn $"{gameIdsAdded}"
    )

//checkPossibleGamesPartOne "./data/input.txt"


let checkPossibleGamesPartTwo (filepath: string) =
    let mutable gamePowersAdded = 0
    let gameNumRegex = new Regex("\d+(?=:)")
    let gamesRegex = new Regex("(?<=\: ).*")
    let blueRegex = new Regex("\d+ blue")
    let redRegex = new Regex("\d+ red")
    let greenRegex = new Regex("\d+ green")
    let digitRegex = new Regex("\d+")

    let getDigit digitString : int =
        let digit = digitRegex.Match(digitString)
        digit.Value |> int

    System.IO.File.ReadLines(filepath)
    |> Seq.iter ( fun s1 ->
        let game = gameNumRegex.Match(s1)
        let gameId = game.Value |> int
        let gameCubes = gamesRegex.Match(s1)

        let blues = blueRegex.Matches(s1)
        let blueArray = [| for b in blues -> getDigit b.Value |]
        let minBlues = Seq.max blueArray
        printfn $"Game {gameId} blue min is {minBlues}"

        let reds = redRegex.Matches(s1)
        let redArray = [| for r in reds -> getDigit r.Value |]
        let minReds = Seq.max redArray
        printfn $"Game {gameId} red min is {minReds}"

        let greens = greenRegex.Matches(s1)
        let greenArray = [| for g in greens -> getDigit g.Value |]
        let minGreens = Seq.max greenArray
        printfn $"Game {gameId} green min is {minGreens}"

        let power = minBlues * minReds * minGreens

        gamePowersAdded <- gamePowersAdded + power

        printfn $"Total power: {gamePowersAdded}"
    )

checkPossibleGamesPartTwo"./data/input_part2.txt"
