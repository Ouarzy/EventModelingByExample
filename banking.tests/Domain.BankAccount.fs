module Banking.Tests.Domain.BankAccount

open System
open Banking.Domain.BankAccount
open Xunit

open Banking.Tests.Dsl
open Banking.Domain

module ``credit should`` =

    [<Fact>]
    let ``raise account credited`` () =
        let expectedDate = DateTime.Now
        let expectedAmount = 15m
        Given []
        |> When BankAccount.credit expectedDate expectedAmount
        |> Then
            [ AccountCredited
                { Date = expectedDate
                  Amount = expectedAmount
                  Solde = expectedAmount } ]


    [<Fact>]
    let ``raise account credited when credited account`` () =
        let expectedDate = DateTime.Now
        let initialSolde = 15m
        let creditAmount = 15m
        let expectedSolde = initialSolde + creditAmount
        Given
            [ AccountCredited
                { Date = expectedDate
                  Amount = initialSolde
                  Solde = initialSolde } ]
        |> When BankAccount.credit expectedDate creditAmount
        |> Then
            [ AccountCredited
                { Date = expectedDate
                  Amount = creditAmount
                  Solde = expectedSolde } ]
