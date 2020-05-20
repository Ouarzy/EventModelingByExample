module Banking.Domain.BankAccount

open System

type Euro = decimal

type Events = AccountCredited of Transaction

and Transaction =
    { Date: DateTime
      Amount: Euro
      Solde: Euro }

type State =
    { Solde: Euro }

let initial = { Solde = 0m }

let private apply (state: State) = function
    | _ -> state

let private applyAll history =
    history |> Seq.fold apply initial

let credit date amount history =
    [ AccountCredited
        { Date = date
          Amount = amount
          Solde = amount } ]
