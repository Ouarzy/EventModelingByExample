module Banking.Domain.BankAccount

open System

type Euro = decimal

type Events =
    | AccountCredited of Transaction
    | AccountDebited of Transaction
    | SurchargeExpected of Transaction
and Transaction =
    { Date: DateTime
      Amount: Euro
      Solde: Euro }

type State =
    { Solde: Euro }

let initial = { Solde = 0m }

let private apply (state: State) = function
    | AccountCredited event -> { Solde = state.Solde + event.Amount }
    | AccountDebited event -> { Solde = state.Solde - event.Amount }
    | _ -> state

let private applyAll history =
    history |> Seq.fold apply initial

let credit date amount history =
    let state = applyAll history
    [ AccountCredited
        { Date = date
          Amount = amount
          Solde = amount + state.Solde} ]

let debit date amount history =
    let state = applyAll history
    let transaction = {Date = date; Amount = amount; Solde = state.Solde - amount}
    if state.Solde - amount > 0m then
       [ AccountDebited transaction ]
    else [ AccountDebited transaction; SurchargeExpected transaction ]
