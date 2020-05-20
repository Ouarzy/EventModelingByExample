module Banking.Tests.Domain.BankAccount

open System
open Banking.Domain.BankAccount
open Xunit

open Banking.Tests.Dsl
open Banking.Domain

module ``my command should`` =

    [<Fact>]
    let ``fail`` () =
      Given []
      |> When BankAccount.credit DateTime.Now 10m
      |> Then []
