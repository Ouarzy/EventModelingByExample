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


